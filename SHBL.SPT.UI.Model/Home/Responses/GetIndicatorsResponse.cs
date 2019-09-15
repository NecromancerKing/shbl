using SHBL.SPT.UI.Model.Base;
using System.Collections.Generic;

namespace SHBL.SPT.UI.Model.Home
{
    public class GetIndicatorsResponse : ResponseBase
    {
        public GetIndicatorsResponse()
        {
            Indicators = new List<Indicator>();
        }

        public List<Indicator> Indicators { get; set; }

        public class Indicator
        {
            public string Route { get; set; }
            public string Title { get; set; }
            public bool IsActive { get; set; }
            public string Style { get; set; }
        }
    }
}
