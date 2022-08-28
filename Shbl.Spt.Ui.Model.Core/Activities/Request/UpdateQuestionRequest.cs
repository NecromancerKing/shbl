using Shbl.Spt.Ui.Model.Core.Base;

namespace Shbl.Spt.Ui.Model.Core.Activities.Request
{
    public class UpdateQuestionRequest : RequestBase
    {
        public int QuestionId { get; set; }
        public string ChosenWord { get; set; }
    }
}
