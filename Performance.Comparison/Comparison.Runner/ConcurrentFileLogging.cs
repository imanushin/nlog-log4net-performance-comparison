using BenchmarkDotNet.Attributes;

namespace Comparison.Runner
{
    partial class BaseTest
    {
        [Benchmark(Description = "KeepFileOpen=true, ConcurrentWrites=false, Async=false")]
        public void ConcurrentWriteOptimized() => _optimizedSync.Info("test");

        [Benchmark(Description = "KeepFileOpen=true, ConcurrentWrites=true, Async=false")]
        public void ConcurrentWriteAllowMultiple() => _concurrentWritesSync.Info("test");

        [Benchmark(Description = "KeepFileOpen=false, ConcurrentWrites=false, Async=false")]
        public void ConcurrentWriteCloseFile() => _closeFileSync.Info("test");

        [Benchmark(Description = "KeepFileOpen=false, ConcurrentWrites=true, Async=false")]
        public void ConcurrentWriteAllowMultipleAndCloseFile() => _concurrentWritesAndCloseFileSync.Info("test");
    }
}