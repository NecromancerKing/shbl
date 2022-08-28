using Shbl.Spt.Business.Core.Interfaces;
using Shbl.Spt.Ui.Model.Core.Activities.Response;
using Shbl.Spt.Ui.Model.Core.Core;

namespace Shbl.Spt.WebApi.Core.Services.Activities
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