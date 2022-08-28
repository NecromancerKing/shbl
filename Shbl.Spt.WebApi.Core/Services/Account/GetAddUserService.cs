using Shbl.Spt.Ui.Model.Core.Account.Responses;
using Shbl.Spt.Ui.Model.Core.Core;

namespace Shbl.Spt.WebApi.Core.Services.Account
{
    public class GetAddUserService : RequestServiceBase<GetAddUserResponse>
    {
        public override async Task<GetAddUserResponse> ProcessRequest()
        {
            return await Task.FromResult(new GetAddUserResponse());
        }
    }
}