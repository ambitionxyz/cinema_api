
using authen.Data;
using authen.Dtos;

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

      var startTimes = _context.schedules
          .Where(s => s.MovieId == movieId &&
                        s.BranchId == branchId &&
                        s.StartDate == startDate &&
                        s.StartTime == startTime &&
                        s.RoomId == roomId)
            .Distinct()
            .ToList();

      return startTimes;
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