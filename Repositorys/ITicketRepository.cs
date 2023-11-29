
using authen.Data;
using authen.Dtos;

namespace authen.Repositorys
{
  public interface ITicketRepository
  {
    bool SaveChanges();

    IEnumerable<Ticket> findTicketsByUserId(string userId);
    public IEnumerable<Seat> FindTicketsByScheduleId(int scheduleId);

    public IEnumerable<Ticket> FindTicketsBySchedule_IdAndSeat_Id(int scheduleId, int seatId);

    public void CreateNewTicket(Ticket ticketDto);
  }
}