namespace SqlBulkLoader;

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

public class SqlBulkLoaderConfig
{
    [AllowNull]
    public string ConnectionString { get; set; }

    public Func<Type, IEnumerable<PropertyInfo>> PropertySelector { get; set; } = t => t.GetProperties();
}
