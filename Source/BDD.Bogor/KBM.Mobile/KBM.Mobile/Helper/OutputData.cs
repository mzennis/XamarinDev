using System;
using System.Collections.Generic;
using System.Text;

namespace KBM.Mobile.Helper
{
    public class OutputData
    {
        public string ErrorMsg { get; set; }
        public bool IsSucceed { get; set; }
        public object Data { set; get; }
        public string Message { set; get; }
    }
}
