using System.Threading.Tasks;
using SHBL.SPT.UI.Model.Account.Responses;
using SHBL.SPT.UI.Model.Core;

namespace SHBL.SPT.UI.WebApi.Services.Account
{
    public class GetAddUserService : RequestServiceBase<GetAddUserResponse>
    {
        public override async Task<GetAddUserResponse> ProcessRequest()
        {
            return await Task.FromResult(new GetAddUserResponse());
        }
    }
}