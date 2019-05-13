using System;
using System.Diagnostics;
using System.IO;
using BenchmarkDotNet.Attributes;
using NLog;
using NLog.Config;
using Logger = NLog.Logger;

namespace Comparison.Runner
{
    public class ConcurrentFileLogging : BaseTest
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

            _optimized = LogManager.GetLogger(nameof(fileTargetOptimized));
            _concurrentWrites = LogManager.GetLogger(nameof(fileTargetWithConcurrentWrites));
            _closeFile = LogManager.GetLogger(nameof(fileTargetWithCloseFile));
            _concurrentWritesAndCloseFile = LogManager.GetLogger(nameof(fileTargetWithConcurrentWritesAndCloseFile));

            config.AddRuleForOneLevel(LogLevel.Info, fileTargetOptimized, nameof(fileTargetOptimized));
            config.AddRuleForOneLevel(LogLevel.Info, fileTargetWithConcurrentWrites, nameof(fileTargetWithConcurrentWrites));
            config.AddRuleForOneLevel(LogLevel.Info, fileTargetWithCloseFile, nameof(fileTargetWithCloseFile));
            config.AddRuleForOneLevel(LogLevel.Info, fileTargetWithConcurrentWritesAndCloseFile, nameof(fileTargetWithConcurrentWritesAndCloseFile));

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