using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net;
using Xamarin.Forms;
using System.Linq;

namespace KBM.Mobile.Helper
{
    public class LocalDB<T> : IDataRepository<T> where T : class
    {
        static SQLiteConnection db = null;
        public LocalDB()
        {
            if (db == null)
            {
                db = DependencyService.Get<ISQLite>().GetConnection();
                //db = con;
            }
            db.CreateTable<T>();
        }

        public Task<OutputData> DeleteData(string ColumnPK, int ValuePK)
        {
            try
            {
                db.Delete(ValuePK);

                return Task.FromResult(new OutputData() { IsSucceed = true, Data = null });
            }
            catch (Exception ex)
            {
                return Task.FromResult(new OutputData() { IsSucceed = false, ErrorMsg = ex.Message, Data = null });
            }
        }

        public Task<OutputData> GetData(string ColumnPK, int ValuePK)
        {
            try
            {
                var datas = db.Get<T>(ValuePK);
                return Task.FromResult(new OutputData() { IsSucceed = true, Data = datas });
            }
            catch (Exception ex)
            {
                return Task.FromResult(new OutputData() { IsSucceed = false, ErrorMsg = ex.Message, Data = null });
            }
        }

        public Task<OutputData> GetDatas(string TableName)
        {
            try
            {
                var datas = db.Query<T>($"select * from {TableName}");

                return Task.FromResult(new OutputData() { IsSucceed=true, Data=datas.AsEnumerable() });
            }
            catch (Exception ex)
            {
                return Task.FromResult(new OutputData() { IsSucceed=false, ErrorMsg=ex.Message, Data=null });
            }
        }

      

        public Task<OutputData> UpdateData(string ColumnPK, int ValuePK, T data)
        {
            try
            {
                db.Update(data);

                return Task.FromResult(new OutputData() { IsSucceed = true, Data = null });
            }
            catch (Exception ex)
            {
                return Task.FromResult(new OutputData() { IsSucceed = false, ErrorMsg = ex.Message, Data = null });
            }
        }
        
      

        public Task<OutputData> InsertData(T data)
        {
            try
            {
                db.Insert(data);
                return Task.FromResult(new OutputData() { IsSucceed = true, Data = null });
            }
            catch (Exception ex)
            {
                return Task.FromResult(new OutputData() { IsSucceed = false, ErrorMsg = ex.Message, Data = null });
            }
        }
        
    }
}
