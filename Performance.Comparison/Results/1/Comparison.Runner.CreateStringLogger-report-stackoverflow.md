
    BenchmarkDotNet=v0.11.5, OS=Windows 10.0.17763.475 (1809/October2018Update/Redstone5)
    Intel Core i5-6600K CPU 3.50GHz (Skylake), 1 CPU, 4 logical and 4 physical cores
      [Host] : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3362.0
      Clr    : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3362.0

    Job=Clr  Runtime=Clr  InvocationCount=1  
    UnrollFactor=1  

                      Method |     Mean |    Error |   StdDev |    Median | Ratio | Rank |
    ------------------------ |---------:|---------:|---------:|----------:|------:|-----:|
     CreateLog4NetFromString | 21.23 us | 2.969 us | 8.753 us | 22.800 us |  1.00 |    1 |
                             |          |          |          |           |       |      |
        CreateNLogFromString | 10.18 us | 2.058 us | 6.004 us |  7.250 us |  1.00 |    1 |
