using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RailwayProject.Models
{
    public class Schedule
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? TrainCode { get; set; }
        [ForeignKey("TrainCode")]
        public Train? Train { get; set; }
        [Required]
        public int? RouteId { get; set; }
        [ForeignKey("RouteId")]
        public Route? Route { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime? StartAt { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime? EndAt { get; set; }
        public bool ScheduleCompleted { get; set; } = false;
    }
}
