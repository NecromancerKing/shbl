using SHBL.SPT.UI.Model.Base;
using System.Collections.Generic;

namespace SHBL.SPT.UI.Model.Activities
{
    public class GetNextWordResponse : ResponseBase
    {
        public int QuestionId { get; set; }
        public int QNo { get; set; }
        public int QCount { get; set; }
        public string FileName { get; set; }
        public List<string> Words { get; set; }
    }
}
