using SHBL.SPT.ApiFactory.Core;
using SHBL.SPT.UI.Model.Activities;
using SHBL.SPT.UI.WebApi.Services.Activities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SHBL.SPT.UI.WebApi.Controllers
{
    [RoutePrefix("Activity")]
    public class ActivityController : ApiController
    {
        [HttpPost]
        [Authorize]
        [Route("PopulateActivity")]
        public IHttpActionResult PopulateActivity(PopulateActivityRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var response = RequestServiceFactory.Instance.Resolve<PopulateActivityService>().ProcessRequest(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Authorize]
        [Route("GetNextWord")]
        public IHttpActionResult GetNextWord(GetNextWordRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var response = RequestServiceFactory.Instance.Resolve<GetNextWordService>().ProcessRequest(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Authorize]
        [Route("UpdateQuestion")]
        public IHttpActionResult UpdateQuestion(UpdateQuestionRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var response = RequestServiceFactory.Instance.Resolve<UpdateQuestionService>().ProcessRequest(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Authorize]
        [Route("GetTestResult")]
        public IHttpActionResult GetTestResult()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var response = RequestServiceFactory.Instance.Resolve<GetTestResultService>().ProcessRequest();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("SeedData")]
        public IHttpActionResult SeedData()
        {
            try
            {
                var response = RequestServiceFactory.Instance.Resolve<SeedDataService>().ProcessRequest();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
