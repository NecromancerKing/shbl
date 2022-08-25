using SHBL.SPT.UI.WebApi.Services.Home;
using System;
using System.Threading.Tasks;
using System.Web.Http;

namespace SHBL.SPT.UI.WebApi.Controllers
{
    [RoutePrefix("Home")]
    public class HomeController : ApiController
    {
        private readonly GetDashboardService _getDashboardService;
        private readonly GetHeaderService _getHeaderService;
        private readonly GetClientInfoService _getClientInfoService;
        private readonly GetIndicatorService _getIndicatorService;

        public HomeController(
            GetDashboardService getDashboardService,
            GetHeaderService getHeaderService,
            GetClientInfoService getClientInfoService,
            GetIndicatorService getIndicatorService)
        {
            _getDashboardService = getDashboardService;
            _getHeaderService = getHeaderService;
            _getClientInfoService = getClientInfoService;
            _getIndicatorService = getIndicatorService;
        }

        [HttpGet]
        [Route("Dashboard")]
        public async Task<IHttpActionResult> Dashboard()
        {
            try
            {
                var response = await _getDashboardService.ProcessRequest();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Authorize]
        [Route("Header")]
        public async Task<IHttpActionResult> Header()
        {
            try
            {
                var response = await _getHeaderService.ProcessRequest();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Authorize]
        [Route("ClientInfo")]
        public async Task<IHttpActionResult> GetClientInfo()
        {
            try
            {
                var response = await _getClientInfoService.ProcessRequest();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Authorize]
        [Route("GetIndicators")]
        public async Task<IHttpActionResult> GetIndicators()
        {
            try
            {
                var response = await _getIndicatorService.ProcessRequest();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}