using BenchmarkDotNet.Attributes;
using LogManager = log4net.LogManager;

namespace Comparison.Runner
{
    partial class BaseTest
    {
        [Benchmark]
        public object CreateLog4NetLogger()
        {
            return new []
            {
                LogManager.GetLogger(typeof(BaseTest)),
                LogManager.GetLogger(typeof(BaseTest)),
                LogManager.GetLogger(typeof(BaseTest)),
                LogManager.GetLogger(typeof(BaseTest)),

                LogManager.GetLogger(typeof(BaseTest)),
                LogManager.GetLogger(typeof(BaseTest)),
                LogManager.GetLogger(typeof(BaseTest)),
                LogManager.GetLogger(typeof(BaseTest)),

                LogManager.GetLogger(typeof(BaseTest)),
                LogManager.GetLogger(typeof(BaseTest)),
                LogManager.GetLogger(typeof(BaseTest)),
                LogManager.GetLogger(typeof(BaseTest)),

                LogManager.GetLogger(typeof(BaseTest)),
                LogManager.GetLogger(typeof(BaseTest)),
                LogManager.GetLogger(typeof(BaseTest)),
                LogManager.GetLogger(typeof(BaseTest)),
            };
        }

        [Benchmark]
        public object CreateNLogTypeOfLogger()
        {
            return new[]
            {
                NLog.LogManager.GetCurrentClassLogger(typeof(BaseTest)),
                NLog.LogManager.GetCurrentClassLogger(typeof(BaseTest)),
                NLog.LogManager.GetCurrentClassLogger(typeof(BaseTest)),
                NLog.LogManager.GetCurrentClassLogger(typeof(BaseTest)),

                NLog.LogManager.GetCurrentClassLogger(typeof(BaseTest)),
                NLog.LogManager.GetCurrentClassLogger(typeof(BaseTest)),
                NLog.LogManager.GetCurrentClassLogger(typeof(BaseTest)),
                NLog.LogManager.GetCurrentClassLogger(typeof(BaseTest)),

                NLog.LogManager.GetCurrentClassLogger(typeof(BaseTest)),
                NLog.LogManager.GetCurrentClassLogger(typeof(BaseTest)),
                NLog.LogManager.GetCurrentClassLogger(typeof(BaseTest)),
                NLog.LogManager.GetCurrentClassLogger(typeof(BaseTest)),

                NLog.LogManager.GetCurrentClassLogger(typeof(BaseTest)),
                NLog.LogManager.GetCurrentClassLogger(typeof(BaseTest)),
                NLog.LogManager.GetCurrentClassLogger(typeof(BaseTest)),
                NLog.LogManager.GetCurrentClassLogger(typeof(BaseTest)),
            };
        }

        [Benchmark]
        public object CreateNLogDynamicLogger()
        {
            return new[]
            {
                NLog.LogManager.GetCurrentClassLogger(),
                NLog.LogManager.GetCurrentClassLogger(),
                NLog.LogManager.GetCurrentClassLogger(),
                NLog.LogManager.GetCurrentClassLogger(),

                NLog.LogManager.GetCurrentClassLogger(),
                NLog.LogManager.GetCurrentClassLogger(),
                NLog.LogManager.GetCurrentClassLogger(),
                NLog.LogManager.GetCurrentClassLogger(),

                NLog.LogManager.GetCurrentClassLogger(),
                NLog.LogManager.GetCurrentClassLogger(),
                NLog.LogManager.GetCurrentClassLogger(),
                NLog.LogManager.GetCurrentClassLogger(),

                NLog.LogManager.GetCurrentClassLogger(),
                NLog.LogManager.GetCurrentClassLogger(),
                NLog.LogManager.GetCurrentClassLogger(),
                NLog.LogManager.GetCurrentClassLogger(),
            };
        }
    }
}