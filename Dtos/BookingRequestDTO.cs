namespace authen.Dtos
{
  public class BookingRequestDTO
  {
    public int? UserId { get; set; }
    public int? ScheduleId { get; set; }
    public List<int> ListSeatIds { get; set; }
  }
}
