using Shbl.Spt.Ui.Model.Core.Core;
using Shbl.Spt.Ui.Model.Core.Home.Responses;

namespace Shbl.Spt.WebApi.Core.Services.Home
{
    public class GetDashboardService : RequestServiceBase<DashboardResponse>
    {
        public override async Task<DashboardResponse> ProcessRequest()
        {
            return await Task.FromResult(new DashboardResponse());
        }
    }
}