
using authen.Data;
using authen.Dtos;
using Microsoft.EntityFrameworkCore;

namespace authen.Repositorys
{
  public class ScheduleRepository : IScheduleRepository
  {

    private readonly ApplicationDbContext _context;

    public ScheduleRepository(ApplicationDbContext context)
    {
      _context = context;
    }

    public IEnumerable<Schedule> GetSchedulesByFilters(int movieId, int branchId, DateTime startDate, TimeSpan startTime, int roomId)
    {

      var schedules = _context.schedules
        .Where(s => s.MovieId == movieId &&
                    s.RoomId == roomId &&
                    s.BranchId == branchId &&
                    s.StartDate == startDate &&
                    s.StartTime == startTime)
        .Include(s => s.Movie) // Include để lấy thông tin của Movie
        .Include(s => s.Room) // Include để lấy thông tin của Room
        .Include(s => s.Branch) // Include để lấy thông tin của Room
        .ToList();

      return schedules;
    }

    public IEnumerable<DateTime> GetStartTimeByMovieIdBranchIdAndStartDate(int movieId, int branchId, DateTime startDate)
    {
      var startTimes = _context.schedules
           .Where(s => s.Movie.Id == movieId && s.Branch.Id == branchId && s.StartDate == startDate)
           .Select(s => s.StartDate)
           .Distinct()
           .ToList();

      return startTimes;
    }

    public Schedule GetById(int scheduleId)
    {
      return _context.schedules.Find(scheduleId);
    }

    public bool SaveChanges()
    {
      return (_context.SaveChanges() >= 0);
    }
  }
}