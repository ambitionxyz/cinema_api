
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
      IEnumerable<Seat> seats = _context.seats
           .Where(s => s.RoomId == roomId)
           .ToList();
      foreach (var seat in seats)
      {
        System.Console.WriteLine(seat.Name);
      }
      return seats;
    }

    public bool SaveChanges()
    {
      return (_context.SaveChanges() >= 0);
    }

    public Seat GetById(int id)
    {
      return _context.seats.Find(id);
    }
  }


}