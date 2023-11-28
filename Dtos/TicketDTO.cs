namespace authen.Dtos
{
  public class TicketDTO
  {
    public int Id { get; set; }
    public string QrImageURL { get; set; }
    public ScheduleDTO Schedule { get; set; }
    public SeatDTO Seat { get; set; }
    public BillDTO Bill { get; set; }
  }
}