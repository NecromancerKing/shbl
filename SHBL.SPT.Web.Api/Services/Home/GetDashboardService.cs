using SHBL.SPT.ApiFactory.Core;
using SHBL.SPT.UI.Model.Home;
using System;

namespace SHBL.SPT.UI.WebApi.Services.Home
{
    public class GetDashboardService : RequestServiceBase<DashboardResponse>
    {
        public override DashboardResponse ProcessRequest()
        {
            var response = new DashboardResponse();
            try
            {
                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}