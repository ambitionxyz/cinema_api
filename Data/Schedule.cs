using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AutoMapper.Configuration.Annotations;

namespace authen.Data
{
  [Table("schedule")]
  public class Schedule
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public DateTime StartDate { get; set; }
    public TimeSpan StartTime { get; set; }
    public double Price { get; set; }

    [ForeignKey("Movie")]
    [Column("movie_id")]
    public int MovieId { get; set; }

    public Movie Movie { get; set; }

    [ForeignKey("Branch")]
    [Column("branch_id")]
    public int BranchId { get; set; }

    public Branch Branch { get; set; }

    [ForeignKey("Room")]
    [Column("room_id")]
    public int RoomId { get; set; }

    public Room Room { get; set; }
  }
}