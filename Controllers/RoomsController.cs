using authen.Data;
using authen.Dtos;
using authen.Repositorys;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace authen.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class RoomsController : ControllerBase
  {
    private readonly IRoomRepository _repository;
    private readonly IMapper _mapper;

    public RoomsController(IRoomRepository repository,
  IMapper mapper)
    {
      _repository = repository;
      _mapper = mapper;
    }


    [HttpGet]
    public ActionResult<IEnumerable<RoomDTO>> GetRooms([FromQuery] int movieId, [FromQuery] int branchId,
                                               [FromQuery] string startDate, [FromQuery] string startTime)
    {
      // Parse startDate and startTime to appropriate DateTime/TimeSpan objects
      string parsedStartDate = DateTime.Parse(startDate).ToString("yyyy-MM-dd HH:mm:ss.fffffff"); //"2023-11-30T00:00:00"
      string parsedStartTime = TimeSpan.Parse(startTime).ToString(@"hh\:mm\:ss\.fffffff"); ; //"18:30:00"
      // Call the service method to get the rooms based on parameters
      var rooms = _repository.GetRoomsByBranchAndMovieAndSchedule(movieId, branchId, parsedStartDate, parsedStartTime);

      return Ok(_mapper.Map<IEnumerable<RoomDTO>>(rooms));
    }

  }
}