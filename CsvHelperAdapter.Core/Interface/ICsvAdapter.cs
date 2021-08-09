using System.Collections.Generic;

namespace CsvHelperAdapter.Core.Interface
{
    public interface ICsvAdapter
    {
        IEnumerable<T> GetObjectData<T,TMap>(byte[] fileData);
    }
}
