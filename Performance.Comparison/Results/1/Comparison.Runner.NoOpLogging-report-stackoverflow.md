
    BenchmarkDotNet=v0.11.5, OS=Windows 10.0.17763.475 (1809/October2018Update/Redstone5)
    Intel Core i5-6600K CPU 3.50GHz (Skylake), 1 CPU, 4 logical and 4 physical cores
      [Host] : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3362.0
      Clr    : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3362.0

    Job=Clr  Runtime=Clr  

                             Method | _intArgument | _stringArgument |      Mean |     Error |    StdDev | Ratio | Rank |
    ------------------------------- |------------- |---------------- |----------:|----------:|----------:|------:|-----:|
                    Log4NetNoParams |         1000 |     ltfdmhiubtc | 11.946 ns | 0.0213 ns | 0.0200 ns |  1.00 |    1 |
                                    |              |                 |           |           |           |       |      |
        Log4NetSingleReferenceParam |         1000 |     ltfdmhiubtc | 11.208 ns | 0.0252 ns | 0.0236 ns |  1.00 |    1 |
                                    |              |                 |           |           |           |       |      |
            Log4NetSingleValueParam |         1000 |     ltfdmhiubtc | 12.449 ns | 0.0159 ns | 0.0141 ns |  1.00 |    1 |
                                    |              |                 |           |           |           |       |      |
     Log4NetMultipleReferencesParam |         1000 |     ltfdmhiubtc | 47.585 ns | 0.0637 ns | 0.0564 ns |  1.00 |    1 |
                                    |              |                 |           |           |           |       |      |
         Log4NetMultipleValuesParam |         1000 |     ltfdmhiubtc | 61.371 ns | 0.0972 ns | 0.0909 ns |  1.00 |    1 |
                                    |              |                 |           |           |           |       |      |
                    NLogNetNoParams |         1000 |     ltfdmhiubtc |  1.825 ns | 0.0033 ns | 0.0026 ns |  1.00 |    1 |
                                    |              |                 |           |           |           |       |      |
        NLogNetSingleReferenceParam |         1000 |     ltfdmhiubtc |  2.062 ns | 0.0034 ns | 0.0031 ns |  1.00 |    1 |
                                    |              |                 |           |           |           |       |      |
            NLogNetSingleValueParam |         1000 |     ltfdmhiubtc |  2.003 ns | 0.0025 ns | 0.0024 ns |  1.00 |    1 |
                                    |              |                 |           |           |           |       |      |
     NLogNetMultipleReferencesParam |         1000 |     ltfdmhiubtc | 35.744 ns | 0.0405 ns | 0.0379 ns |  1.00 |    1 |
                                    |              |                 |           |           |           |       |      |
         NLogNetMultipleValuesParam |         1000 |     ltfdmhiubtc | 47.731 ns | 0.0932 ns | 0.0872 ns |  1.00 |    1 |
