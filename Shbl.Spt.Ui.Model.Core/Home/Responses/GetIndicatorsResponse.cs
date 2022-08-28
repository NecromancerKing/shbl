using Shbl.Spt.Model.Core.Dto;
using Shbl.Spt.Ui.Model.Core.Base;

namespace Shbl.Spt.Ui.Model.Core.Home.Responses
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
