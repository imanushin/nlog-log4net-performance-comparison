using System;
using System.IO;
using System.Linq;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;

namespace Comparison.Runner
{
    internal static class StartClass
    {
        private static void Main()
        {
            BenchmarkRunner.Run<NoOpLogging>();
        }
    }
}
