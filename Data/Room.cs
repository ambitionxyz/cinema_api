using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace authen.Data
{
  [Table("room")]
  public class Room
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public string Name { get; set; }
    public int Capacity { get; set; }
    public double TotalArea { get; set; }

    [Column(TypeName = "nvarchar(1000)")]
    public string ImgURL { get; set; }

    [ForeignKey("Branch")]
    [Column("branch_id")]
    public int BranchId { get; set; }

    public Branch Branch { get; set; }
  }
}