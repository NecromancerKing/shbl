using Shbl.Spt.Ui.Model.Core.Core;
using Shbl.Spt.Ui.Model.Core.WebAuth.Responses;

namespace Shbl.Spt.WebApi.Core.Services.WebAuth
{
    public class GetRegisterService : RequestServiceBase<GetRegisterResponse>
    {
        public override async Task<GetRegisterResponse> ProcessRequest()
        {
            return await Task.FromResult(new GetRegisterResponse());
        }
    }
}