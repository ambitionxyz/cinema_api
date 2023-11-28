using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace authen.Data
{
  [Table("bill")]
  public class Bill
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Column("createdTime")]
    public DateTime CreatedTime { get; set; }

    [ForeignKey("User")]
    [Column("user_id")]
    public string UserId { get; set; }

    public ApplicationUser User { get; set; }
  }
}