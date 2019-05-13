
    BenchmarkDotNet=v0.11.5, OS=Windows 10.0.17763.475 (1809/October2018Update/Redstone5)
    Intel Core i5-6600K CPU 3.50GHz (Skylake), 1 CPU, 4 logical and 4 physical cores
      [Host] : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3362.0
      Clr    : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3362.0

    Job=Clr  Runtime=Clr  

                                           Method |     Mean |     Error |    StdDev | Ratio | Rank |
    --------------------------------------------- |---------:|----------:|----------:|------:|-----:|
      'KeepFileOpen=true, ConcurrentWrites=false' | 1.470 us | 0.0292 us | 0.0799 us |  1.00 |    1 |
                                                  |          |           |           |       |      |
       'KeepFileOpen=true, ConcurrentWrites=true' | 1.875 us | 0.0376 us | 0.1104 us |  1.00 |    1 |
                                                  |          |           |           |       |      |
     'KeepFileOpen=false, ConcurrentWrites=false' | 1.400 us | 0.0278 us | 0.0673 us |  1.00 |    1 |
                                                  |          |           |           |       |      |
      'KeepFileOpen=false, ConcurrentWrites=true' | 1.807 us | 0.0356 us | 0.0554 us |  1.00 |    1 |
