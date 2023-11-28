
using authen.Data;
using authen.Dtos;

namespace authen.Repositorys
{
  public class TicketRepository : ITicketRepository
  {

    private readonly ApplicationDbContext _context;

    public TicketRepository(ApplicationDbContext context)
    {
      _context = context;
    }

    public IEnumerable<Ticket> FindTicketsByScheduleId(int scheduleId)
    {
      var tickets = _context.tickets
             .Where(ticket => ticket.ScheduleId == scheduleId)
             .ToList();

      return tickets;
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