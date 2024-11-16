namespace SqlBulkLoader;

using System.Reflection;

public sealed class SqlBulkLoaderConfig
{
    public string ConnectionString { get; set; } = default!;

    public Func<Type, IEnumerable<PropertyInfo>> PropertySelector { get; set; } = static t => t.GetProperties();
}
