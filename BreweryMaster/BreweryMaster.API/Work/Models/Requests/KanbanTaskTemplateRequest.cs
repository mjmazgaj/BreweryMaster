using BreweryMaster.API.Configuration.Enums;
using BreweryMaster.API.SharedModule.Validators;
using System.ComponentModel.DataAnnotations;

namespace BreweryMaster.API.Work.Models.Requests
{
    public class KanbanTaskTemplateRequest
    {
        [Required]
        [MinIntValidation]
        public int OrderId { get; set; }

        [Required]
        [EnumDataType(typeof(OrderStatus))]
        public OrderStatus? OrderStatus { get; set; }
    }
}
