using BenchmarkDotNet.Attributes;
using log4net;
using NLog;

namespace Comparison.Runner
{
    public abstract class BaseLoggingBenchmarks
    {
        protected ILog _log4Net;
        protected Logger _nlog;

        [Params(1000)]
        public int _intArgument;

        [Params("32197463298746")]
        public string _stringArgument;
        
        [Benchmark]
        public void Log4NetNoParams() => _log4Net.DebugFormat("test");

        [Benchmark]
        public void Log4NetSingleReferenceParam() => _log4Net.DebugFormat("test {0}", _stringArgument);

        [Benchmark]
        public void Log4NetSingleValueParam() => _log4Net.DebugFormat("test {0}", _intArgument);

        [Benchmark]
        public void Log4NetMultipleReferencesParam() => _log4Net.DebugFormat(
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
        public void Log4NetMultipleValuesParam() => _log4Net.DebugFormat(
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
        public void NLogNetNoParams() => _nlog.Debug("test");

        [Benchmark]
        public void NLogNetSingleReferenceParam() => _nlog.Debug("test {0}", _stringArgument);

        [Benchmark]
        public void NLogNetSingleValueParam() => _nlog.Debug("test {0}", _intArgument);

        [Benchmark]
        public void NLogNetMultipleReferencesParam() => _nlog.Debug(
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
        public void NLogNetMultipleValuesParam() => _nlog.Debug(
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