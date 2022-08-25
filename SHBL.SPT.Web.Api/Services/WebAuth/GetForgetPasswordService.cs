using System.Threading.Tasks;
using SHBL.SPT.UI.Model.Core;
using SHBL.SPT.UI.Model.WebAuth.Responses;

namespace SHBL.SPT.UI.WebApi.Services.WebAuth
{
    public class GetForgetPasswordService : RequestServiceBase<GetForgetPasswordResponse>
    {
        public override async Task<GetForgetPasswordResponse> ProcessRequest()
        {
            return await Task.FromResult(new GetForgetPasswordResponse());
        }
    }
}