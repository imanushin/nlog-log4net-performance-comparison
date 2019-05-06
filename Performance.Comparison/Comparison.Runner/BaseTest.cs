using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Environments;
using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Exporters.Csv;

namespace Comparison.Runner
{
    [ClrJob(baseline: true)]
    [RPlotExporter,
     PlainExporter,
     CsvMeasurementsExporter,
     CsvExporter(CsvSeparator.Comma),
     MarkdownExporterAttribute.GitHub,
     MarkdownExporterAttribute.StackOverflow]
    [RankColumn]
    public abstract class BaseTest
    {

    }
}