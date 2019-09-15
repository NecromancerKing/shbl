using SHBL.SPT.UI.Model.Base;

namespace SHBL.SPT.UI.Model.Activities
{
    public class GetNextWordRequest : RequestBase
    {
        public byte ActivityId { get; set; }
        public byte Session { get; set; }
    }
}
