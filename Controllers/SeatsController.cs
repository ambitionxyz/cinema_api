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


    [HttpGet]
    public ActionResult<IEnumerable<SeatDTO>> GetSeatsByScheduleId([FromQuery] int scheduleId)
    {
      // Lấy ra các chỗ ngồi của phòng trong lịch đó
      var room = _scheduleRepository.GetById(scheduleId);
      if (room == null)
      {
        return NotFound();
      }
      IEnumerable<Seat> listSeat = _seatRepository.getSeatByRoom_Id(room.Room.Id);
      if (listSeat == null)
      {
        return NotFound();
      }
      // Lấy ra các vé đã được đặt trong lịch đó rồi map sang các chỗ ngồi
      IEnumerable<Seat> occupiedSeats = (IEnumerable<Seat>)_ticketRepository.FindTicketsByScheduleId(scheduleId).ToList();

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
            // Map các thuộc tính khác của Seat sang SeatDTO ở đây
          };
          seatDTO.IsOccupied = occupiedSeats.Any(occupiedSeat => occupiedSeat.Id == seat.Id) ? 1 : 0;
          return seatDTO;
        }).ToList();

      return Ok(filteredSeats);
    }
  }
}