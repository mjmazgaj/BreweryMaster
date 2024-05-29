using BreweryMaster.API.Helpers.User;
using BreweryMaster.API.Mappers;
using BreweryMaster.API.Models.User;
using BreweryMaster.API.Models.Work;
using BreweryMaster.API.Validators;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace apiDoReacta.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly WorkDbContext _workDbContext;
        private readonly UserContext _userContext;
        public TaskController(WorkDbContext workDbContext, UserContext userContext)
        {
            _workDbContext = workDbContext;
            _userContext = userContext;
        }

        [HttpGet]
        [Route("ByOwnerId")]
        [ProducesResponseType(typeof(IEnumerable<KanbanTaskDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Dictionary<string, BreweryMaster.API.Models.Work.Column>>> GetKanbanTaskesByOwnerId(int ownerId)
        {
            if (_workDbContext.KanbanTasks == null)
                return NotFound();

            var tasks = await _workDbContext.KanbanTasks.Where(x => x.OwnerId == ownerId).ToListAsync();
            var owner = await _userContext.Employees.FirstOrDefaultAsync(x => x.ID == ownerId);

            var ownerName = string.Empty;

            if (owner != null)
                ownerName = UserHelper.GetFullName(owner.Forename, owner.Surname);

            var result = tasks.Select(x => KanbanTaskMapper.ToDto(x, ownerName));

            var columnsDictionary = Enum.GetValues(typeof(BreweryMaster.API.Models.Work.TaskStatus))
                .Cast<BreweryMaster.API.Models.Work.TaskStatus>()
                .ToDictionary(
                    status => Enum.GetName(typeof(BreweryMaster.API.Models.Work.TaskStatus), status),
                    status =>
                    {
                        var tasksForStatus = result.Where(t => (BreweryMaster.API.Models.Work.TaskStatus)t.Status == status).ToList();
                        return new BreweryMaster.API.Models.Work.Column
                        {
                            Title = $"Status {status}",
                            Status = (int)status,
                            Items = tasksForStatus
                        };
                    });

            return Ok(columnsDictionary);
        }

        [HttpGet]
        [Route("ByOrderId")]
        [ProducesResponseType(typeof(IEnumerable<KanbanTaskDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<KanbanTaskDto>>> GetKanbanTaskesByOrderId(int orderId)
        {
            if (_workDbContext.KanbanTasks == null)
                return NotFound();

            var tasks = await _workDbContext.KanbanTasks.Where(x => x.OrderId == orderId).ToListAsync();
            var owners = await _userContext.Employees.ToListAsync();

            var result = new List<KanbanTaskDto>();

            foreach (var task in tasks)
            {
                var ownerName = string.Empty;

                var owner = owners.FirstOrDefault(x => x.ID == task.OwnerId);

                if (owner != null)
                    ownerName = UserHelper.GetFullName(owner.Forename, owner.Surname);

                result.Add(KanbanTaskMapper.ToDto(task, ownerName));
            }

            return Ok(result);
        }

        [HttpGet]
        [Route("{id:int}")]
        [ProducesResponseType(typeof(KanbanTask), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<KanbanTask>> GetKanbanTaskById(int id)
        {
            if (_workDbContext.KanbanTasks == null)
                return NotFound();

            var kanbanTask = await _workDbContext.KanbanTasks.FirstOrDefaultAsync(x => x.ID == id);

            if (kanbanTask == null)
                return NotFound();

            return kanbanTask;
        }

        [HttpPost]
        [ProducesResponseType(typeof(KanbanTask), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<KanbanTask>> CreateKanbanTask([FromBody] KanbanTask kanbanTask)
        {
            var kanbanTaskToCreate = new KanbanTask()
            {
                Title = kanbanTask.Title,
                Summary = kanbanTask.Summary,
                Status = kanbanTask.Status,
                DueDate = kanbanTask.DueDate,
                OwnerId = kanbanTask.OwnerId,
                OrderId = kanbanTask.OrderId
            };

            _workDbContext.KanbanTasks.Add(kanbanTaskToCreate);
            await _workDbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetKanbanTaskById), new { id = kanbanTaskToCreate.ID }, kanbanTaskToCreate);
        }

        [HttpPut]
        [Route("{id:int}")]
        [ProducesResponseType(typeof(KanbanTask), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<KanbanTask>> EditKanbanTask(int id, [FromBody] KanbanTask kanbanTask)
        {
            if (id != kanbanTask.ID)
                return BadRequest();

            _workDbContext.Entry(kanbanTask).State = EntityState.Modified;

            try
            {
                await _workDbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                    return NotFound();
                else
                    throw;
            }

            return Ok();
        }

        [HttpPut]
        [Route("EditStatus")]
        [ProducesResponseType(typeof(KanbanTask), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<KanbanTask>> EditKanbanTaskStatus([FromBody] List<KanbanTaskStatusSaveRequest> request)
        {
            foreach (var item in request)
            {
                var task = await _workDbContext.KanbanTasks.FirstOrDefaultAsync(x => x.ID == item.ID);

                if (task != null)
                    task.Status = item.Status;
            }

            try
            {
                await _workDbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return Ok();
        }

        [HttpDelete]
        [Route("{id:int}")]
        [ProducesResponseType(typeof(KanbanTask), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<KanbanTask>> DeleteKanbanTaskById(int id)
        {
            if (_workDbContext.KanbanTasks == null)
                return NotFound();

            var kanbanTask = await _workDbContext.KanbanTasks.FirstOrDefaultAsync(x => x.ID == id);

            if (kanbanTask == null)
                return NotFound();

            _workDbContext.KanbanTasks.Remove(kanbanTask);
            await _workDbContext.SaveChangesAsync();

            return Ok();
        }

        private bool ProductExists(int id)
        {
            return _workDbContext.KanbanTasks.Any(x => x.ID == id);
        }
    }
}
