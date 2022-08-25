using System.Threading.Tasks;
using SHBL.SPT.UI.Model.Core;
using SHBL.SPT.UI.Model.WebAuth.Responses;

namespace SHBL.SPT.UI.WebApi.Services.WebAuth
{
    public class GetLoginService : RequestServiceBase<GetLoginResponse>
    {
        public override async Task<GetLoginResponse> ProcessRequest()
        {
            return await Task.FromResult(new GetLoginResponse());
        }
    }
}