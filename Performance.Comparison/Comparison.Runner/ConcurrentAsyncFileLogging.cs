using BenchmarkDotNet.Attributes;

namespace Comparison.Runner
{
    partial class BaseTest
    {
        [Benchmark(Description = "KeepFileOpen=true, ConcurrentWrites=false, Async=true")]
        public void AsyncOptimized() => _optimizedAsync.Info("test");

        [Benchmark(Description = "KeepFileOpen=true, ConcurrentWrites=true, Async=true")]
        public void AsyncConcurrentWrites() => _concurrentWritesAsync.Info("test");

        [Benchmark(Description = "KeepFileOpen=false, ConcurrentWrites=false, Async=true")]
        public void AsyncCloseFile() => _closeFileAsync.Info("test");

        [Benchmark(Description = "KeepFileOpen=false, ConcurrentWrites=true, Async=true")]
        public void AsyncConcurrentWritesAndCloseFile() => _concurrentWritesAndCloseFileAsync.Info("test");
    }
}