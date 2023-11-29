
using authen.Data;
using authen.Dtos;
using Microsoft.EntityFrameworkCore;

namespace authen.Repositorys
{
  public class TicketRepository : ITicketRepository
  {

    private readonly ApplicationDbContext _context;

    public TicketRepository(ApplicationDbContext context)
    {
      _context = context;
    }

    public IEnumerable<Seat> FindTicketsByScheduleId(int scheduleId)
    {
      System.Console.WriteLine($"---FIND ID> ", scheduleId);
      var occupiedSeats = _context.tickets
       .Where(ticket => ticket.ScheduleId == scheduleId)
       .Select(ticket => ticket.Seat) // Chỉ lấy thông tin chỗ ngồi từ vé
       .Distinct() // Đảm bảo không có chỗ ngồi trùng lặp nếu có nhiều vé cho cùng một chỗ ngồi
       .ToList();


      foreach (var occupiedSeat in occupiedSeats)
      {
        System.Console.WriteLine($"---FIND> ", occupiedSeat.Id);
      }

      return occupiedSeats;
    }

    public IEnumerable<Ticket> FindTicketsBySchedule_IdAndSeat_Id(int scheduleId, int seatId)
    {
      var tickets = _context.tickets
            .Where(t => t.Schedule.Id == scheduleId && t.Seat.Id == seatId)
            .ToList();

      return tickets;
    }

    public void CreateNewTicket(Ticket ticketDto)
    {
      if (ticketDto == null)
      {
        throw new ArgumentNullException(nameof(ticketDto));
      }
      _context.Add(ticketDto);
    }

    public IEnumerable<Ticket> findTicketsByUserId(string userId)
    {
      var listtickets = _context.tickets
            .Where(t => t.Bill.User.Id == userId)
            .OrderByDescending(t => t.Id)
            .ToList();

      return listtickets;
    }
    public bool SaveChanges()
    {
      return (_context.SaveChanges() >= 0);
    }
  }
}