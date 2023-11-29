
using authen.Data;
using authen.Dtos;

namespace authen.Repositorys
{
  public class BillRepository : IBillRepository
  {

    private readonly ApplicationDbContext _context;

    public BillRepository(ApplicationDbContext context)
    {
      _context = context;
    }

    public void CreateNewBill(Bill billDto)
    {
      if (billDto == null)
      {
        throw new ArgumentNullException(nameof(billDto));
      }
      _context.Add(billDto);
    }

    public bool SaveChanges()
    {
      return (_context.SaveChanges() >= 0);
    }
  }
}