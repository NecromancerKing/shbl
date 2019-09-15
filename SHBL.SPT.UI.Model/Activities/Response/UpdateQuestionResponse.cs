using SHBL.SPT.UI.Model.Base;

namespace SHBL.SPT.UI.Model.Activities
{
    public class UpdateQuestionResponse : ResponseBase
    {
        public bool? Result { get; set; }
        public string FileNameOne { get; set; }
        public string FileNameTwo { get; set; }
        public string CFFileNameOne { get; set; }
        public string CFFileNameTwo { get; set; }
    }
}
