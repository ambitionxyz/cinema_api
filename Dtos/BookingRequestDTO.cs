namespace authen.Dtos
{
  public class BookingRequestDTO
  {
    public string? UserId { get; set; }
    public int? ScheduleId { get; set; }
    public List<int> ListSeatIds { get; set; }
  }
}
