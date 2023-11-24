using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace RailwayProject.Models
{
    public class Station
    {
        [Key]
        
        public int Id { get; set; }
        [Required]
        public string? StationCode {  get; set; }
        [Required]
        public string? StationName { get; set; }
        [AllowNull]
        public string? NameOfDivision { get; set; }
        [Required]
        public string? Zone {  get; set; }
        public int? ZipCode { get; set; }
        [ForeignKey("StartStationId")]
        public ICollection<Route>? StartRoutes { get; set;}
        [ForeignKey("EndStationId")]
        public ICollection<Route>? EndRoutes { get; set; }
        [ForeignKey("DepartureStationId")]
        public ICollection<RouteDetail>? DepartureRouteDetails { get; set; }
        [ForeignKey("ArrivalStationId")]
        public ICollection<RouteDetail>? ArrivalRouteDetails {  get; set; }
    }
}
