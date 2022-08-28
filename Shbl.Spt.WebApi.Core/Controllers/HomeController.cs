using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shbl.Spt.WebApi.Core.Services.Home;

namespace Shbl.Spt.WebApi.Core.Controllers
{
    [Route("api/[controller]")]
    public class HomeController : ControllerBase
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
        public async Task<IActionResult> Dashboard()
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
        public async Task<IActionResult> Header()
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
        public async Task<IActionResult> GetClientInfo()
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
        public async Task<IActionResult> GetIndicators()
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