using System.Threading.Tasks;
using SHBL.SPT.UI.Model.Core;
using SHBL.SPT.UI.Model.WebAuth.Responses;

namespace SHBL.SPT.UI.WebApi.Services.WebAuth
{
    public class GetLoginSocialService : RequestServiceBase<GetLoginSocialResponse>
    {
        public override async Task<GetLoginSocialResponse> ProcessRequest()
        {
            return await Task.FromResult(new GetLoginSocialResponse());
        }
    }
}