using BenchmarkDotNet.Attributes;

namespace Comparison.Runner
{
    partial class BaseTest
    {
        [Benchmark]
        public void NoOpLog4NetNoParams() => _log4Net.Debug("test");

        [Benchmark]
        public void NoOpLog4NetSingleReferenceParam() => _log4Net.DebugFormat("test {0}", _stringArgument);

        [Benchmark]
        public void NoOpLog4NetSingleValueParam() => _log4Net.DebugFormat("test {0}", _intArgument);

        [Benchmark]
        public void NoOpLog4NetMultipleReferencesParam() => _log4Net.DebugFormat(
            "test {0} {1} {2} {3} {4} {5} {6} {7} {8}",
            _stringArgument,
            _stringArgument,
            _stringArgument,
            _stringArgument,
            _stringArgument,
            _stringArgument,
            _stringArgument,
            _stringArgument,
            _stringArgument);

        [Benchmark]
        public void NoOpLog4NetMultipleValuesParam() => _log4Net.DebugFormat(
            "test {0} {1} {2} {3} {4} {5} {6} {7} {8}",
            _intArgument,
            _intArgument,
            _intArgument,
            _intArgument,
            _intArgument,
            _intArgument,
            _intArgument,
            _intArgument,
            _intArgument);

        [Benchmark]
        public void NoOpNLogNetNoParams() => _nLogSyncFile.Debug("test");

        [Benchmark]
        public void NoOpNLogNetSingleReferenceParam() => _nLogSyncFile.Debug("test {0}", _stringArgument);

        [Benchmark]
        public void NoOpNLogNetSingleValueParam() => _nLogSyncFile.Debug("test {0}", _intArgument);

        [Benchmark]
        public void NoOpNLogNetMultipleReferencesParam() => _nLogSyncFile.Debug(
            "test {0} {1} {2} {3} {4} {5} {6} {7} {8}",
            _stringArgument,
            _stringArgument,
            _stringArgument,
            _stringArgument,
            _stringArgument,
            _stringArgument,
            _stringArgument,
            _stringArgument,
            _stringArgument);

        [Benchmark]
        public void NoOpNLogNetMultipleValuesParam() => _nLogSyncFile.Debug(
            "test {0} {1} {2} {3} {4} {5} {6} {7} {8}",
            _intArgument,
            _intArgument,
            _intArgument,
            _intArgument,
            _intArgument,
            _intArgument,
            _intArgument,
            _intArgument,
            _intArgument);
    }
}