using SHBL.SPT.UI.Model.Base;

namespace SHBL.SPT.UI.Model.Activities
{
    public class UpdateQuestionRequest : RequestBase
    {
        public int QuestionId { get; set; }
        public string ChosenWord { get; set; }
    }
}
