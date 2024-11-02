using Final_Project.Core.Dtos.EventDtos;
using FinalProject.Core;
using FinalProject.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Final_Project.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public EventsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost("/Create_Event")]
        public IActionResult Create(CreateEvent EventDto) {
            Event Event = new Event()
            {
                Name = EventDto.Name,
                Description = EventDto.Description,
                Event_Start_Date = EventDto.Event_Start_Date
            };
            if (_unitOfWork.Events.Create(Event) == null)
                return BadRequest("Bad Request");
            _unitOfWork.Complete();
            return Ok(Event);
        }

        [HttpGet("/Get_Event_By_Id/{id}")]
        public IActionResult Get(int id) {
            Event Event = _unitOfWork.Events.Get(id);
            if (Event == null)
                return NotFound();

            return Ok(Event);
        }

        [HttpGet("/Get_All_Events")]
        public IActionResult GetAll()
        {
            IEnumerable<Event> Events = _unitOfWork.Events.GetAll();
            if (Events == null)
                return NotFound();

            return Ok(Events);
        }

        [HttpPut("/Update_Event")]
        public IActionResult Update(UpdateEvent EventDto)
        {

            Event Event = new()
            {
                EventId = EventDto.EventId,
                Name = EventDto.Name,
                Description = EventDto.Description,
                Event_Start_Date = EventDto.Event_Start_Date
            };
            if(_unitOfWork.Events.Get(Event.EventId) == null)
                return NotFound();
            _unitOfWork.Events.Update(Event);
            _unitOfWork.Complete();
            return Ok(Event);
        }

        [HttpDelete("/Delete_Event/{id}")]
        public IActionResult Delete(int id)
        {
            Event Event = _unitOfWork.Events.Get(id);
            if (Event == null)
                return NotFound("Event Not Found");

            _unitOfWork.Events.Delete(id);
            _unitOfWork.Complete();
            return Ok(Event);
        }
    }
}
