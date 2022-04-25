namespace SqlBulkLoader;

using System.Collections.Concurrent;

using Microsoft.Data.SqlClient;

using Smart.Linq;
using Smart.Reflection;

public sealed class SqlBulkLoader : IBulkLoader
{
    private readonly ConcurrentDictionary<Type, Func<object?, object?>[]> accessorCache = new();

    private readonly SqlBulkLoaderConfig config;

    public SqlBulkLoader(SqlBulkLoaderConfig config)
    {
        this.config = config;
    }

    public async ValueTask LoadAsync<T>(string table, IEnumerable<T> source)
    {
        var accessors = accessorCache.GetOrAdd(typeof(T), CreateAccessors);
        using var reader = new BulkDataReader<T>(source, accessors);
#pragma warning disable CA2007
        await using var con = new SqlConnection(config.ConnectionString);
#pragma warning restore CA2007
        await con.OpenAsync().ConfigureAwait(false);

        using var loader = new SqlBulkCopy(con)
        {
            DestinationTableName = table
        };
        await loader.WriteToServerAsync(reader).ConfigureAwait(false);
    }

    private Func<object?, object?>[] CreateAccessors(Type type)
    {
        return config.PropertySelector(type)
            .Select(x => DelegateFactory.Default.CreateGetter(x))
            .ExcludeNull()
            .ToArray();
    }
}
