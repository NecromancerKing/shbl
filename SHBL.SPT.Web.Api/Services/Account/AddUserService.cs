using System.Threading.Tasks;
using SHBL.SPT.Business.Interfaces;
using SHBL.SPT.Model.Auth;
using SHBL.SPT.UI.Model.Account.Requests;
using SHBL.SPT.UI.Model.Account.Responses;
using SHBL.SPT.UI.Model.Core;

namespace SHBL.SPT.UI.WebApi.Services.Account
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
                    CFType = await _cfTypeService.GetByIdAsync(request.CFType)
                }
            };

            await _userService.AddUserAsync(user);

            return response;
        }
    }
}