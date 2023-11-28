namespace authen.Dtos
{
  public class ScheduleDTO
  {
    public int Id { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime StartTime { get; set; }
    public BranchDTO Branch { get; set; }
    public RoomDTO Room { get; set; }
    public MovieDTO Movie { get; set; }
    public double Price { get; set; }
  }
}
