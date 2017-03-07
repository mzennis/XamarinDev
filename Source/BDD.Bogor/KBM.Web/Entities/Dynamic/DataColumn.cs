using System;

namespace KBM.Web.Entities
{
    public class DataColumn
    {
        public DataColumn()
        {
            this.DataType = typeof(object);
        }

        public Type DataType { get; set; }
        public string ColumnName { get; set; }
    }
}
