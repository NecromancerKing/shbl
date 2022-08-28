using Shbl.Spt.Business.Core.Interfaces;
using Shbl.Spt.Ui.Model.Core.Core;
using Shbl.Spt.Ui.Model.Core.Home.Responses;

namespace Shbl.Spt.WebApi.Core.Services.Home
{
    public class GetClientInfoService : RequestServiceBase<GetClientInfoResponse>
    {
        private readonly IUserActivityService _userActivityService;
        private readonly string _username;

        public GetClientInfoService(IUserActivityService userActivityService, IHttpContextAccessor httpContextAccessor)
        {
            _userActivityService = userActivityService;
            _username = httpContextAccessor.HttpContext!.User!.Identity!.Name;
        }

        public override async Task<GetClientInfoResponse> ProcessRequest()
        {
            var dto = await _userActivityService.GetClientInfoAsync(_username);

            return new GetClientInfoResponse
            {
                CfTypeId = dto.CfTypeId,
                CfTypeName = dto.CfTypeName,
                ActivityId = dto.ActivityId,
                ActivityName = dto.ActivityName,
                ActivityTitle = dto.ActivityTitle,
                ActivityDesc = dto.ActivityDesc,
                Session = dto.Session,
                QuestionId = dto.QuestionId,
                IsTest = dto.IsTest,
                IsAdmin = dto.IsAdmin
            };
        }
    }
}