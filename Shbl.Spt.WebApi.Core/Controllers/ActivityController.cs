using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shbl.Spt.Ui.Model.Core.Activities.Request;
using Shbl.Spt.WebApi.Core.Services.Activities;

namespace Shbl.Spt.WebApi.Core.Controllers
{
    [Route("api/[controller]")]
    public class ActivityController : ControllerBase
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
        public async Task<IActionResult> PopulateActivity(PopulateActivityRequest request)
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
        public async Task<IActionResult> GetNextWord(GetNextWordRequest request)
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
        public async Task<IActionResult> UpdateQuestion(UpdateQuestionRequest request)
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
        public async Task<IActionResult> GetTestResult()
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
        public async Task<IActionResult> SeedData()
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
