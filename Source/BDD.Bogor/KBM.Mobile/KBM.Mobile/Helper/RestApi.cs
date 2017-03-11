using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace KBM.Mobile.Helper
{
    public class RestApi<T> : IDataRepository<T> where T : class
    {
        static HttpClient client;
        private UrlConstants ApiUrl { set; get; }

        public RestApi()
        {
            if (client == null)
            {
                client = new HttpClient()
                {
                    MaxResponseContentBufferSize = 256000
                };
            }
            string ServiceName = DependencyService.Get<IRestUrl>().GetServiceName(nameof(T));
            ApiUrl = new UrlConstants(ServiceName);
        }
        public async Task<OutputData> DeleteData(string ColumnPK, int ValuePK)
        {
            var uri = new Uri(ApiUrl.DELETEURL.Replace("{1}",ValuePK.ToString()));

            try
            {
                var response = await client.DeleteAsync(uri);

                if (response.IsSuccessStatusCode)
                {

                    return new OutputData() { IsSucceed = true, Data = null };
                }

                return new OutputData() { IsSucceed = false, ErrorMsg = "Fail to call service", Data = null };
            }
            catch (Exception ex)
            {
                return new OutputData() { IsSucceed = false, ErrorMsg = ex.Message, Data = null };
            }
        }

        public async Task<OutputData> GetData(string ColumnPK, int ValuePK)
        {
            var uri = new Uri(ApiUrl.GETURL.Replace("{1}",ValuePK.ToString()));

            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var datas = JsonConvert.DeserializeObject<T>(content);
                    return new OutputData() { IsSucceed = true, Data = datas };
                }

                return new OutputData() { IsSucceed = false, ErrorMsg = "Fail to call service", Data = null };
            }
            catch (Exception ex)
            {
                return new OutputData() { IsSucceed = false, ErrorMsg = ex.Message, Data = null };
            }
        }

        public async Task<OutputData> GetDatas(string TableName)
        {
            var uri = new Uri(ApiUrl.GETALLURL);

            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var datas = JsonConvert.DeserializeObject<List<T>>(content);
                    return new OutputData() { IsSucceed = true, Data = datas.AsEnumerable() };
                }

                return new OutputData() { IsSucceed = false, ErrorMsg = "Fail to call service", Data = null };
            }
            catch (Exception ex)
            {
                return new OutputData() { IsSucceed = false, ErrorMsg = ex.Message, Data = null };
            }
        }

        public async Task<OutputData> InsertData(T data)
        {
            var uriPost = new Uri(ApiUrl.ADDURL);

            try
            {
                var json = JsonConvert.SerializeObject(data);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(uriPost, content);
                
                if (response.IsSuccessStatusCode)
                {
                    return new OutputData() { IsSucceed = true, Data = null };
                }
                return new OutputData() { IsSucceed = false, ErrorMsg = "Fail to call service", Data = null };
            }
            catch (Exception ex)
            {
                return new OutputData() { IsSucceed = false, ErrorMsg = ex.Message, Data = null };
            }
        }

        public async Task<OutputData> UpdateData(string ColumnPK, int ValuePK, T data)
        {
            var uriPut = new Uri(ApiUrl.UPDATEURL.Replace("{1}",ValuePK.ToString()));

            try
            {
                var json = JsonConvert.SerializeObject(data);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PutAsync(uriPut, content);

                if (response.IsSuccessStatusCode)
                {
                    return new OutputData() { IsSucceed = true, Data = null };
                }
                return new OutputData() { IsSucceed = false, ErrorMsg = "Fail to call service", Data = null };
            }
            catch (Exception ex)
            {
                return new OutputData() { IsSucceed = false, ErrorMsg = ex.Message, Data = null };
            }
        }
    }
}
