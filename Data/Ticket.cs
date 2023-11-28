using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace authen.Data
{
  [Table("ticket")]
  public class Ticket
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public string QRImageURL { get; set; }

    [ForeignKey("Seat")]
    [Column("seat_id")]
    public int SeatId { get; set; }

    public Seat Seat { get; set; }

    [ForeignKey("Schedule")]
    [Column("schedule_id")]
    public int ScheduleId { get; set; }

    public Schedule Schedule { get; set; }

    [ForeignKey("Bill")]
    [Column("bill_id")]
    public int BillId { get; set; }

    public Bill Bill { get; set; }
  }
}