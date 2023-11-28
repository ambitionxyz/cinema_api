using authen.Dtos;
using authen.Repositorys;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace authen.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class SchedulesController : ControllerBase
  {
    private readonly IScheduleRepository _repository;
    private readonly IMapper _mapper;

    public SchedulesController(IScheduleRepository repository,
  IMapper mapper)
    {
      _repository = repository;
      _mapper = mapper;
    }

    [HttpGet("start-times")]
    public ActionResult<List<string>> GetStartTimes([FromQuery] int movieId, [FromQuery] int branchId, [FromQuery] string startDate)
    {
      if (!DateTime.TryParse(startDate, out var parsedDate))
      {
        return BadRequest("Invalid date format. Use yyyy-MM-dd.");
      }

      var startTimes = _repository.GetStartTimeByMovieIdBranchIdAndStartDate(movieId, branchId, parsedDate);

      return Ok(_mapper.Map<IEnumerable<ScheduleDTO>>(startTimes));
    }

    [HttpGet]
    public ActionResult<List<ScheduleDTO>> GetSchedules([FromQuery] int movieId, [FromQuery] int branchId,
       [FromQuery] string startDate, [FromQuery] string startTime, [FromQuery] int roomId)
    {
      if (!DateTime.TryParse(startDate, out var parsedDate) || !TimeSpan.TryParse(startTime, out var parsedTime))
      {
        return BadRequest("Invalid date or time format. Use yyyy-MM-dd for date and HH:mm:ss for time.");
      }

      var schedules = _repository.GetSchedulesByFilters(movieId, branchId, parsedDate, parsedTime, roomId);

      return Ok(_mapper.Map<IEnumerable<ScheduleDTO>>(schedules));
    }

  }
}