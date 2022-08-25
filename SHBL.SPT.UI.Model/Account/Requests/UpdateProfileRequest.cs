using SHBL.SPT.UI.Model.Base;

namespace SHBL.SPT.UI.Model.Account.Requests
{
    public class UpdateProfileRequest : RequestBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
