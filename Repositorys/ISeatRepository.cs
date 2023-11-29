
using authen.Data;
using authen.Dtos;

namespace authen.Repositorys
{
  public interface ISeatRepository
  {
    bool SaveChanges();

    IEnumerable<Seat> getSeatByRoom_Id(int roomId);

    public Seat GetById(int id);

  }
}