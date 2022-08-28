using Shbl.Spt.Ui.Model.Core.Base;

namespace Shbl.Spt.Ui.Model.Core.Activities.Request
{
    public class GetNextWordRequest : RequestBase
    {
        public byte ActivityId { get; set; }
        public byte Session { get; set; }
    }
}
