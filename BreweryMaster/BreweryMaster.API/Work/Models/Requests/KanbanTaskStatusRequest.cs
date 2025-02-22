using BreweryMaster.API.SharedModule.Validators;
using System.ComponentModel.DataAnnotations;

namespace BreweryMaster.API.Work.Models
{
    public class KanbanTaskStatusRequest
    {
        [Required]
        [MinIntValidation]
        public int Id { get; set; }

        [Required]
        [MinIntValidation]
        public int Status { get; set; }
    }
}
