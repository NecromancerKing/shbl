using SHBL.SPT.UI.Model.Home;
using System.Threading.Tasks;
using SHBL.SPT.UI.Model.Core;

namespace SHBL.SPT.UI.WebApi.Services.Home
{
    public class GetDashboardService : RequestServiceBase<DashboardResponse>
    {
        public override async Task<DashboardResponse> ProcessRequest()
        {
            return await Task.FromResult(new DashboardResponse());
        }
    }
}