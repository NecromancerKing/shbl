using Shbl.Spt.Ui.Model.Core.Base;

namespace Shbl.Spt.Ui.Model.Core.Activities.Response
{
    public class UpdateQuestionResponse : ResponseBase
    {
        public bool? Result { get; set; }
        public string FileNameOne { get; set; }
        public string FileNameTwo { get; set; }
        public string CfFileNameOne { get; set; }
        public string CfFileNameTwo { get; set; }
    }
}
