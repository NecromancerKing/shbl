using Shbl.Spt.Ui.Model.Core.Core;
using Shbl.Spt.Ui.Model.Core.WebAuth.Responses;

namespace Shbl.Spt.WebApi.Core.Services.WebAuth
{
    public class GetForgetPasswordService : RequestServiceBase<GetForgetPasswordResponse>
    {
        public override async Task<GetForgetPasswordResponse> ProcessRequest()
        {
            return await Task.FromResult(new GetForgetPasswordResponse());
        }
    }
}