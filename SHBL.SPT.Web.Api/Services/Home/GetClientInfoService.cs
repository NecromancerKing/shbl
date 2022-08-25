using System.Threading.Tasks;
using SHBL.SPT.Business.Interfaces;
using SHBL.SPT.UI.Model.Home.Responses;
using SHBL.SPT.UI.Model.Core;

namespace SHBL.SPT.UI.WebApi.Services.Home
{
    public class GetClientInfoService : RequestServiceBase<GetClientInfoResponse>
    {
        private readonly IUserActivityService _userActivityService;
        private readonly AuthContext _authContext;

        public GetClientInfoService(IUserActivityService userActivityService, AuthContext authContext)
        {
            _userActivityService = userActivityService;
            _authContext = authContext;
        }

        public override async Task<GetClientInfoResponse> ProcessRequest()
        {
            var dto = await _userActivityService.GetClientInfoAsync(_authContext.UserName);

            return new GetClientInfoResponse
            {
                CFTypeId = dto.CfTypeId,
                CFTypeName = dto.CfTypeName,
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