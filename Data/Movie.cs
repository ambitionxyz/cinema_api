using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace authen.Data
{
  [Table("movie")]
  public class Movie
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public string Name { get; set; }

    [Column(TypeName = "nvarchar(1000)")]
    public string SmallImageURL { get; set; }

    [Column(TypeName = "nvarchar(500)")]
    public string ShortDescription { get; set; }

    [Column(TypeName = "nvarchar(1000)")]
    public string LongDescription { get; set; }

    [Column(TypeName = "nvarchar(1000)")]
    public string LargeImageURL { get; set; }

    public string Director { get; set; }
    public string Actors { get; set; }
    public string Categories { get; set; }
    public DateTime ReleaseDate { get; set; }
    public int Duration { get; set; }

    [Column(TypeName = "nvarchar(1000)")]
    public string TrailerURL { get; set; }

    public string Language { get; set; }
    public string Rated { get; set; }
    public int IsShowing { get; set; }
  }
}