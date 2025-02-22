using BreweryMaster.API.SharedModule.Validators;
using System.ComponentModel.DataAnnotations;

namespace BreweryMaster.API.Work.Models
{
    public class KanbanTaskUpdateRequest : KanbanTaskRequest
    {
        [Required]
        [MinIntValidation]
        public int Id { get; set; }

        [MaxLength(450)]
        public string? AssignTo { get; set; }
    }
}
