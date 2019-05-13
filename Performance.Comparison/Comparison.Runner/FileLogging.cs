using System;
using System.Diagnostics;
using System.IO;
using BenchmarkDotNet.Attributes;
using log4net;
using log4net.Appender;
using log4net.Config;
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
    public class FileLogging : BaseTest
    {
        private Logger _nlog;
        private ILog _log4Net;
        private string _logsFolder;

        [Params(1000)]
        public int _intArgument;

        [Params("ltfdmhiubtc")]
        public string _stringArgument;

        [GlobalSetup]
        public void Setup()
        {
            _logsFolder = CreateLogFolder();

            _log4Net = GetLog4NetLogger();
            _nlog = GetNLogLogger();
        }

        [Benchmark]
        public void Log4NetNoParams() => _log4Net.InfoFormat("test");

       [Benchmark]
        public void Log4NetSingleReferenceParam() => _log4Net.InfoFormat("test {0}", _stringArgument);

        [Benchmark]
        public void Log4NetSingleValueParam() => _log4Net.InfoFormat("test {0}", _intArgument);

        [Benchmark]
        public void Log4NetMultipleReferencesParam() => _log4Net.InfoFormat(
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
        public void Log4NetMultipleValuesParam() => _log4Net.InfoFormat(
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
        public void NLogNetNoParams() => _nlog.Info("test");

        [Benchmark]
        public void NLogNetSingleReferenceParam() => _nlog.Info("test {0}", _stringArgument);

        [Benchmark]
        public void NLogNetSingleValueParam() => _nlog.Info("test {0}", _intArgument);

        [Benchmark]
        public void NLogNetMultipleReferencesParam() => _nlog.Info(
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
        public void NLogNetMultipleValuesParam() => _nlog.Info(
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

        private Logger GetNLogLogger()
        {
            // from https://github.com/nlog/NLog/wiki/Configuration-API
            var config = new LoggingConfiguration();

            var fileTarget = CreateNLogAppender(_logsFolder);
            config.AddTarget(fileTarget);

            config.AddRuleForOneLevel(LogLevel.Info, fileTarget);

            NLog.LogManager.Configuration = config;

            return NLog.LogManager.GetCurrentClassLogger();
        }

        private ILog GetLog4NetLogger()
        {
            BasicConfigurator.Configure();

            // from https://stackoverflow.com/questions/16336917/can-you-configure-log4net-in-code-instead-of-using-a-config-file
            var hierarchy = (Hierarchy)LogManager.GetRepository();

            hierarchy.ResetConfiguration();
            hierarchy.Clear();

            var patternLayout = new PatternLayout();
            patternLayout.ConversionPattern = "%date [%thread] %-5level %logger %message%newline";
            patternLayout.ActivateOptions();

            var roller = new RollingFileAppender();
            roller.AppendToFile = false;
            roller.File = $"{_logsFolder}/log4net.txt";
            roller.Layout = patternLayout;
            roller.ImmediateFlush = true;
            roller.RollingStyle = RollingFileAppender.RollingMode.Once;
            roller.MaxFileSize = 128 * 1000 * 1000;
            roller.ActivateOptions();

            hierarchy.Threshold = Level.Info;
            hierarchy.Root.Level = Level.Info;
            hierarchy.Root.AddAppender(roller);

            hierarchy.Configured = true;
            
            return LogManager.GetLogger(GetType());
        }
    }
}