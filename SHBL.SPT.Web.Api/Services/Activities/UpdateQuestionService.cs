using SHBL.SPT.UI.Model.Activities;
using System.Threading.Tasks;
using SHBL.SPT.Business.Interfaces;
using SHBL.SPT.UI.Model.Core;

namespace SHBL.SPT.UI.WebApi.Services.Activities
{
    public class UpdateQuestionService : RequestServiceBase<UpdateQuestionRequest, UpdateQuestionResponse>
    {
        private readonly IUserActivityService _userActivityService;

        public UpdateQuestionService(IUserActivityService userActivityService)
        {
            _userActivityService = userActivityService;
        }

        public override async Task<UpdateQuestionResponse> ProcessRequest(UpdateQuestionRequest request)
        {
            var dto = await _userActivityService.UpdateQuestionAsync(request.QuestionId, request.ChosenWord);

            return new UpdateQuestionResponse
            {
                Result = dto.Result,
                FileNameOne = dto.FileNameOne,
                FileNameTwo = dto.FileNameTwo,
                CFFileNameOne = dto.CfFileNameOne,
                CFFileNameTwo = dto.CfFileNameTwo
            };
        }
    }
}