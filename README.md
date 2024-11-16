# SqlBulkLoader - SqlBulkCopy helper

[![NuGet](https://img.shields.io/nuget/v/SqlBulkLoader.svg)](https://www.nuget.org/packages/SqlBulkLoader)

# Usage

```csharp
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using SqlBulkLoader;

public static class Program
{
    public static async Task Main()
    {
        var loader = new SqlBulkLoader(new SqlBulkLoaderConfig
        {
            ConnectionString = "..."
        });

        await loader.LoadAsync("TargetTable", Query());
    }

    private static IEnumerable<Data> Query()
    {
        ...
    }
}
```

