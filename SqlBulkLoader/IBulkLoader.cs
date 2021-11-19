namespace SqlBulkLoader;

using System.Collections.Generic;
using System.Threading.Tasks;

public interface IBulkLoader
{
    ValueTask LoadAsync<T>(string table, IEnumerable<T> source);
}
