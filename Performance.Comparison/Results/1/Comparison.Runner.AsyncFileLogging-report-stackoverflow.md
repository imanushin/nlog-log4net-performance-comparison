
    BenchmarkDotNet=v0.11.5, OS=Windows 10.0.17763.475 (1809/October2018Update/Redstone5)
    Intel Core i5-6600K CPU 3.50GHz (Skylake), 1 CPU, 4 logical and 4 physical cores
      [Host] : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3362.0
      Clr    : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3362.0

    Job=Clr  Runtime=Clr  

                             Method | _intArgument | _stringArgument |     Mean |     Error |    StdDev | Ratio | Rank |
    ------------------------------- |------------- |---------------- |---------:|----------:|----------:|------:|-----:|
                    NLogNetNoParams |         1000 |     ltfdmhiubtc | 1.845 us | 0.0369 us | 0.0939 us |  1.00 |    1 |
                                    |              |                 |          |           |           |       |      |
        NLogNetSingleReferenceParam |         1000 |     ltfdmhiubtc | 1.948 us | 0.0414 us | 0.0935 us |  1.00 |    1 |
                                    |              |                 |          |           |           |       |      |
            NLogNetSingleValueParam |         1000 |     ltfdmhiubtc | 2.120 us | 0.0421 us | 0.0967 us |  1.00 |    1 |
                                    |              |                 |          |           |           |       |      |
     NLogNetMultipleReferencesParam |         1000 |     ltfdmhiubtc | 2.975 us | 0.0589 us | 0.1148 us |  1.00 |    1 |
                                    |              |                 |          |           |           |       |      |
         NLogNetMultipleValuesParam |         1000 |     ltfdmhiubtc | 3.515 us | 0.0702 us | 0.1480 us |  1.00 |    1 |
