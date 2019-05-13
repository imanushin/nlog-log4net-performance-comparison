
    BenchmarkDotNet=v0.11.5, OS=Windows 10.0.17763.475 (1809/October2018Update/Redstone5)
    Intel Core i5-6600K CPU 3.50GHz (Skylake), 1 CPU, 4 logical and 4 physical cores
      [Host] : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3362.0
      Clr    : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3362.0

    Job=Clr  Runtime=Clr  InvocationCount=1  
    UnrollFactor=1  

                Method |      Mean |     Error |   StdDev |    Median | Ratio | Rank |
    ------------------ |----------:|----------:|---------:|----------:|------:|-----:|
         CreateLog4Net |  52.01 us |  4.213 us | 12.36 us |  55.30 us |  1.00 |    1 |
                       |           |           |          |           |       |      |
      CreateNLogTypeOf | 269.86 us | 19.114 us | 56.36 us | 290.40 us |  1.00 |    1 |
                       |           |           |          |           |       |      |
     CreateNLogDynamic | 209.51 us | 17.794 us | 52.46 us | 195.15 us |  1.00 |    1 |
