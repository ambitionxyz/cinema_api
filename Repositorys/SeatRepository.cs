
using authen.Data;
using authen.Dtos;

namespace authen.Repositorys
{
  public class SeatRepository : ISeatRepository
  {

    private readonly ApplicationDbContext _context;

    public SeatRepository(ApplicationDbContext context)
    {
      _context = context;
    }

    public IEnumerable<Seat> getSeatByRoom_Id(int roomId)
    {
      var seats = _context.seats
           .Where(s => s.RoomId == roomId)
           .ToList();

      return seats;
    }

    public bool SaveChanges()
    {
      return (_context.SaveChanges() >= 0);
    }
  }
}