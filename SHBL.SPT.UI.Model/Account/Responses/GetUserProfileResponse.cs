using SHBL.SPT.UI.Model.Base;

namespace SHBL.SPT.UI.Model.Account.Responses
{
    public class GetUserProfileResponse : ResponseBase
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
