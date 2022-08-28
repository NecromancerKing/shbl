using Shbl.Spt.Ui.Model.Core.Base;

namespace Shbl.Spt.Ui.Model.Core.Account.Requests
{
    public class UpdateProfileRequest : RequestBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
