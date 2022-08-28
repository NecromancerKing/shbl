using Shbl.Spt.Ui.Model.Core.Core;
using Shbl.Spt.Ui.Model.Core.WebAuth.Responses;

namespace Shbl.Spt.WebApi.Core.Services.WebAuth
{
    public class GetLoginService : RequestServiceBase<GetLoginResponse>
    {
        public override async Task<GetLoginResponse> ProcessRequest()
        {
            return await Task.FromResult(new GetLoginResponse());
        }
    }
}