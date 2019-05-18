using System.Threading;
using BenchmarkDotNet.Attributes;
using LogManager = log4net.LogManager;

namespace Comparison.Runner
{
    partial class BaseTest
    {
        private static int _stringLogIndex;

        [Benchmark]
        public object CreateLog4NetFromString()
        {
            return LogManager.GetLogger("my-logger_" + Interlocked.Increment(ref _stringLogIndex));
        }

        [Benchmark]
        public object CreateNLogFromString()
        {
            return NLog.LogManager.GetLogger("my-logger_" + Interlocked.Increment(ref _stringLogIndex));
        }
    }
}