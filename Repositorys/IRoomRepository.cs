
using authen.Data;
using authen.Dtos;

namespace authen.Repositorys
{
  public interface IRoomRepository
  {
    bool SaveChanges();

    public IEnumerable<Room> GetRoomsByBranchAndMovieAndSchedule(int movieId, int branchId, string startDate, string startTime);
  }
}