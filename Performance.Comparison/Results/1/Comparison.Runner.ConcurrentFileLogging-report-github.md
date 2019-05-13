``` ini

BenchmarkDotNet=v0.11.5, OS=Windows 10.0.17763.475 (1809/October2018Update/Redstone5)
Intel Core i5-6600K CPU 3.50GHz (Skylake), 1 CPU, 4 logical and 4 physical cores
  [Host] : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3362.0
  Clr    : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3362.0

Job=Clr  Runtime=Clr  

```
|                                       Method |       Mean |      Error |     StdDev | Ratio | Rank |
|--------------------------------------------- |-----------:|-----------:|-----------:|------:|-----:|
|  &#39;KeepFileOpen=true, ConcurrentWrites=false&#39; |   5.978 us |  0.0448 us |  0.0419 us |  1.00 |    1 |
|                                              |            |            |            |       |      |
|   &#39;KeepFileOpen=true, ConcurrentWrites=true&#39; |  13.070 us |  0.0729 us |  0.0682 us |  1.00 |    1 |
|                                              |            |            |            |       |      |
| &#39;KeepFileOpen=false, ConcurrentWrites=false&#39; | 675.946 us | 13.3731 us | 30.9943 us |  1.00 |    1 |
|                                              |            |            |            |       |      |
|  &#39;KeepFileOpen=false, ConcurrentWrites=true&#39; | 679.459 us |  4.8281 us |  4.2799 us |  1.00 |    1 |
