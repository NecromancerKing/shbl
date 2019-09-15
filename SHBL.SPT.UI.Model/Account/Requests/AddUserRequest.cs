using SHBL.SPT.UI.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHBL.SPT.UI.Model.Account.Requests
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
        public int CFType { get; set; }
    }
}
