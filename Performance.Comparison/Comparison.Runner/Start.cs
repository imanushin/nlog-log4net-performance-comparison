using System.Collections.Concurrent;
using System.IO;
using BenchmarkDotNet.Running;
using log4net;

namespace Comparison.Runner
{
    internal static class StartClass
    {
        internal static readonly ConcurrentBag<DirectoryInfo> Folders = new ConcurrentBag<DirectoryInfo>();

        private static void Main()
        {
            //BenchmarkRunner.Run<NoOpLogging>();
           BenchmarkRunner.Run<AsyncFileLogging>();
           //BenchmarkRunner.Run<FileLogging>();

            LogManager.Shutdown();
            NLog.LogManager.Configuration = null;

            foreach (var directoryInfo in Folders)
            {
                directoryInfo.Delete(true);
            }
        }
    }
}
