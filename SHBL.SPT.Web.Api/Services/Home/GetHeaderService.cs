using SHBL.SPT.ApiFactory.Core;
using SHBL.SPT.Business;
using SHBL.SPT.DALFactory;
using SHBL.SPT.UI.Model.Home;
using System;
using System.Linq;

namespace SHBL.SPT.UI.WebApi.Services.Home
{
    public class GetHeaderService : RequestServiceBase<HeaderResponse>
    {
        public override HeaderResponse ProcessRequest()
        {
            var response = new HeaderResponse();
            try
            {
                using (var uow = new SptUnitOfWork())
                {
                    var username = AuthContext.Instance.UserName;
                    var user = uow.UserRepository.GetByUserName(username);

                    response.Username = user.Person.FullName;
                    response.Image = null;
                }

                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}