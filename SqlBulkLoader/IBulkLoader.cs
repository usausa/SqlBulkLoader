namespace SqlBulkLoader;

public interface IBulkLoader
{
    ValueTask LoadAsync<T>(string table, IEnumerable<T> source);
}
