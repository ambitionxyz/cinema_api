namespace authen.Dtos
{
  public class MovieCreateDTO
  {
    public string Name { get; set; }
    public string SmallImageURL { get; set; }
    public string ShortDescription { get; set; }
    public string LongDescription { get; set; }
    public string LargeImageURL { get; set; }
    public string Director { get; set; }
    public string Actors { get; set; }
    public string Categories { get; set; }
    public DateTime ReleaseDate { get; set; }
    public int Duration { get; set; }
    public string TrailerURL { get; set; }
    public string Language { get; set; }
    public string Rated { get; set; }
    public int IsShowing { get; set; }
  }
}