namespace authen.Dtos
{
  public class RoomDTO
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public int Capacity { get; set; }
    public double TotalArea { get; set; }
    public string ImgURL { get; set; }
    public BranchDTO Branch { get; set; }
  }
}