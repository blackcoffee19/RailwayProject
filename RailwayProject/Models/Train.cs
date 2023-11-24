using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace RailwayProject.Models
{
    public class Train
    {
        [Key]
        [Required]
        public string? TrainCode { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? TypeCode { get; set; }
        public bool IsRunning { get; set; } = true;
        [AllowNull]
        public string? Description { get; set; } 
        public ICollection<Schedule>? Schedules { get; set; }  
        public ICollection<Class>? Classes { get; set; }
    }
}
