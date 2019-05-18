using BenchmarkDotNet.Running;

namespace Comparison.Runner
{
    internal static class StartClass
    {
        private static void Main()
        {
            BenchmarkRunner.Run<BaseTest>();
        }
    }
}