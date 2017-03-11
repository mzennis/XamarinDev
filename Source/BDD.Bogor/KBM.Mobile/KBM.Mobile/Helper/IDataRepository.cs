using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace KBM.Mobile.Helper
{
    public interface IDataRepository<T>
    {
        Task<OutputData> InsertData(T data);
        Task<OutputData> UpdateData(string ColumnPK, int ValuePK, T data);
        Task<OutputData> DeleteData(string ColumnPK, int ValuePK);
        Task<OutputData> GetData(string ColumnPK, int ValuePK);
        Task<OutputData> GetDatas(string TableName);
    }
}
