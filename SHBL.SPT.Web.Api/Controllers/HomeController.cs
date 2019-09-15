using SHBL.SPT.ApiFactory.Core;
using SHBL.SPT.UI.WebApi.Services.Home;
using System;
using System.Web.Http;

namespace SHBL.SPT.UI.WebApi.Controllers
{
    [RoutePrefix("Home")]
    public class HomeController : ApiController
    {
        [HttpGet]
        [Route("Dashboard")]
        public IHttpActionResult Dashboard()
        {
            try
            {
                var response = RequestServiceFactory.Instance.Resolve<GetDashboardService>();
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
        public IHttpActionResult Header()
        {
            try
            {
                var response = RequestServiceFactory.Instance.Resolve<GetHeaderService>().ProcessRequest();
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
        public IHttpActionResult GetClientInfo()
        {
            try
            {
                var response = RequestServiceFactory.Instance.Resolve<GetClientInfoService>().ProcessRequest();
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
        public IHttpActionResult GetIndicators()
        {
            try
            {
                var response = RequestServiceFactory.Instance.Resolve<GetIndicatorService>().ProcessRequest();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}