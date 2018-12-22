using BenchmarkDotNet.Attributes;
using log4net;
using NLog;
using LogManager = log4net.LogManager;

namespace Comparison.Runner
{
    [ClrJob(baseline: true)]
    [RPlotExporter, RankColumn]
    internal sealed class EmptyLoggers
    {
        private ILog _log4Net;
        private Logger _nlog;

        [Params(1000, 10000)]
        public int _inputArgument;

        [GlobalSetup]
        public void Setup()
        {
            _log4Net = LogManager.GetLogger(typeof(EmptyLoggers));
            _nlog = NLog.LogManager.GetCurrentClassLogger();
        }

        [Benchmark]
        public void Log4NetEmpty() => _log4Net.DebugFormat("test {0}", _inputArgument);

        [Benchmark]
        public void NLogEmpty() => _nlog.Debug("test {0}", _inputArgument);
    }
}