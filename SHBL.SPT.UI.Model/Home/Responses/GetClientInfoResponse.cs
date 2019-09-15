using SHBL.SPT.UI.Model.Base;
using System.Collections.Generic;

namespace SHBL.SPT.UI.Model.Home.Responses
{
    public class GetClientInfoResponse : ResponseBase
    {
        public int CFTypeId { get; set; }
        public string CFTypeName { get; set; }
        public int? ActivityId { get; set; }
        public string ActivityName { get; set; }
        public string ActivityTitle { get; set; }
        public string ActivityDesc { get; set; }
        public byte? Session { get; set; }
        public int? QuestionId { get; set; }
        public bool? IsTest { get; set; }
        public bool IsAdmin { get; set; }
    }
}
