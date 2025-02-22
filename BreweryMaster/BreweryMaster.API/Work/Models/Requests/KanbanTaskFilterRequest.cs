using BreweryMaster.API.SharedModule.Validators;
using System.ComponentModel.DataAnnotations;

namespace BreweryMaster.API.Work.Models.Requests
{
    public class KanbanTaskFilterRequest
    {
        [MaxLength(450)]
        public string? CreatedById { get; set; }

        [MaxLength(450)]
        public string? AssignedToId { get; set; }

        [MinIntValidation(isNullAllowed: true)]
        public int? OrderId { get; set; }
    }
}
