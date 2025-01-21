using BreweryMaster.API.Work.Models.DB;

namespace BreweryMaster.API.Shared.Helpers
{
    public static class KanbanTaskDataProvider
    {
        public static IEnumerable<KanbanTask> GetKanbanTasks()
        {
            return new List<KanbanTask>()
            {
                new()
                {
                    Id = 1,
                    Title = "title",
                    Summary = "",
                    Status = null!,
                    StatusId = 1,
                    DueDate= DateTime.Now.AddDays(3),
                    CreatedById = "880685e3-e9a9-43b0-a5e5-905d590634c5",
                    CreatedBy = null!,
                    CreatedOn = DateTime.Now,
                    AssignedToId = null,
                    AssignedTo = null,
                    OrderId = 1,
                    Order = null,
                },
                new()
                {
                    Id = 2,
                    Title = "title",
                    Summary = "",
                    Status = null!,
                    StatusId = 2,
                    DueDate= DateTime.Now.AddDays(2),
                    CreatedById = "f31c50a7-431c-4358-8fdc-bfa083cfacb7",
                    CreatedBy = null!,
                    CreatedOn = DateTime.Now,
                    AssignedToId = null,
                    AssignedTo = null,
                    OrderId = 2,
                    Order = null,
                }
            };
        }
    }
}
