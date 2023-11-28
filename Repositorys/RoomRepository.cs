
using authen.Data;
using authen.Dtos;

namespace authen.Repositorys
{
  public class RoomRepository : IRoomRepository
  {

    private readonly ApplicationDbContext _context;

    public RoomRepository(ApplicationDbContext context)
    {
      _context = context;
    }

    public IEnumerable<Room> GetRoomsByBranchAndMovieAndSchedule(int movieId, int branchId, DateTime startDate, TimeSpan startTime)
    {
      var rooms = (from r in _context.rooms
                   join s in _context.schedules on r.Id equals s.RoomId
                   where s.MovieId == movieId &&
                         s.BranchId == branchId &&
                         s.StartDate == startDate.Date &&
                         s.StartTime == startTime
                   select r).ToList();

      return rooms;
    }


    public bool SaveChanges()
    {
      return (_context.SaveChanges() >= 0);
    }
  }
}