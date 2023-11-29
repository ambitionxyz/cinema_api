using authen.Data;
using authen.Dtos;
using authen.Helpers;
using authen.Repositorys;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace authen.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class BillsController : ControllerBase
  {
    private readonly IBillRepository _buildRepository;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IScheduleRepository _scheduleRepository;
    private readonly ITicketRepository _ticketRepository;
    private readonly ISeatRepository _seatRepository;
    private readonly IMapper _mapper;

    public BillsController(IBillRepository buildRepository, IScheduleRepository scheduleRepository, UserManager<ApplicationUser> userManager,
  ITicketRepository ticketRepository, ISeatRepository seatRepository
  , IMapper mapper)
    {

      _buildRepository = buildRepository;
      _userManager = userManager;
      _scheduleRepository = scheduleRepository;
      _ticketRepository = ticketRepository;
      _seatRepository = seatRepository;
      _mapper = mapper;
    }


    [HttpPost("create-new-bill")]
    public async Task<IActionResult> CreateNewBillAsync([FromBody] BookingRequestDTO bookingRequestDTO)
    {
      try
      {

        if (bookingRequestDTO == null)
        {
          return NotFound();
        }

        //Lấy ra lịch
        Schedule schedule = _scheduleRepository.GetById((int)bookingRequestDTO.ScheduleId);

        //         {
        //   "id": 2,
        //   "startDate": "2023-12-01T00:00:00",
        //   "startTime": "14:00:00",
        //   "price": 8.5,
        //   "movieId": 4,
        //   "movie": null,
        //   "branchId": 1,
        //   "branch": null,
        //   "roomId": 2,
        //   "room": null
        // }

        if (schedule == null)
        {
          return NotFound();
        }
        //Lấy ra người dùng
        ApplicationUser user = await _userManager.FindByIdAsync(bookingRequestDTO.UserId);

        if (user == null)
        {
          return NotFound();
        }

        //Lưu Bill gồm thông tin người dùng xuống trước

        var billToCreate = new Bill
        {
          User = user,
          CreatedTime = DateTime.Now
        };

        _buildRepository.CreateNewBill(billToCreate);
        _buildRepository.SaveChanges();

        //Với mỗi ghế ngồi check xem đã có ai đặt chưa, nếu rồi thì throw, roll back luôn còn ko
        //thì đóng gói các thông tin ghế và lịch vào vé và lưu xuống db
        foreach (var seatId in bookingRequestDTO.ListSeatIds)
        {

          if (_ticketRepository.FindTicketsBySchedule_IdAndSeat_Id(schedule.Id, seatId).Any())
          {
            return await Task.FromResult(BadRequest("Đã có người nhanh tay hơn đặt ghế, mời bạn chọn lại!"));

          }

          //           {
          //   "id": 2,
          //   "name": "Seat B",
          //   "roomId": 1,
          //   "room": null
          // }
          var seat = _seatRepository.GetById(seatId);

          var ticket = new Ticket
          {
            Schedule = schedule,
            Seat = seat,
            Bill = billToCreate,
            QRImageURL = "https://scontent-sin6-2.xx.fbcdn.net/v/t1.15752-9/268794058_655331555823095_3657556108194277679_n.png?_nc_cat=105&ccb=1-5&_nc_sid=ae9488&_nc_ohc=BrNXGO8HufkAX_OGjWc&_nc_ht=scontent-sin6-2.xx&oh=03_AVK_zaJj7pziY9nLrVqoIQJAzbomu4KPgED1PxFFpYfCrQ&oe=61F778D8"
          };

          _ticketRepository.CreateNewTicket(ticket);

          _ticketRepository.SaveChanges();
        }


        return await Task.FromResult(Ok());

      }
      catch (Exception ex)
      {

        return await Task.FromResult(BadRequest("Có lỗi xảy ra"));
      }
    }
  }
}