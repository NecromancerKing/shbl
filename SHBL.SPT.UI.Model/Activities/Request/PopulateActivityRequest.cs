using SHBL.SPT.UI.Model.Base;

namespace SHBL.SPT.UI.Model.Activities
{
    public class PopulateActivityRequest : RequestBase
    {
        public byte ActivityId { get; set; }
        public byte Session { get; set; }
    }
}
