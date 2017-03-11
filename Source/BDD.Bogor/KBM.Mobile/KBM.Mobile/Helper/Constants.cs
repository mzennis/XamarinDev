using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KBM.Mobile.Helper
{
    public class UrlConstants
    {
        public string GETALLURL { set; get; } = "http://kbm.azurewebsites.net/api/{0}";
        public string GETURL { set; get; } = "http://kbm.azurewebsites.net/api/{0}/{1}";
        public string ADDURL { set; get; } = "http://kbm.azurewebsites.net/api/{0}";
        public string UPDATEURL { set; get; } = "http://kbm.azurewebsites.net/api/{0}/{1}";
        public string DELETEURL { set; get; } = "http://kbm.azurewebsites.net/api/{0}/{1}";

        public UrlConstants(string ServiceName)
        {
            GETALLURL = GETALLURL.Replace("{0}", ServiceName);
            GETURL = GETURL.Replace("{0}", ServiceName);
            ADDURL = ADDURL.Replace("{0}", ServiceName);
            UPDATEURL = UPDATEURL.Replace("{0}", ServiceName);
            DELETEURL = DELETEURL.Replace("{0}", ServiceName);
        }
    }
}
