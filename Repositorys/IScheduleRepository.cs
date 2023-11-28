
using authen.Data;
using authen.Dtos;

namespace authen.Repositorys
{
  public interface IScheduleRepository
  {
    bool SaveChanges();

    IEnumerable<DateTime> GetStartTimeByMovieIdBranchIdAndStartDate(int movieId, int branchId, DateTime startDate);
    IEnumerable<Schedule> GetSchedulesByFilters(int movieId, int branchId, DateTime startDate, TimeSpan startTime, int roomId);
    public Schedule GetById(int scheduleId);
  }
}