using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Exporters.Csv;
using log4net;
using NLog.Targets;

namespace Comparison.Runner
{
    [ClrJob(baseline: true)]
    [/*RPlotExporter,*/
     PlainExporter,
     CsvMeasurementsExporter,
     CsvExporter(CsvSeparator.Comma),
     MarkdownExporterAttribute.GitHub,
     MarkdownExporterAttribute.StackOverflow]
    [RankColumn]
    public abstract class BaseTest
    {
        private static int _logIndex;

        private static readonly List<DirectoryInfo> Folders = new List<DirectoryInfo>();

        protected static string CreateLogFolder()
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

        protected static FileTarget CreateNLogAppender(
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
    }
}