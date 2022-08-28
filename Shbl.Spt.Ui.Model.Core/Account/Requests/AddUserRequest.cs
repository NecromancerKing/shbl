using Shbl.Spt.Ui.Model.Core.Base;

namespace Shbl.Spt.Ui.Model.Core.Account.Requests
{
    public class AddUserRequest : RequestBase
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public byte AgeGroup { get; set; }
        public byte ProficiencyLevel { get; set; }
        public int CfType { get; set; }
    }
}
