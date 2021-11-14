namespace SqlBulkLoader
{
    using System;
    using System.Collections.Generic;
    using System.Data;

    public sealed class BulkDataReader<T> : IDataReader
    {
        private readonly IEnumerator<T> source;

        private readonly Func<object?, object?>[] accessors;

        public int FieldCount => accessors.Length;

        public int Depth => throw new NotSupportedException();

        public bool IsClosed => false;

        public int RecordsAffected => -1;

        public object this[int i] => throw new NotSupportedException();

        public object this[string name] => throw new NotSupportedException();

        public BulkDataReader(IEnumerable<T> source, Func<object?, object?>[] accessors)
        {
            this.source = source.GetEnumerator();
            this.accessors = accessors;
        }

        public void Dispose()
        {
            source.Dispose();
        }

        public void Close()
        {
        }

        public bool Read() => source.MoveNext();

        public bool NextResult() => throw new NotSupportedException();

        public bool IsDBNull(int i) => throw new NotSupportedException();

        public object GetValue(int i) => accessors[i](source.Current!)!;

        public int GetValues(object[] values) => throw new NotSupportedException();

        public IDataReader GetData(int i) => throw new NotSupportedException();

        public DataTable GetSchemaTable() => throw new NotSupportedException();

        public string GetDataTypeName(int i) => throw new NotSupportedException();

        public Type GetFieldType(int i) => throw new NotSupportedException();

        public string GetName(int i) => throw new NotSupportedException();

        public int GetOrdinal(string name) => throw new NotSupportedException();

        public bool GetBoolean(int i) => throw new NotSupportedException();

        public byte GetByte(int i) => throw new NotSupportedException();

        public long GetBytes(int i, long fieldOffset, byte[]? buffer, int bufferOffset, int length) => throw new NotSupportedException();

        public char GetChar(int i) => throw new NotSupportedException();

        public long GetChars(int i, long fieldOffset, char[]? buffer, int bufferOffset, int length) => throw new NotSupportedException();

        public DateTime GetDateTime(int i) => throw new NotSupportedException();

        public decimal GetDecimal(int i) => throw new NotSupportedException();

        public double GetDouble(int i) => throw new NotSupportedException();

        public float GetFloat(int i) => throw new NotSupportedException();

        public Guid GetGuid(int i) => throw new NotSupportedException();

        public short GetInt16(int i) => throw new NotSupportedException();

        public int GetInt32(int i) => throw new NotSupportedException();

        public long GetInt64(int i) => throw new NotSupportedException();

        public string GetString(int i) => throw new NotSupportedException();
    }
}
