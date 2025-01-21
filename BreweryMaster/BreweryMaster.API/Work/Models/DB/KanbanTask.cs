using BreweryMaster.API.OrderModule.Models;
using BreweryMaster.API.User.Models.Users.DB;

namespace BreweryMaster.API.Work.Models.DB
{
    public class KanbanTask
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public string? Summary { get; set; }
        public required TaskStatusEntity Status { get; set; }
        public int StatusId { get; set; }
        public DateTime DueDate { get; set; }
        public required string CreatedById { get; set; }
        public required ApplicationUser CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string? AssignedToId { get; set; }
        public ApplicationUser? AssignedTo { get; set; }
        public int? OrderId { get; set; }
        public Order? Order { get; set; }
    }
}
