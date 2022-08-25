using System.Collections.Generic;
using System.Threading.Tasks;
using SHBL.SPT.Model.Activities;
using SHBL.SPT.Model.Dto;

namespace SHBL.SPT.Business.Interfaces
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