using System.Threading.Tasks;
using SHBL.SPT.UI.Model.Core;
using SHBL.SPT.UI.Model.WebAuth.Responses;

namespace SHBL.SPT.UI.WebApi.Services.WebAuth
{
    public class GetAuthHomeService : RequestServiceBase<GetAuthHomeResponse>
    {
        public override async Task<GetAuthHomeResponse> ProcessRequest()
        {
            return await Task.FromResult(new GetAuthHomeResponse());
        }
    }
}