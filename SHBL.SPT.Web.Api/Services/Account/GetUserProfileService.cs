using SHBL.SPT.ApiFactory.Core;
using SHBL.SPT.Business;
using SHBL.SPT.UI.Model.Account.Responses;

namespace SHBL.SPT.UI.WebApi.Services.Account
{
    public class GetUserProfileService : RequestServiceBase<GetUserProfileResponse>
    {
        public override GetUserProfileResponse ProcessRequest()
        {
            var response = new GetUserProfileResponse();
            using (var uow = new SptUnitOfWork())
            {
                var username = AuthContext.Instance.UserName;
                var user = uow.UserRepository.GetByUserName(username);
                response.Email = user.Username;
                response.FirstName = user.Person.FirstName;
                response.LastName = user.Person.LastName; 
            }

            return response;
        }
    }
}