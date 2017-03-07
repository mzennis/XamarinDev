using System;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.SignalR.Hubs;
using System.Linq;
using System.Collections.Generic;
using MoreLinq;
using KBM.Web.Entities;
using KBM.Web.Tools;

using System.Threading.Tasks;
using KBM.Web.Data;

namespace KBM.Web
{
    [HubName("KBMHub")]
    public class KBMHub : Hub
    {
        private static ApplicationDbContext Ctx { set; get; }

        public KBMHub()
        {
            if (Ctx == null)
            {
                Ctx = new ApplicationDbContext();
            }
        }
        [HubMethodName("InsertFirstName")]
        public async Task<OutputData> InsertFirstName(string UserName)
        {
            var Output = new OutputData();
            var IsExists = Ctx.DataUser.Any(x => x.UserName == UserName);
            if (!IsExists)
            {
                var newNode = Ctx.DataUser.Add(new UserProfile() { UserName=UserName, Email=UserName });
                await Ctx.SaveChangesAsync();
                Output.IsSucceed = true;
            }
            else
            {
                Output.IsSucceed = false;
            }
            return Output;
        }
    }
}
