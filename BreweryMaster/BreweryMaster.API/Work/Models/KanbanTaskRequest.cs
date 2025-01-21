using BreweryMaster.API.OrderModule.Models;
using BreweryMaster.API.User.Models.Users.DB;
using BreweryMaster.API.Work.Models.DB;

namespace BreweryMaster.API.Work.Models
{
    public class KanbanTaskRequest
    {
        public required string Title { get; set; }
        public string? Summary { get; set; }
        public int Status { get; set; }
        public DateTime DueDate { get; set; }
        public required string CreatedById { get; set; }
        public DateTime CreatedOn { get; set; }
        public string? AssignedToId { get; set; }
        public int OrderId { get; set; }
    }
}
