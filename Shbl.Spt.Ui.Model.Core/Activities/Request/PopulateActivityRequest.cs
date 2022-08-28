using Shbl.Spt.Ui.Model.Core.Base;

namespace Shbl.Spt.Ui.Model.Core.Activities.Request
{
    public class PopulateActivityRequest : RequestBase
    {
        public byte ActivityId { get; set; }
        public byte Session { get; set; }
    }
}
