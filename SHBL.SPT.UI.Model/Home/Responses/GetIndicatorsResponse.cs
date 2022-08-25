using SHBL.SPT.UI.Model.Base;
using System.Collections.Generic;
using SHBL.SPT.Model.Dto;

namespace SHBL.SPT.UI.Model.Home
{
    public class GetIndicatorsResponse : ResponseBase
    {
        public GetIndicatorsResponse()
        {
            Indicators = new List<IndicatorDto>();
        }

        public List<IndicatorDto> Indicators { get; set; }

    }
}
