using Application.Interfaces;
using Application.Models.Request;
using Application.Models.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("api/meeting")]
    [ApiController]
    public class MeetingController : ControllerBase
    {
        private readonly IMeetingService _meetingService;

        public MeetingController(IMeetingService meetingService)
        {
            _meetingService = meetingService;
        }

        [HttpGet]
        [Authorize]
        public IActionResult GetAllMeetings()
        {
            var response = _meetingService.GetAllMeetings();

            if (response.Count == 0)
            {
                return NotFound("No se encuentran turnos");
            }

            return Ok(response);
        }

        [HttpGet("{id}")]
        public ActionResult<MeetingResponse?> GetMeetingById([FromRoute] int id)
        {
            var response = _meetingService.GetMeetingById(id);

            if (response is null)
            {
                return NotFound("Turno no encontrado");
            }

            return Ok(response);
        }

        [HttpGet("professional/{professionalId}")]
        public IActionResult GetMeetingsByProfessional([FromRoute] int professionalId)
        {
            var response = _meetingService.GetMeetingsByProfessional(professionalId);
            return Ok(response);
        }

        [HttpGet("customer/{customerId}")]
        public IActionResult GetMeetingsByCustomer([FromRoute] int customerId)
        {
            var response = _meetingService.GetMeetingsByCustomer(customerId);
            return Ok(response);
        }

        [HttpPost]
        public IActionResult CreateMeeting([FromBody] MeetingRequest meeting)
        {
            _meetingService.CreateMeeting(meeting);
            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult<bool> UpdateMeeting([FromRoute] int id, [FromBody] MeetingRequest meeting)
        {
            return Ok(_meetingService.UpdateMeeting(id, meeting));
        }

        [HttpDelete("{id}")]
        public ActionResult<bool> DeleteMeeting([FromRoute] int id)
        {
            return Ok(_meetingService.DeleteMeeting(id));
        }
    }
}

