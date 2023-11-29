
using authen.Data;
using authen.Dtos;

namespace authen.Repositorys
{
  public interface IBillRepository
  {
    bool SaveChanges();

    void CreateNewBill(Bill billDto);

  }
}