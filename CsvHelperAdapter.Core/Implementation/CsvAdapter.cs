using CsvHelper;
using CsvHelper.Configuration;
using CsvHelperAdapter.Core.Interface;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace CsvHelperAdapter.Core.Implementation
{
    public class CsvAdapter : ICsvAdapter
    {
        public IEnumerable<T> GetObjectData<T, TMap>(byte[] fileData)
        {
            if (!typeof(TMap).IsSubclassOf(typeof(ClassMap<T>)))
                throw new Exception("Invalid mapping");

            using (var stream = new MemoryStream(fileData))
            {
                var config = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    BadDataFound = null
                };

                using (var reader = new StreamReader(stream))
                using (var csv = new CsvReader(reader, config))
                {
                    var mapType = typeof(TMap);
                    csv.Context.RegisterClassMap(mapType);
                    return csv.GetRecords<T>().ToList();
                }
            }
        }
    }
}
