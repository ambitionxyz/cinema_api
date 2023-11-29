using authen.Data;
using authen.Dtos;
using authen.Repositorys;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace authen.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class SeatsController : ControllerBase
  {
    private readonly ISeatRepository _seatRepository;
    private readonly IScheduleRepository _scheduleRepository;
    private readonly ITicketRepository _ticketRepository;
    private readonly IMapper _mapper;

    public SeatsController(ISeatRepository seatRepository, IScheduleRepository scheduleRepository, ITicketRepository ticketRepository,
  IMapper mapper)
    {
      _seatRepository = seatRepository;
      _scheduleRepository = scheduleRepository;
      _ticketRepository = ticketRepository;
      _mapper = mapper;
    }


    [HttpGet("{scheduleId}")]
    public ActionResult GetSeatsByScheduleId(int scheduleId)
    {
      System.Console.WriteLine($"---> scheduleId", scheduleId);
      // Lấy ra các chỗ ngồi của phòng trong lịch đó
      var schedule = _scheduleRepository.GetById(scheduleId);
      if (schedule == null)
      {
        return NotFound();
      }


      var roomId = schedule.RoomId;
      // "id": 1,
      // "startDate": "2023-11-30T00:00:00",
      // "startTime": "18:30:00",
      // "price": 9.99,
      // "movieId": 3,
      // "movie": null,
      // "branchId": 2,
      // "branch": null,
      // "roomId": 2,
      // "room": null


      var listSeat = _seatRepository.getSeatByRoom_Id(roomId);
      if (listSeat == null)
      {
        return NotFound();
      }
      // Lấy ra các vé đã được đặt trong lịch đó rồi map sang các chỗ ngồi

      var occupiedSeats = _ticketRepository.FindTicketsByScheduleId(1);
      foreach (var occupiedSeat in occupiedSeats)
      {
        System.Console.WriteLine($"---> ", occupiedSeat.Id);
      }
      if (occupiedSeats == null)
      {
        return NotFound();
      }
      // Map list chỗ ngồi của phòng ở bước 1 sang list dto
      IEnumerable<SeatDTO> filteredSeats = listSeat.Select(seat =>
        {
          var seatDTO = new SeatDTO
          {
            Id = seat.Id,

          };
          seatDTO.IsOccupied = occupiedSeats.Any(occupiedSeat => occupiedSeat.Id == seat.Id) ? 1 : 0;
          return seatDTO;
        }).ToList();

      return Ok(filteredSeats);
    }
  }
}