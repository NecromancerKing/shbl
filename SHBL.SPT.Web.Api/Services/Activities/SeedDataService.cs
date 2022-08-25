using SHBL.SPT.UI.Model.Activities;
using System.Threading.Tasks;
using SHBL.SPT.Business.Interfaces;
using SHBL.SPT.UI.Model.Core;

namespace SHBL.SPT.UI.WebApi.Services.Activities
{
    public class SeedDataService : RequestServiceBase<SeedDataResponse>
    {
        private readonly ISeedDataService _seedDataService;

        public SeedDataService(ISeedDataService seedDataService)
        {
            _seedDataService = seedDataService;
        }

        public override async Task<SeedDataResponse> ProcessRequest()
        {
            await _seedDataService.SeedAsync();

            return new SeedDataResponse();
        }
    }
}