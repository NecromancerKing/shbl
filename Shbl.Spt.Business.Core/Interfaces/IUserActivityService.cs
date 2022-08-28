using Shbl.Spt.Model.Core.Dto;
using Shbl.Spt.Model.Core.Entity.Activities;

namespace Shbl.Spt.Business.Core.Interfaces
{
    public interface IUserActivityService
    {
        Task<List<SptUserActivityDetail>> GetUserActivityDetailAsync(string username, byte activityId, byte session);

        Task<SptUserActivity> GetLatestUserActivityAsync(string username);

        Task AddActivityAsync(string username, byte activityId);

        Task<UpdateQuestionDto> UpdateQuestionAsync(int questionId, string chosenWord);

        Task<ClientInfoDto> GetClientInfoAsync(string username);

        Task<List<IndicatorDto>> GetIndicatorsAsync(string username);
    }
}