using Shbl.Spt.Ui.Model.Core.Base;

namespace Shbl.Spt.Ui.Model.Core.Activities.Response
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
