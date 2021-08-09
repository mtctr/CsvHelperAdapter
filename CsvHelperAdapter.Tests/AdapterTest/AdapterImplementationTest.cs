using CsvHelperAdapter.Core.Implementation;
using CsvHelperAdapter.Core.Interface;
using CsvHelperAdapter.Tests.CsvClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CsvHelperAdapter.Tests.AdapterTest
{
    [TestClass]
    public class AdapterImplementationTest
    {
        private ICsvAdapter _csvAdapter;
        [TestInitialize]
        public void Initialize()
        {
            _csvAdapter = new CsvAdapter();
        }

        [TestMethod]
        public async Task Data_list_should_not_be_empty()
        {
            var url = "https://filesamples.com/samples/document/csv/sample4.csv";
            IEnumerable<Sample> data = new List<Sample>();

            using(var client = new HttpClient())
            {
                var bytes = await client.GetByteArrayAsync(url);
                data = _csvAdapter.GetObjectData<Sample, SampleMap>(bytes);
            }

            Assert.IsTrue(data.Any());
        }
    }
}
