using BenchmarkDotNet.Attributes;

namespace Comparison.Runner
{
    partial class BaseTest
    {
        [Benchmark]
        public void FileLoggingLog4NetNoParams() => _log4Net.InfoFormat("test");

        [Benchmark]
        public void FileLoggingLog4NetSingleReferenceParam() => _log4Net.InfoFormat("test {0}", _stringArgument);

        [Benchmark]
        public void FileLoggingLog4NetSingleValueParam() => _log4Net.InfoFormat("test {0}", _intArgument);

        [Benchmark]
        public void FileLoggingLog4NetMultipleReferencesParam() => _log4Net.InfoFormat(
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
        public void FileLoggingLog4NetMultipleValuesParam() => _log4Net.InfoFormat(
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
        public void FileLoggingNLogNetNoParams() => _nLogSyncFile.Info("test");

        [Benchmark]
        public void FileLoggingNLogNetSingleReferenceParam() => _nLogSyncFile.Info("test {0}", _stringArgument);

        [Benchmark]
        public void FileLoggingNLogNetSingleValueParam() => _nLogSyncFile.Info("test {0}", _intArgument);

        [Benchmark]
        public void FileLoggingNLogNetMultipleReferencesParam() => _nLogSyncFile.Info(
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
        public void FileLoggingNLogNetMultipleValuesParam() => _nLogSyncFile.Info(
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