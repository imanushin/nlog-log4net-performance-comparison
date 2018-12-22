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
    public class EmptyLoggers
    {
        private ILog _log4Net;
        private Logger _nlog;

        [Params(1000)]
        public int _intArgument;

        [Params("32197463298746")]
        public string _stringArgument;

        [GlobalSetup]
        public void Setup()
        {
            _log4Net = GetLog4NetLogger();
            _nlog = GetNLogLogger();
        }

        [Benchmark]
        public void Log4NetNoParams() => _log4Net.DebugFormat("test");

        [Benchmark]
        public void Log4NetSingleReferenceParam() => _log4Net.DebugFormat("test {0}", _stringArgument);

        [Benchmark]
        public void Log4NetSingleValueParam() => _log4Net.DebugFormat("test {0}", _intArgument);
        
        [Benchmark]
        public void Log4NetMultipleReferencesParam() => _log4Net.DebugFormat(
            "test {0} {1} {2} {3} {4} {5} {6} {7} {8}",
            _stringArgument,
            _stringArgument,
            _stringArgument,
            _stringArgument,
            _stringArgument,
            _stringArgument,
            _stringArgument,
            _stringArgument,
            _stringArgument);

        [Benchmark]
        public void Log4NetMultipleValuesParam() => _log4Net.DebugFormat(
            "test {0} {1} {2} {3} {4} {5} {6} {7} {8}",
            _intArgument,
            _intArgument,
            _intArgument,
            _intArgument,
            _intArgument,
            _intArgument,
            _intArgument,
            _intArgument,
            _intArgument);

        [Benchmark]
        public void NLogNetNoParams() => _nlog.Debug("test");

        [Benchmark]
        public void NLogNetSingleReferenceParam() => _nlog.Debug("test {0}", _stringArgument);

        [Benchmark]
        public void NLogNetSingleValueParam() => _nlog.Debug("test {0}", _intArgument);

        [Benchmark]
        public void NLogNetMultipleReferencesParam() => _nlog.Debug(
            "test {0} {1} {2} {3} {4} {5} {6} {7} {8}",
            _stringArgument,
            _stringArgument,
            _stringArgument,
            _stringArgument,
            _stringArgument,
            _stringArgument,
            _stringArgument,
            _stringArgument,
            _stringArgument);

        [Benchmark]
        public void NLogNetMultipleValuesParam() => _nlog.Debug(
            "test {0} {1} {2} {3} {4} {5} {6} {7} {8}",
            _intArgument,
            _intArgument,
            _intArgument,
            _intArgument,
            _intArgument,
            _intArgument,
            _intArgument,
            _intArgument,
            _intArgument);

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

            return LogManager.GetLogger(typeof(EmptyLoggers));
        }
    }
}