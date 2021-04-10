# SqlBulkLoader - SqlBulkCopy helper

## Usage example

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

