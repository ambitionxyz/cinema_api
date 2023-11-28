using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace authen.Data
{
  [Table("seat")]
  public class Seat
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public string Name { get; set; }

    [ForeignKey("Room")]
    [Column("room_id")]
    public int RoomId { get; set; }

    public Room Room { get; set; }
  }
}