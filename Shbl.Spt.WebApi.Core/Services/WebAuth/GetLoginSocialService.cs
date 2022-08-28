using Shbl.Spt.Ui.Model.Core.Core;
using Shbl.Spt.Ui.Model.Core.WebAuth.Responses;

namespace Shbl.Spt.WebApi.Core.Services.WebAuth
{
    public class GetLoginSocialService : RequestServiceBase<GetLoginSocialResponse>
    {
        public override async Task<GetLoginSocialResponse> ProcessRequest()
        {
            return await Task.FromResult(new GetLoginSocialResponse());
        }
    }
}