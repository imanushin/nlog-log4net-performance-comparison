using System.Threading;
using BenchmarkDotNet.Attributes;
using log4net;
using log4net.Appender;
using log4net.Core;
using log4net.Layout;
using log4net.Repository.Hierarchy;
using NLog;
using NLog.Config;
using NLog.Targets;
using Logger = NLog.Logger;
using LogManager = log4net.LogManager;

namespace Comparison.Runner
{
    [ClrJob(baseline: true)]
    [RPlotExporter, RankColumn]
    public class CreateLogger
    {
        private int _index;

        [GlobalSetup]
        public void Setup()
        {
            _index = 0;

            ConfigureLog4Net();
            ConfigureNLog();
        }

        [Benchmark]
        public void CreateLog4Net()
        {
            for (var i = 0; i < 1024 * 256; i++)
            {
                LogManager.GetLogger(Interlocked.Increment(ref _index).ToString());
            }
        }

        [Benchmark]
        public void CreateNLog()
        {
            for (var i = 0; i < 1024 * 256; i++)
            {
                NLog.LogManager.GetLogger(Interlocked.Increment(ref _index).ToString());
            }
        }

        [IterationCleanup]
        public void Cleanup()
        {
            _index = 0;

            ConfigureLog4Net();
            ConfigureNLog();
        }

        private static void ConfigureNLog()
        {
            // from https://github.com/nlog/NLog/wiki/Configuration-API
            var config = new LoggingConfiguration();

            var fileTarget = new FileTarget("target2")
            {
                FileName = "${basedir}/file.txt",
                Layout = "${longdate} ${level} ${message}  ${exception}"
            };
            config.AddTarget(fileTarget);

            config.AddRuleForOneLevel(LogLevel.Info, fileTarget); // only errors to file

            NLog.LogManager.Configuration = config;

            NLog.LogManager.GetCurrentClassLogger();
        }

        private static void ConfigureLog4Net()
        {
            // from https://stackoverflow.com/questions/16336917/can-you-configure-log4net-in-code-instead-of-using-a-config-file
            var hierarchy = (Hierarchy)LogManager.GetRepository();

            hierarchy.ResetConfiguration();
            hierarchy.Clear();

            var patternLayout = new PatternLayout();
            patternLayout.ConversionPattern = "%date [%thread] %-5level %logger - %message%newline";
            patternLayout.ActivateOptions();

            var roller = new RollingFileAppender();
            roller.AppendToFile = false;
            roller.File = @"Logs\EventLog.txt";
            roller.Layout = patternLayout;
            roller.MaxSizeRollBackups = 5;
            roller.MaximumFileSize = "1GB";
            roller.RollingStyle = RollingFileAppender.RollingMode.Size;
            roller.StaticLogFileName = true;
            roller.ActivateOptions();
            hierarchy.Root.AddAppender(roller);

            hierarchy.Root.Level = Level.Info;
            hierarchy.Configured = true;

            LogManager.GetLogger(typeof(CreateLogger));
        }
    }
}