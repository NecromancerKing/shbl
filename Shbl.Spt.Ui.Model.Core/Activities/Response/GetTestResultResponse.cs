using Shbl.Spt.Ui.Model.Core.Base;

namespace Shbl.Spt.Ui.Model.Core.Activities.Response
{
    public class GetTestResultResponse : ResponseBase
    {
        public int Corrects { get; set; }
        public int Wrongs { get; set; }
        public int Total { get; set; }
    }
}
