using authen.Data;

namespace authen.Dtos
{
  public class BillDTO
  {
    public int Id { get; set; }
    public DateTime CreatedTime { get; set; }
    public List<TicketDTO> ListTickets { get; set; }
    public ApplicationUser User { get; set; }
  }
}