using SHBL.SPT.UI.Model.Activities;
using SHBL.SPT.UI.WebApi.Services.Activities;
using System;
using System.Threading.Tasks;
using System.Web.Http;

namespace SHBL.SPT.UI.WebApi.Controllers
{
    [RoutePrefix("Activity")]
    public class ActivityController : ApiController
    {
        private readonly PopulateActivityService _populateActivityService;
        private readonly GetNextWordService _getNextWordService;
        private readonly UpdateQuestionService _updateQuestionService;
        private readonly GetTestResultService _getTestResultService;
        private readonly SeedDataService _seedDataService;

        public ActivityController(
            PopulateActivityService populateActivityService, 
            GetNextWordService getNextWordService, 
            UpdateQuestionService updateQuestionService, 
            GetTestResultService getTestResultService,
            SeedDataService seedDataService)
        {
            _populateActivityService = populateActivityService;
            _getNextWordService = getNextWordService;
            _updateQuestionService = updateQuestionService;
            _getTestResultService = getTestResultService;
            _seedDataService = seedDataService;
        }

        [HttpPost]
        [Authorize]
        [Route("PopulateActivity")]
        public async Task<IHttpActionResult> PopulateActivity(PopulateActivityRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var response = await _populateActivityService.ProcessRequest(request);
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
        public async Task<IHttpActionResult> GetNextWord(GetNextWordRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var response = await _getNextWordService.ProcessRequest(request);
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
        public async Task<IHttpActionResult> UpdateQuestion(UpdateQuestionRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var response = await _updateQuestionService.ProcessRequest(request);
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
        public async Task<IHttpActionResult> GetTestResult()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var response = await _getTestResultService.ProcessRequest();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("SeedData")]
        public async Task<IHttpActionResult> SeedData()
        {
            try
            {
                var response = await _seedDataService.ProcessRequest();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
