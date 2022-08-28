using Shbl.Spt.Business.Core.Interfaces;
using Shbl.Spt.Model.Core.Entity.Auth;
using Shbl.Spt.Ui.Model.Core.Account.Requests;
using Shbl.Spt.Ui.Model.Core.Account.Responses;
using Shbl.Spt.Ui.Model.Core.Core;

namespace Shbl.Spt.WebApi.Core.Services.Account
{
    public class AddUserService : RequestServiceBase<AddUserRequest, AddUserResponse>
    {
        private readonly IUserService _userService;
        private readonly ICfTypeService _cfTypeService;

        public AddUserService(IUserService userService, ICfTypeService cfTypeService)
        {
            _userService = userService;
            _cfTypeService = cfTypeService;
        }

        public override async Task<AddUserResponse> ProcessRequest(AddUserRequest request)
        {
            var response = new AddUserResponse();

            var user = new SptUser
            {
                Username = request.Email,
                Password = request.Password,
                IsAdmin = request.IsAdmin,
                Person = new Person
                {
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Gender = request.Gender,
                    AgeGroup = (Person.AgeGroupEnum)request.AgeGroup,
                    ProficiencyLevel = (Person.ProficiencyLevelEnum)request.ProficiencyLevel,
                    CfType = await _cfTypeService.GetByIdAsync(request.CfType)
                }
            };

            await _userService.AddUserAsync(user);

            return response;
        }
    }
}