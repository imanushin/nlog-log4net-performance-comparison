using BenchmarkDotNet.Attributes;

namespace Comparison.Runner
{
    partial class BaseTest
    {
        [Benchmark(Description = "KeepFileOpen=true, ConcurrentWrites=false")]
        public void Optimized() => _optimizedAsync.Info("test");

        [Benchmark(Description = "KeepFileOpen=true, ConcurrentWrites=true")]
        public void ConcurrentWrites() => _concurrentWritesAsync.Info("test");

        [Benchmark(Description = "KeepFileOpen=false, ConcurrentWrites=false")]
        public void CloseFile() => _closeFileAsync.Info("test");

        [Benchmark(Description = "KeepFileOpen=false, ConcurrentWrites=true")]
        public void ConcurrentWritesAndCloseFile() => _concurrentWritesAndCloseFileAsync.Info("test");
    }
}