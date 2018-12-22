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
    public class NoOpLogging : BaseLoggingBenchmarks
    {
        [GlobalSetup]
        public void Setup()
        {
            _log4Net = GetLog4NetLogger();
            _nlog = GetNLogLogger();
        }

        private static Logger GetNLogLogger()
        {
            // from https://github.com/nlog/NLog/wiki/Configuration-API
            var config = new LoggingConfiguration();
            
            var fileTarget = new FileTarget("target2")
            {
                FileName = "${basedir}/file.txt",
                Layout = "${longdate} ${level} ${message}  ${exception}"
            };
            config.AddTarget(fileTarget);
            
            // Step 3. Define rules
            config.AddRuleForOneLevel(LogLevel.Info, fileTarget); // only errors to file

            // Step 4. Activate the configuration
            NLog.LogManager.Configuration = config;

            return NLog.LogManager.GetCurrentClassLogger();
        }

        private static ILog GetLog4NetLogger()
        {
            // from https://stackoverflow.com/questions/16336917/can-you-configure-log4net-in-code-instead-of-using-a-config-file
            var hierarchy = (Hierarchy)LogManager.GetRepository();

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

            return LogManager.GetLogger(typeof(NoOpLogging));
        }
    }
}