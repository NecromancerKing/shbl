using SHBL.SPT.UI.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHBL.SPT.UI.Model.Account.Requests
{
    public class UpdateProfileRequest : RequestBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
