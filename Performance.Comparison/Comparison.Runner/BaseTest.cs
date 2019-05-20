using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Exporters.Csv;
using log4net;
using log4net.Appender;
using log4net.Config;
using log4net.Core;
using log4net.Layout;
using log4net.Repository.Hierarchy;
using NLog;
using NLog.Config;
using NLog.Targets;
using NLog.Targets.Wrappers;
using Logger = NLog.Logger;
using LogManager = log4net.LogManager;

namespace Comparison.Runner
{
    [ClrJob(baseline: true)]
    [//RPlotExporter,
     PlainExporter,
     CsvMeasurementsExporter,
     CsvExporter(CsvSeparator.Comma),
     MarkdownExporterAttribute.GitHub,
     MarkdownExporterAttribute.StackOverflow]
    [RankColumn]
    public partial class BaseTest
    {
        private const string DefaultLoggerName = "DefaultLogger";

        private static int _logIndex;

        private static readonly List<DirectoryInfo> Folders = new List<DirectoryInfo>();

        private Logger _nLogSyncFile;

        private Logger _optimizedSync;
        private Logger _concurrentWritesSync;
        private Logger _closeFileSync;
        private Logger _concurrentWritesAndCloseFileSync;
        private Logger _optimizedAsync;
        private Logger _concurrentWritesAsync;
        private Logger _closeFileAsync;
        private Logger _concurrentWritesAndCloseFileAsync;

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

            /****  NLog ****/
            
            // from https://github.com/nlog/NLog/wiki/Configuration-API
            var config = new LoggingConfiguration();

            var fileTarget = CreateNLogAppender(_logsFolder);
            config.AddTarget(fileTarget);

            config.AddRuleForOneLevel(LogLevel.Info, fileTarget, DefaultLoggerName);

            _nLogSyncFile = NLog.LogManager.GetLogger(DefaultLoggerName);

            var fileTargetOptimizedSync = CreateNLogAppender(_logsFolder);
            var fileTargetWithConcurrentWritesSync = CreateNLogAppender(_logsFolder, concurrentWrites: true);
            var fileTargetWithCloseFileSync = CreateNLogAppender(_logsFolder, keepFileOpen: false);
            var fileTargetWithConcurrentWritesAndCloseFileSync = CreateNLogAppender(_logsFolder, keepFileOpen: false, concurrentWrites: true);
            var fileTargetOptimizedAsync = CreateNLogAppender(_logsFolder);
            var fileTargetWithConcurrentWritesAsync = CreateNLogAppender(_logsFolder, concurrentWrites: true);
            var fileTargetWithCloseFileAsync = CreateNLogAppender(_logsFolder, keepFileOpen: false);
            var fileTargetWithConcurrentWritesAndCloseFileAsync = CreateNLogAppender(_logsFolder, keepFileOpen: false, concurrentWrites: true);

            config.AddTarget(fileTargetOptimizedSync);
            config.AddTarget(fileTargetWithConcurrentWritesSync);
            config.AddTarget(fileTargetWithCloseFileSync);
            config.AddTarget(fileTargetWithConcurrentWritesAndCloseFileSync);
            config.AddTarget(fileTargetOptimizedAsync);
            config.AddTarget(fileTargetWithConcurrentWritesAsync);
            config.AddTarget(fileTargetWithCloseFileAsync);
            config.AddTarget(fileTargetWithConcurrentWritesAndCloseFileAsync);

            var asyncOptimized = new AsyncTargetWrapper(fileTargetOptimizedAsync)
            {
                Name = nameof(fileTargetOptimizedAsync),
                OverflowAction = AsyncTargetWrapperOverflowAction.Block,
                BatchSize = 4096,
                FullBatchSizeWriteLimit = 128
            };

            var asyncWithConcurrentWrites = new AsyncTargetWrapper(fileTargetWithConcurrentWritesAsync)
            {
                Name = nameof(fileTargetWithConcurrentWritesAsync),
                OverflowAction = AsyncTargetWrapperOverflowAction.Block,
                BatchSize = 4096,
                FullBatchSizeWriteLimit = 128
            };

            var asyncWithCloseFile = new AsyncTargetWrapper(fileTargetWithCloseFileAsync)
            {
                Name = nameof(fileTargetWithCloseFileAsync),
                OverflowAction = AsyncTargetWrapperOverflowAction.Block,
                BatchSize = 4096,
                FullBatchSizeWriteLimit = 128
            };

            var asyncWithConcurrentWritesAndCloseFile = new AsyncTargetWrapper(fileTargetWithConcurrentWritesAndCloseFileAsync)
            {
                Name = nameof(fileTargetWithConcurrentWritesAndCloseFileAsync),
                OverflowAction = AsyncTargetWrapperOverflowAction.Block,
                BatchSize = 4096,
                FullBatchSizeWriteLimit = 128
            };

            _optimizedSync = NLog.LogManager.GetLogger(nameof(fileTargetOptimizedSync));
            _concurrentWritesSync = NLog.LogManager.GetLogger(nameof(fileTargetWithConcurrentWritesSync));
            _closeFileSync = NLog.LogManager.GetLogger(nameof(fileTargetWithCloseFileSync));
            _concurrentWritesAndCloseFileSync = NLog.LogManager.GetLogger(nameof(fileTargetWithConcurrentWritesAndCloseFileSync));
            _optimizedAsync = NLog.LogManager.GetLogger(nameof(fileTargetOptimizedAsync));
            _concurrentWritesAsync = NLog.LogManager.GetLogger(nameof(fileTargetWithConcurrentWritesAsync));
            _closeFileAsync = NLog.LogManager.GetLogger(nameof(fileTargetWithCloseFileAsync));
            _concurrentWritesAndCloseFileAsync = NLog.LogManager.GetLogger(nameof(fileTargetWithConcurrentWritesAndCloseFileAsync));

            config.AddRuleForOneLevel(LogLevel.Info, fileTargetOptimizedSync, nameof(fileTargetOptimizedSync));
            config.AddRuleForOneLevel(LogLevel.Info, fileTargetWithConcurrentWritesSync, nameof(fileTargetWithConcurrentWritesSync));
            config.AddRuleForOneLevel(LogLevel.Info, fileTargetWithCloseFileSync, nameof(fileTargetWithCloseFileSync));
            config.AddRuleForOneLevel(LogLevel.Info, fileTargetWithConcurrentWritesAndCloseFileSync, nameof(fileTargetWithConcurrentWritesAndCloseFileSync));
            config.AddRuleForOneLevel(LogLevel.Info, asyncOptimized, nameof(fileTargetOptimizedAsync));
            config.AddRuleForOneLevel(LogLevel.Info, asyncWithConcurrentWrites, nameof(fileTargetWithConcurrentWritesAsync));
            config.AddRuleForOneLevel(LogLevel.Info, asyncWithCloseFile, nameof(fileTargetWithCloseFileAsync));
            config.AddRuleForOneLevel(LogLevel.Info, asyncWithConcurrentWritesAndCloseFile, nameof(fileTargetWithConcurrentWritesAndCloseFileAsync));

            NLog.LogManager.Configuration = config;
        }

        private static string CreateLogFolder()
        {
            var logsFolder = $"logs_{DateTime.UtcNow.Ticks}_{Process.GetCurrentProcess().Id}";

            if (Directory.Exists(logsFolder))
            {
                Directory.Delete(logsFolder, true);
            }

            Directory.CreateDirectory(logsFolder);

            var info = new DirectoryInfo(logsFolder);

            Folders.Add(info);

            return new DirectoryInfo(logsFolder).FullName;
        }

        [GlobalCleanup]
        public void Cleanup()
        {
            LogManager.Shutdown();
            NLog.LogManager.Configuration = null;

            foreach (var directoryInfo in Folders)
            {
                directoryInfo.Delete(true);
            }

            Folders.Clear();
        }

        private static FileTarget CreateNLogAppender(
            string logsFolder,
            bool concurrentWrites = false,
            bool keepFileOpen = true)
        {
            return new FileTarget($"target_{_logIndex++}")
            {
                FileName = $"{logsFolder}/nlog.txt",
                ArchiveAboveSize = 128 * 1000 * 1000,
                MaxArchiveFiles = 16,
                AutoFlush = true,
                ConcurrentWrites = concurrentWrites,
                KeepFileOpen = keepFileOpen,
                Layout = "${longdate} ${threadid} ${logger} ${level} ${message}  ${exception}"
            };
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