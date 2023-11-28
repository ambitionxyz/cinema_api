namespace authen.Dtos
{
  public class MovieDTO
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string SmallImageURl { get; set; }
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
  }
}