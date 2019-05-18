using BenchmarkDotNet.Attributes;

namespace Comparison.Runner
{
    partial class BaseTest
    {
        [Benchmark(Description = "KeepFileOpen=true, ConcurrentWrites=false")]
        public void ConcurrentWriteOptimized() => _optimizedSync.Info("test");

        [Benchmark(Description = "KeepFileOpen=true, ConcurrentWrites=true")]
        public void ConcurrentWriteAllowMultiple() => _concurrentWritesSync.Info("test");

        [Benchmark(Description = "KeepFileOpen=false, ConcurrentWrites=false")]
        public void ConcurrentWriteCloseFile() => _closeFileSync.Info("test");

        [Benchmark(Description = "KeepFileOpen=false, ConcurrentWrites=true")]
        public void ConcurrentWriteAllowMultipleAndCloseFile() => _concurrentWritesAndCloseFileSync.Info("test");
    }
}