namespace SqlBulkLoader;

using System.Reflection;

public class SqlBulkLoaderConfig
{
    public string ConnectionString { get; set; } = default!;

    public Func<Type, IEnumerable<PropertyInfo>> PropertySelector { get; set; } = t => t.GetProperties();
}
