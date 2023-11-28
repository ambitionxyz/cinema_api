using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace authen.Data
{
  [Table("branch")]
  public class Branch
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Column(TypeName = "nvarchar(2000)")]
    public string ImgURL { get; set; }

    public string Name { get; set; }
    public string DiaChi { get; set; }
    public string PhoneNo { get; set; }
  }
}