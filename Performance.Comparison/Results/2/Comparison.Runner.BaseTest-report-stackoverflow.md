
    BenchmarkDotNet=v0.11.5, OS=Windows 10.0.17763.503 (1809/October2018Update/Redstone5)
    Intel Core i5-6600K CPU 3.50GHz (Skylake), 1 CPU, 4 logical and 4 physical cores
      [Host] : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3416.0
      Clr    : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3416.0

    Job=Clr  Runtime=Clr  

                                                        Method | _intArgument | _stringArgument |           Mean |          Error |         StdDev |         Median | Ratio | Rank |
    ---------------------------------------------------------- |------------- |---------------- |---------------:|---------------:|---------------:|---------------:|------:|-----:|
       'KeepFileOpen=true, ConcurrentWrites=false, Async=true' |         1000 |     ltfdmhiubtc |   1,835.730 ns |     55.3980 ns |    163.3422 ns |   1,791.901 ns |  1.00 |    1 |
                                                               |              |                 |                |                |                |                |       |      |
        'KeepFileOpen=true, ConcurrentWrites=true, Async=true' |         1000 |     ltfdmhiubtc |   1,910.814 ns |     37.9116 ns |     90.1008 ns |   1,908.513 ns |  1.00 |    1 |
                                                               |              |                 |                |                |                |                |       |      |
      'KeepFileOpen=false, ConcurrentWrites=false, Async=true' |         1000 |     ltfdmhiubtc |   1,765.390 ns |     34.5893 ns |     33.9713 ns |   1,764.598 ns |  1.00 |    1 |
                                                               |              |                 |                |                |                |                |       |      |
       'KeepFileOpen=false, ConcurrentWrites=true, Async=true' |         1000 |     ltfdmhiubtc |   1,834.002 ns |     36.2599 ns |     56.4523 ns |   1,838.500 ns |  1.00 |    1 |
                                                               |              |                 |                |                |                |                |       |      |
      'KeepFileOpen=true, ConcurrentWrites=false, Async=false' |         1000 |     ltfdmhiubtc |   5,387.220 ns |     77.9523 ns |     69.1027 ns |   5,376.298 ns |  1.00 |    1 |
                                                               |              |                 |                |                |                |                |       |      |
       'KeepFileOpen=true, ConcurrentWrites=true, Async=false' |         1000 |     ltfdmhiubtc |  11,171.048 ns |     58.5253 ns |     54.7446 ns |  11,186.697 ns |  1.00 |    1 |
                                                               |              |                 |                |                |                |                |       |      |
     'KeepFileOpen=false, ConcurrentWrites=false, Async=false' |         1000 |     ltfdmhiubtc | 652,512.923 ns |  8,856.6000 ns |  8,284.4691 ns | 650,545.605 ns |  1.00 |    1 |
                                                               |              |                 |                |                |                |                |       |      |
      'KeepFileOpen=false, ConcurrentWrites=true, Async=false' |         1000 |     ltfdmhiubtc | 642,003.054 ns | 12,750.3183 ns | 31,515.6277 ns | 645,749.609 ns |  1.00 |    1 |
                                                               |              |                 |                |                |                |                |       |      |
                                       CreateLog4NetFromString |         1000 |     ltfdmhiubtc |   1,271.456 ns |      3.9287 ns |      3.4827 ns |   1,271.722 ns |  1.00 |    1 |
                                                               |              |                 |                |                |                |                |       |      |
                                          CreateNLogFromString |         1000 |     ltfdmhiubtc |     199.004 ns |      0.3101 ns |      0.2901 ns |     199.046 ns |  1.00 |    1 |
                                                               |              |                 |                |                |                |                |       |      |
                                           CreateLog4NetLogger |         1000 |     ltfdmhiubtc |  18,564.228 ns |     44.6344 ns |     41.7510 ns |  18,564.598 ns |  1.00 |    1 |
                                                               |              |                 |                |                |                |                |       |      |
                                        CreateNLogTypeOfLogger |         1000 |     ltfdmhiubtc | 140,220.404 ns |    188.8802 ns |    176.6787 ns | 140,235.303 ns |  1.00 |    1 |
                                                               |              |                 |                |                |                |                |       |      |
                                       CreateNLogDynamicLogger |         1000 |     ltfdmhiubtc | 115,329.549 ns |    243.0537 ns |    227.3526 ns | 115,361.597 ns |  1.00 |    1 |
                                                               |              |                 |                |                |                |                |       |      |
                                    FileLoggingLog4NetNoParams |         1000 |     ltfdmhiubtc |   7,076.251 ns |     41.5518 ns |     38.8676 ns |   7,075.394 ns |  1.00 |    1 |
                                                               |              |                 |                |                |                |                |       |      |
                        FileLoggingLog4NetSingleReferenceParam |         1000 |     ltfdmhiubtc |   7,464.427 ns |     36.0445 ns |     33.7161 ns |   7,470.789 ns |  1.00 |    1 |
                                                               |              |                 |                |                |                |                |       |      |
                            FileLoggingLog4NetSingleValueParam |         1000 |     ltfdmhiubtc |   7,684.635 ns |     49.2505 ns |     46.0690 ns |   7,693.219 ns |  1.00 |    1 |
                                                               |              |                 |                |                |                |                |       |      |
                     FileLoggingLog4NetMultipleReferencesParam |         1000 |     ltfdmhiubtc |   8,207.387 ns |     79.5855 ns |     74.4443 ns |   8,220.897 ns |  1.00 |    1 |
                                                               |              |                 |                |                |                |                |       |      |
                         FileLoggingLog4NetMultipleValuesParam |         1000 |     ltfdmhiubtc |   8,477.657 ns |     63.4105 ns |     59.3143 ns |   8,472.385 ns |  1.00 |    1 |
                                                               |              |                 |                |                |                |                |       |      |
                                    FileLoggingNLogNetNoParams |         1000 |     ltfdmhiubtc |   5,438.306 ns |     42.0170 ns |     37.2470 ns |   5,427.805 ns |  1.00 |    1 |
                                                               |              |                 |                |                |                |                |       |      |
                        FileLoggingNLogNetSingleReferenceParam |         1000 |     ltfdmhiubtc |   5,734.572 ns |     46.0770 ns |     40.8461 ns |   5,729.974 ns |  1.00 |    1 |
                                                               |              |                 |                |                |                |                |       |      |
                            FileLoggingNLogNetSingleValueParam |         1000 |     ltfdmhiubtc |   5,834.548 ns |     40.4125 ns |     35.8246 ns |   5,838.905 ns |  1.00 |    1 |
                                                               |              |                 |                |                |                |                |       |      |
                     FileLoggingNLogNetMultipleReferencesParam |         1000 |     ltfdmhiubtc |   6,445.663 ns |     57.5870 ns |     53.8669 ns |   6,440.509 ns |  1.00 |    1 |
                                                               |              |                 |                |                |                |                |       |      |
                         FileLoggingNLogNetMultipleValuesParam |         1000 |     ltfdmhiubtc |   6,784.489 ns |     43.9255 ns |     38.9388 ns |   6,782.898 ns |  1.00 |    1 |
                                                               |              |                 |                |                |                |                |       |      |
                                           NoOpLog4NetNoParams |         1000 |     ltfdmhiubtc |      11.063 ns |      0.0141 ns |      0.0125 ns |      11.065 ns |  1.00 |    1 |
                                                               |              |                 |                |                |                |                |       |      |
                               NoOpLog4NetSingleReferenceParam |         1000 |     ltfdmhiubtc |       9.206 ns |      0.0321 ns |      0.0300 ns |       9.203 ns |  1.00 |    1 |
                                                               |              |                 |                |                |                |                |       |      |
                                   NoOpLog4NetSingleValueParam |         1000 |     ltfdmhiubtc |      11.423 ns |      0.0147 ns |      0.0131 ns |      11.421 ns |  1.00 |    1 |
                                                               |              |                 |                |                |                |                |       |      |
                            NoOpLog4NetMultipleReferencesParam |         1000 |     ltfdmhiubtc |      44.472 ns |      0.0474 ns |      0.0396 ns |      44.475 ns |  1.00 |    1 |
                                                               |              |                 |                |                |                |                |       |      |
                                NoOpLog4NetMultipleValuesParam |         1000 |     ltfdmhiubtc |      58.138 ns |      0.1598 ns |      0.1416 ns |      58.139 ns |  1.00 |    1 |
                                                               |              |                 |                |                |                |                |       |      |
                                           NoOpNLogNetNoParams |         1000 |     ltfdmhiubtc |       1.045 ns |      0.0037 ns |      0.0033 ns |       1.045 ns |  1.00 |    1 |
                                                               |              |                 |                |                |                |                |       |      |
                               NoOpNLogNetSingleReferenceParam |         1000 |     ltfdmhiubtc |       1.994 ns |      0.0033 ns |      0.0028 ns |       1.994 ns |  1.00 |    1 |
                                                               |              |                 |                |                |                |                |       |      |
                                   NoOpNLogNetSingleValueParam |         1000 |     ltfdmhiubtc |       2.025 ns |      0.0044 ns |      0.0042 ns |       2.024 ns |  1.00 |    1 |
                                                               |              |                 |                |                |                |                |       |      |
                            NoOpNLogNetMultipleReferencesParam |         1000 |     ltfdmhiubtc |      34.800 ns |      0.0374 ns |      0.0312 ns |      34.798 ns |  1.00 |    1 |
                                                               |              |                 |                |                |                |                |       |      |
                                NoOpNLogNetMultipleValuesParam |         1000 |     ltfdmhiubtc |      47.509 ns |      0.1199 ns |      0.1063 ns |      47.511 ns |  1.00 |    1 |
