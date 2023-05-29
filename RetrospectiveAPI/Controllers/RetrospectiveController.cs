using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RetrospectiveAPI.Model;
using RetrospectiveAPI.Service.AddFeedback;
using RetrospectiveAPI.Service.CreateRetrospective;
using RetrospectiveAPI.Service.GetAllRetrospectives;
using RetrospectiveAPI.Service.GetRetrospectivesByDate;
using System.Globalization;

namespace RetrospectiveAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RetrospectiveController : ControllerBase
    {
        private readonly ICreateRetrospectiveService createRetrospectiveService;
        private readonly IGetAllRetrospectivesService getAllRetrospectivesService;
        private readonly IGetRetrospectivesByDate getRetrospectivesByDate;
        private readonly IAddFeedbackService addFeedbackService;

        public RetrospectiveController(ICreateRetrospectiveService createRetrospectiveService, IGetAllRetrospectivesService getAllRetrospectivesService, IGetRetrospectivesByDate getRetrospectivesByDate, IAddFeedbackService addFeedbackService) 
        {
            this.createRetrospectiveService = createRetrospectiveService;
            this.getAllRetrospectivesService = getAllRetrospectivesService;
            this.getRetrospectivesByDate= getRetrospectivesByDate;
            this.addFeedbackService = addFeedbackService;
        }

        [Consumes("application/json")]
        [HttpPost("create")]
        public IActionResult CreateNewRetrospective([FromBody] CreateRetrospectiveRequestEntity createRetrospectiveRequestEntity) 
        {
           
            try
            {
                createRetrospectiveService.CreateNewRetrospective(createRetrospectiveRequestEntity);
                return StatusCode(201);
            }
            catch (Exception ex) 
            {
                var errorMessage = "Failed To Create Retrospective: " + ex.Message;
                return StatusCode(409, errorMessage);
            }            
        }

        [HttpGet("retrospectives")]
        public IActionResult GetAllRetrospectives() 
        {
            //string contentType = Request.Headers["Content-Type"].ToString();
            var retrospectives = getAllRetrospectivesService.GetAllRetrospectives();
            if (retrospectives == null || retrospectives.Count == 0) 
            {
                return NotFound();
            }
            return Ok(retrospectives);
        }

        [HttpGet("retrospective")]
        public IActionResult GetRetrospectivesByDate([FromQuery] String date)
        {
            try 
            {
                var retrospectives = getRetrospectivesByDate.GetRetrospectives(DateTime.ParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture));
                if (retrospectives == null || retrospectives.Count == 0)
                {
                    return NotFound();
                }
                return Ok(retrospectives);
            }
            catch (Exception ex) 
            {
                return StatusCode(500, ex.Message);
            }
        }
        
        
        [HttpPost("retrospective/{Name}/feedback")]
        public IActionResult AddFeedbackToRetrospective(string Name,[FromBody] FeedbackItem feedbackItem)
        {
            try {
                addFeedbackService.AddFeedback(Name, feedbackItem);
                return Ok();
            } 
            catch (Exception ex) 
            {
                var errorMessage = "Failed To Add Feedback: " + ex.Message;
                return StatusCode(500, errorMessage);
            }        

        }

    }
}