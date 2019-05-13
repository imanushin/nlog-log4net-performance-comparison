using BenchmarkDotNet.Running;
using NLog.Targets;

namespace Comparison.Runner
{
    internal static class StartClass
    {

        private static void Main()
        {
            if (true)
            {
                BenchmarkRunner.Run(typeof(StartClass).Assembly);
            }
            else
            {
                BenchmarkRunner.Run<ConcurrentAsyncFileLogging>();
            }
        }
    }
}