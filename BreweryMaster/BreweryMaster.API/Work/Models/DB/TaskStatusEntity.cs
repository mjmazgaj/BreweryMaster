using System.ComponentModel.DataAnnotations;

namespace BreweryMaster.API.Work.Models.DB
{
    public class TaskStatusEntity
    {
        public int Id { get; set; }

        [MaxLength(255)]
        public required string Name { get; set; }
    }
}
