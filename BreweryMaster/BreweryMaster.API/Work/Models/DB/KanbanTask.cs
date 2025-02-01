using BreweryMaster.API.OrderModule.Models;
using BreweryMaster.API.User.Models.Users.DB;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BreweryMaster.API.Work.Models.DB
{
    public class KanbanTask
    {
        public int Id { get; set; }
        [MaxLength(255)]
        public required string Title { get; set; }
        public string? Summary { get; set; }
        public int StatusId { get; set; }
        [JsonIgnore]
        public required TaskStatusEntity Status { get; set; }
        public DateTime DueDate { get; set; }
        [MaxLength(450)]
        public required string CreatedById { get; set; }
        [JsonIgnore]
        public required ApplicationUser CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        [MaxLength(450)]
        public string? AssignedToId { get; set; }
        [JsonIgnore]
        public ApplicationUser? AssignedTo { get; set; }
        public int? OrderId { get; set; }
        [JsonIgnore]
        public Order? Order { get; set; }
    }
}
