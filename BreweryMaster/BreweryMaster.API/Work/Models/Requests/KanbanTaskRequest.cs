using BreweryMaster.API.SharedModule.Validators;
using System.ComponentModel.DataAnnotations;

namespace BreweryMaster.API.Work.Models
{
    public class KanbanTaskRequest
    {
        [Required]
        [MaxLength(255)]
        public required string Title { get; set; }

        public string? Summary { get; set; }

        [DateTimeRequired]
        public required DateTime DueDate { get; set; }
    }
}
