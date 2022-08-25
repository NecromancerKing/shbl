using System.Threading.Tasks;
using SHBL.SPT.UI.Model.Core;
using SHBL.SPT.UI.Model.WebAuth.Responses;

namespace SHBL.SPT.UI.WebApi.Services.WebAuth
{
    public class GetRegisterService : RequestServiceBase<GetRegisterResponse>
    {
        public override async Task<GetRegisterResponse> ProcessRequest()
        {
            return await Task.FromResult(new GetRegisterResponse());
        }
    }
}