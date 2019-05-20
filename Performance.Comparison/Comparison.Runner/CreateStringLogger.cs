using System.Threading;
using BenchmarkDotNet.Attributes;
using LogManager = log4net.LogManager;

namespace Comparison.Runner
{
    partial class BaseTest
    {
        private static int _nLogStringLogIndex;
        private static int _log4NetStringLogIndex;

        [Benchmark]
        public object CreateLog4NetFromString()
        {
            return LogManager.GetLogger("my-logger_" + (Interlocked.Increment(ref _log4NetStringLogIndex) % 1000));
        }

        [Benchmark]
        public object CreateNLogFromString()
        {
            return NLog.LogManager.GetLogger("my-logger_" + (Interlocked.Increment(ref _nLogStringLogIndex) % 1000));
        }
    }
}