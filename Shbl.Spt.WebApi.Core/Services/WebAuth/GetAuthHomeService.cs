using Shbl.Spt.Ui.Model.Core.Core;
using Shbl.Spt.Ui.Model.Core.WebAuth.Responses;

namespace Shbl.Spt.WebApi.Core.Services.WebAuth
{
    public class GetAuthHomeService : RequestServiceBase<GetAuthHomeResponse>
    {
        public override async Task<GetAuthHomeResponse> ProcessRequest()
        {
            return await Task.FromResult(new GetAuthHomeResponse());
        }
    }
}