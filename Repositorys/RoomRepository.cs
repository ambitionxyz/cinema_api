
using authen.Data;
using authen.Dtos;
using Microsoft.EntityFrameworkCore;

namespace authen.Repositorys
{
  public class RoomRepository : IRoomRepository
  {

    private readonly ApplicationDbContext _context;

    public RoomRepository(ApplicationDbContext context)
    {
      _context = context;
    }

    public IEnumerable<Room> GetRoomsByBranchAndMovieAndSchedule(int movieId, int branchId, string startDate, string startTime)
    {
      var rooms = (from r in _context.rooms
                   join s in _context.schedules on r.Id equals s.RoomId
                   where s.MovieId == movieId &&
                         s.BranchId == branchId &&
                         s.StartDate.ToString() == startDate &&
                         s.StartTime.ToString() == startTime

                   select r).Include(s => s.Branch).ToList();

      return rooms;
    }


    public bool SaveChanges()
    {
      return (_context.SaveChanges() >= 0);
    }
  }
}