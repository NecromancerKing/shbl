using SHBL.SPT.UI.Model.Base;

namespace SHBL.SPT.UI.Model.Activities
{
    public class GetTestResultResponse : ResponseBase
    {
        public int Corrects { get; set; }
        public int Wrongs { get; set; }
        public int Total { get; set; }
    }
}
