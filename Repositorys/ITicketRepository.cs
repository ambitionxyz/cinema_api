
using authen.Data;
using authen.Dtos;

namespace authen.Repositorys
{
  public interface ITicketRepository
  {
    bool SaveChanges();

    IEnumerable<Ticket> findTicketsByUserId(string userId);
    public IEnumerable<Ticket> FindTicketsByScheduleId(int scheduleId);
  }
}