
    BenchmarkDotNet=v0.11.5, OS=Windows 10.0.17763.557 (1809/October2018Update/Redstone5)
    Intel Core i5-6600K CPU 3.50GHz (Skylake), 1 CPU, 4 logical and 4 physical cores
      [Host] : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3416.0
      Clr    : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3416.0

    Job=Clr  Runtime=Clr  

                                                        Method | _intArgument | _stringArgument |           Mean |          Error |         StdDev | Ratio | Rank |
    ---------------------------------------------------------- |------------- |---------------- |---------------:|---------------:|---------------:|------:|-----:|
       'KeepFileOpen=true, ConcurrentWrites=false, Async=true' |         1000 |     ltfdmhiubtc |   1,144.677 ns |     26.3805 ns |     77.7835 ns |  1.00 |    1 |
                                                               |              |                 |                |                |                |       |      |
        'KeepFileOpen=true, ConcurrentWrites=true, Async=true' |         1000 |     ltfdmhiubtc |   1,106.691 ns |     31.4041 ns |     87.5421 ns |  1.00 |    1 |
                                                               |              |                 |                |                |                |       |      |
      'KeepFileOpen=false, ConcurrentWrites=false, Async=true' |         1000 |     ltfdmhiubtc |   4,804.426 ns |    110.3406 ns |    103.2126 ns |  1.00 |    1 |
                                                               |              |                 |                |                |                |       |      |
       'KeepFileOpen=false, ConcurrentWrites=true, Async=true' |         1000 |     ltfdmhiubtc |   5,303.602 ns |    104.3022 ns |    102.4387 ns |  1.00 |    1 |
                                                               |              |                 |                |                |                |       |      |
      'KeepFileOpen=true, ConcurrentWrites=false, Async=false' |         1000 |     ltfdmhiubtc |   5,642.301 ns |     73.2291 ns |     68.4986 ns |  1.00 |    1 |
                                                               |              |                 |                |                |                |       |      |
       'KeepFileOpen=true, ConcurrentWrites=true, Async=false' |         1000 |     ltfdmhiubtc |  11,834.892 ns |     82.7578 ns |     77.4117 ns |  1.00 |    1 |
                                                               |              |                 |                |                |                |       |      |
     'KeepFileOpen=false, ConcurrentWrites=false, Async=false' |         1000 |     ltfdmhiubtc | 731,250.539 ns | 14,612.0117 ns | 27,444.8998 ns |  1.00 |    1 |
                                                               |              |                 |                |                |                |       |      |
      'KeepFileOpen=false, ConcurrentWrites=true, Async=false' |         1000 |     ltfdmhiubtc | 730,271.927 ns | 11,330.0172 ns | 10,598.1051 ns |  1.00 |    1 |
                                                               |              |                 |                |                |                |       |      |
                                       CreateLog4NetFromString |         1000 |     ltfdmhiubtc |   1,470.662 ns |     19.9492 ns |     18.6605 ns |  1.00 |    1 |
                                                               |              |                 |                |                |                |       |      |
                                          CreateNLogFromString |         1000 |     ltfdmhiubtc |     228.774 ns |      2.1315 ns |      1.8895 ns |  1.00 |    1 |
                                                               |              |                 |                |                |                |       |      |
                                           CreateLog4NetLogger |         1000 |     ltfdmhiubtc |  21,046.294 ns |    284.1171 ns |    265.7633 ns |  1.00 |    1 |
                                                               |              |                 |                |                |                |       |      |
                                        CreateNLogTypeOfLogger |         1000 |     ltfdmhiubtc | 164,487.931 ns |  3,240.4372 ns |  3,031.1070 ns |  1.00 |    1 |
                                                               |              |                 |                |                |                |       |      |
                                       CreateNLogDynamicLogger |         1000 |     ltfdmhiubtc | 134,459.092 ns |  1,882.8663 ns |  1,761.2344 ns |  1.00 |    1 |
                                                               |              |                 |                |                |                |       |      |
                                    FileLoggingLog4NetNoParams |         1000 |     ltfdmhiubtc |   8,251.032 ns |    109.3075 ns |    102.2463 ns |  1.00 |    1 |
                                                               |              |                 |                |                |                |       |      |
                        FileLoggingLog4NetSingleReferenceParam |         1000 |     ltfdmhiubtc |   8,260.452 ns |    145.9028 ns |    136.4776 ns |  1.00 |    1 |
                                                               |              |                 |                |                |                |       |      |
                            FileLoggingLog4NetSingleValueParam |         1000 |     ltfdmhiubtc |   8,378.693 ns |    121.3003 ns |    113.4643 ns |  1.00 |    1 |
                                                               |              |                 |                |                |                |       |      |
                     FileLoggingLog4NetMultipleReferencesParam |         1000 |     ltfdmhiubtc |   9,133.136 ns |     89.7420 ns |     79.5539 ns |  1.00 |    1 |
                                                               |              |                 |                |                |                |       |      |
                         FileLoggingLog4NetMultipleValuesParam |         1000 |     ltfdmhiubtc |   9,393.989 ns |    166.0347 ns |    155.3089 ns |  1.00 |    1 |
                                                               |              |                 |                |                |                |       |      |
                                    FileLoggingNLogNetNoParams |         1000 |     ltfdmhiubtc |   6,061.837 ns |     69.5666 ns |     65.0726 ns |  1.00 |    1 |
                                                               |              |                 |                |                |                |       |      |
                        FileLoggingNLogNetSingleReferenceParam |         1000 |     ltfdmhiubtc |   6,458.201 ns |     94.5617 ns |     88.4530 ns |  1.00 |    1 |
                                                               |              |                 |                |                |                |       |      |
                            FileLoggingNLogNetSingleValueParam |         1000 |     ltfdmhiubtc |   6,460.859 ns |     95.5435 ns |     84.6969 ns |  1.00 |    1 |
                                                               |              |                 |                |                |                |       |      |
                     FileLoggingNLogNetMultipleReferencesParam |         1000 |     ltfdmhiubtc |   7,236.886 ns |     89.7334 ns |     83.9367 ns |  1.00 |    1 |
                                                               |              |                 |                |                |                |       |      |
                         FileLoggingNLogNetMultipleValuesParam |         1000 |     ltfdmhiubtc |   7,524.876 ns |     82.8979 ns |     77.5427 ns |  1.00 |    1 |
                                                               |              |                 |                |                |                |       |      |
                                           NoOpLog4NetNoParams |         1000 |     ltfdmhiubtc |      12.684 ns |      0.0795 ns |      0.0743 ns |  1.00 |    1 |
                                                               |              |                 |                |                |                |       |      |
                               NoOpLog4NetSingleReferenceParam |         1000 |     ltfdmhiubtc |      10.506 ns |      0.0571 ns |      0.0506 ns |  1.00 |    1 |
                                                               |              |                 |                |                |                |       |      |
                                   NoOpLog4NetSingleValueParam |         1000 |     ltfdmhiubtc |      12.608 ns |      0.1012 ns |      0.0946 ns |  1.00 |    1 |
                                                               |              |                 |                |                |                |       |      |
                            NoOpLog4NetMultipleReferencesParam |         1000 |     ltfdmhiubtc |      48.858 ns |      0.3988 ns |      0.3730 ns |  1.00 |    1 |
                                                               |              |                 |                |                |                |       |      |
                                NoOpLog4NetMultipleValuesParam |         1000 |     ltfdmhiubtc |      69.463 ns |      0.9444 ns |      0.8834 ns |  1.00 |    1 |
                                                               |              |                 |                |                |                |       |      |
                                           NoOpNLogNetNoParams |         1000 |     ltfdmhiubtc |       2.073 ns |      0.0253 ns |      0.0225 ns |  1.00 |    1 |
                                                               |              |                 |                |                |                |       |      |
                               NoOpNLogNetSingleReferenceParam |         1000 |     ltfdmhiubtc |       2.625 ns |      0.0364 ns |      0.0340 ns |  1.00 |    1 |
                                                               |              |                 |                |                |                |       |      |
                                   NoOpNLogNetSingleValueParam |         1000 |     ltfdmhiubtc |       2.281 ns |      0.0222 ns |      0.0208 ns |  1.00 |    1 |
                                                               |              |                 |                |                |                |       |      |
                            NoOpNLogNetMultipleReferencesParam |         1000 |     ltfdmhiubtc |      41.525 ns |      0.4481 ns |      0.4191 ns |  1.00 |    1 |
                                                               |              |                 |                |                |                |       |      |
                                NoOpNLogNetMultipleValuesParam |         1000 |     ltfdmhiubtc |      57.622 ns |      0.5341 ns |      0.4996 ns |  1.00 |    1 |
