﻿using Shbl.Spt.Ui.Model.Core.Base;

namespace Shbl.Spt.Ui.Model.Core.Home.Responses
{
    public class GetClientInfoResponse : ResponseBase
    {
        public int CfTypeId { get; set; }
        public string CfTypeName { get; set; }
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
