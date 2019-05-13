using System;
using System.Diagnostics;
using System.IO;
using BenchmarkDotNet.Attributes;
using NLog;
using NLog.Config;
using NLog.Targets;
using NLog.Targets.Wrappers;
using Logger = NLog.Logger;

namespace Comparison.Runner
{
    public class AsyncFileLogging : BaseTest
    {
        private Logger _nlog;

        [Params(1000)]
        public int _intArgument;

        [Params("32197463298746")]
        public string _stringArgument;

        [GlobalSetup]
        public void Setup()
        {
            var logsFolder = $"logs_{DateTime.UtcNow.Ticks}_{Process.GetCurrentProcess().Id}";

            if (Directory.Exists(logsFolder))
            {
                Directory.Delete(logsFolder, true);
            }

            Directory.CreateDirectory(logsFolder);

            var info = new DirectoryInfo(logsFolder);

            StartClass.Folders.Add(info);

            _nlog = GetNLogLogger();
        }

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

        private static Logger GetNLogLogger()
        {
            // from https://github.com/nlog/NLog/wiki/Configuration-API
            var config = new LoggingConfiguration();

            var fileTarget = new FileTarget("target2")
            {
                FileName = "${basedir}/file-async.txt",
                Layout = "${longdate} ${threadid} ${logger} ${level} ${message} ${exception}"
            };

            var asyncWrapper = new AsyncTargetWrapper(fileTarget)
            {
                Name = "async",
                OverflowAction = AsyncTargetWrapperOverflowAction.Block,
                BatchSize = 4096,
                FullBatchSizeWriteLimit = 128
            };
            config.AddTarget(asyncWrapper);

            config.AddRuleForOneLevel(LogLevel.Info, asyncWrapper);

            LogManager.Configuration = config;

            return LogManager.GetCurrentClassLogger();
        }
    }
}