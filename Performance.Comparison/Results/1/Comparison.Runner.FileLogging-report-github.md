``` ini

BenchmarkDotNet=v0.11.5, OS=Windows 10.0.17763.475 (1809/October2018Update/Redstone5)
Intel Core i5-6600K CPU 3.50GHz (Skylake), 1 CPU, 4 logical and 4 physical cores
  [Host] : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3362.0
  Clr    : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3362.0

Job=Clr  Runtime=Clr  

```
|                         Method | _intArgument | _stringArgument |     Mean |     Error |    StdDev | Ratio | Rank |
|------------------------------- |------------- |---------------- |---------:|----------:|----------:|------:|-----:|
|                Log4NetNoParams |         1000 |     ltfdmhiubtc | 7.705 us | 0.0630 us | 0.0589 us |  1.00 |    1 |
|                                |              |                 |          |           |           |       |      |
|    Log4NetSingleReferenceParam |         1000 |     ltfdmhiubtc | 7.801 us | 0.0523 us | 0.0490 us |  1.00 |    1 |
|                                |              |                 |          |           |           |       |      |
|        Log4NetSingleValueParam |         1000 |     ltfdmhiubtc | 8.049 us | 0.0747 us | 0.0699 us |  1.00 |    1 |
|                                |              |                 |          |           |           |       |      |
| Log4NetMultipleReferencesParam |         1000 |     ltfdmhiubtc | 8.742 us | 0.0418 us | 0.0391 us |  1.00 |    1 |
|                                |              |                 |          |           |           |       |      |
|     Log4NetMultipleValuesParam |         1000 |     ltfdmhiubtc | 8.909 us | 0.1000 us | 0.0935 us |  1.00 |    1 |
|                                |              |                 |          |           |           |       |      |
|                NLogNetNoParams |         1000 |     ltfdmhiubtc | 6.056 us | 0.0502 us | 0.0470 us |  1.00 |    1 |
|                                |              |                 |          |           |           |       |      |
|    NLogNetSingleReferenceParam |         1000 |     ltfdmhiubtc | 6.560 us | 0.0411 us | 0.0385 us |  1.00 |    1 |
|                                |              |                 |          |           |           |       |      |
|        NLogNetSingleValueParam |         1000 |     ltfdmhiubtc | 6.631 us | 0.0386 us | 0.0342 us |  1.00 |    1 |
|                                |              |                 |          |           |           |       |      |
| NLogNetMultipleReferencesParam |         1000 |     ltfdmhiubtc | 7.116 us | 0.0419 us | 0.0392 us |  1.00 |    1 |
|                                |              |                 |          |           |           |       |      |
|     NLogNetMultipleValuesParam |         1000 |     ltfdmhiubtc | 7.366 us | 0.0483 us | 0.0403 us |  1.00 |    1 |
