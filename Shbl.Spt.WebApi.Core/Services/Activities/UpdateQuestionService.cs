using Shbl.Spt.Business.Core.Interfaces;
using Shbl.Spt.Ui.Model.Core.Activities.Request;
using Shbl.Spt.Ui.Model.Core.Activities.Response;
using Shbl.Spt.Ui.Model.Core.Core;

namespace Shbl.Spt.WebApi.Core.Services.Activities
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
                CfFileNameOne = dto.CfFileNameOne,
                CfFileNameTwo = dto.CfFileNameTwo
            };
        }
    }
}