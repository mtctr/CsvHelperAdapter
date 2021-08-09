using CsvHelper.Configuration;

namespace CsvHelperAdapter.Tests.CsvClasses
{
    public class SampleMap : ClassMap<Sample>
    {
        public SampleMap()
        {
            Map(m => m.GameNumber).Index(0);
            Map(m => m.GameLength).Index(1);
        }
    }
}
