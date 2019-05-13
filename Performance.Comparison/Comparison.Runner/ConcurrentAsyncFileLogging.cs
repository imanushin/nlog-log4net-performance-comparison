using System;
using System.Diagnostics;
using System.IO;
using BenchmarkDotNet.Attributes;
using NLog;
using NLog.Config;
using NLog.Targets.Wrappers;
using Logger = NLog.Logger;

namespace Comparison.Runner
{
    public class ConcurrentAsyncFileLogging : BaseTest
    {
        private string _logsFolder;
        private Logger _optimized;
        private Logger _concurrentWrites;
        private Logger _closeFile;
        private Logger _concurrentWritesAndCloseFile;

        [GlobalSetup]
        public void Setup()
        {
            _logsFolder = CreateLogFolder();

            // from https://github.com/nlog/NLog/wiki/Configuration-API
            var config = new LoggingConfiguration();

            var fileTargetOptimized = CreateNLogAppender(_logsFolder);
            var fileTargetWithConcurrentWrites = CreateNLogAppender(_logsFolder, concurrentWrites: true);
            var fileTargetWithCloseFile = CreateNLogAppender(_logsFolder, keepFileOpen: false);
            var fileTargetWithConcurrentWritesAndCloseFile = CreateNLogAppender(_logsFolder, keepFileOpen: false, concurrentWrites: true);

            config.AddTarget(fileTargetOptimized);
            config.AddTarget(fileTargetWithConcurrentWrites);
            config.AddTarget(fileTargetWithCloseFile);
            config.AddTarget(fileTargetWithConcurrentWritesAndCloseFile);
            
            var asyncOptimized = new AsyncTargetWrapper(fileTargetOptimized)
            {
                Name = nameof(fileTargetOptimized),
                OverflowAction = AsyncTargetWrapperOverflowAction.Block,
                BatchSize = 4096,
                FullBatchSizeWriteLimit = 128
            };

            var asyncWithConcurrentWrites = new AsyncTargetWrapper(fileTargetWithConcurrentWrites)
            {
                Name = nameof(fileTargetWithConcurrentWrites),
                OverflowAction = AsyncTargetWrapperOverflowAction.Block,
                BatchSize = 4096,
                FullBatchSizeWriteLimit = 128
            };

            var asyncWithCloseFile = new AsyncTargetWrapper(fileTargetWithCloseFile)
            {
                Name = nameof(fileTargetWithCloseFile),
                OverflowAction = AsyncTargetWrapperOverflowAction.Block,
                BatchSize = 4096,
                FullBatchSizeWriteLimit = 128
            };

            var asyncWithConcurrentWritesAndCloseFile = new AsyncTargetWrapper(fileTargetWithConcurrentWritesAndCloseFile)
            {
                Name = nameof(fileTargetWithConcurrentWritesAndCloseFile),
                OverflowAction = AsyncTargetWrapperOverflowAction.Block,
                BatchSize = 4096,
                FullBatchSizeWriteLimit = 128
            };

            _optimized = LogManager.GetLogger(nameof(fileTargetOptimized));
            _concurrentWrites = LogManager.GetLogger(nameof(fileTargetWithConcurrentWrites));
            _closeFile = LogManager.GetLogger(nameof(fileTargetWithCloseFile));
            _concurrentWritesAndCloseFile = LogManager.GetLogger(nameof(fileTargetWithConcurrentWritesAndCloseFile));

            config.AddRuleForOneLevel(LogLevel.Info, asyncOptimized, nameof(fileTargetOptimized));
            config.AddRuleForOneLevel(LogLevel.Info, asyncWithConcurrentWrites, nameof(fileTargetWithConcurrentWrites));
            config.AddRuleForOneLevel(LogLevel.Info, asyncWithCloseFile, nameof(fileTargetWithCloseFile));
            config.AddRuleForOneLevel(LogLevel.Info, asyncWithConcurrentWritesAndCloseFile, nameof(fileTargetWithConcurrentWritesAndCloseFile));

            LogManager.Configuration = config;
        }

        [Benchmark(Description = "KeepFileOpen=true, ConcurrentWrites=false")]
        public void Optimized() => _optimized.Info("test");

        [Benchmark(Description = "KeepFileOpen=true, ConcurrentWrites=true")]
        public void ConcurrentWrites() => _concurrentWrites.Info("test");

        [Benchmark(Description = "KeepFileOpen=false, ConcurrentWrites=false")]
        public void CloseFile() => _closeFile.Info("test");

        [Benchmark(Description = "KeepFileOpen=false, ConcurrentWrites=true")]
        public void ConcurrentWritesAndCloseFile() => _concurrentWritesAndCloseFile.Info("test");
    }
}