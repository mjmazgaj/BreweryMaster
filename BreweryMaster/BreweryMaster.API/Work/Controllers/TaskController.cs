using BreweryMaster.API.Work.Models;
using BreweryMaster.API.Work.Models.Requests;
using BreweryMaster.API.WorkModule.Models;
using BreweryMaster.API.WorkModule.Services;
using Microsoft.AspNetCore.Mvc;

namespace BreweryMaster.API.WorkModule.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;
        private readonly IOrderService _orderService;

        public TaskController(ITaskService taskService, IOrderService orderService)
        {
            _taskService = taskService;
            _orderService = orderService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(Dictionary<string, KanbanTaskGroupResponse>), StatusCodes.Status200OK)]
        public async Task<ActionResult<Dictionary<string, KanbanTaskGroupResponse>>?> GetKanbanTasksByOwnerId([FromQuery] KanbanTaskFilterRequest? request)
        {
            var tasks = await _taskService.GetKanbanTasksByOwnerIdAsync(request);
            return Ok(tasks);
        }

        [HttpGet]
        [Route("{id:int}")]
        [ProducesResponseType(typeof(KanbanTaskResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<KanbanTaskResponse>> GetKanbanTaskById(int id)
        {
            var task = await _taskService.GetKanbanTaskByIdAsync(id);

            if (task == null)
                return NotFound();

            return Ok(task);
        }

        [HttpPost]
        [ProducesResponseType(typeof(KanbanTaskResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<KanbanTaskResponse>> CreateKanbanTask([FromBody] KanbanTaskRequest kanbanTask)
        {
            var createdTask = await _taskService.CreateKanbanTaskAsync(kanbanTask, HttpContext.User);

            if (createdTask == null)
                return Unauthorized();

            return CreatedAtAction(nameof(GetKanbanTaskById), new { id = createdTask.Id }, createdTask);
        }

        [HttpPost]
        [Route("Template")]
        [ProducesResponseType(typeof(IEnumerable<KanbanTaskResponse>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<KanbanTaskResponse>>> CreateKanbanTaskTemplates(KanbanTaskTemplateRequest request)
        {
            var createdTasks = await _taskService.CreateKanbanTaskTemplates(request, HttpContext.User);

            if (createdTasks == null)
                return Unauthorized();

            return Ok(createdTasks);
        }

        [HttpPut]
        [Route("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> EditKanbanTask(int id, [FromBody] KanbanTaskUpdateRequest kanbanTask)
        {
            var isUpdated = await _taskService.EditKanbanTaskAsync(id, kanbanTask);

            if (!isUpdated)
                return BadRequest();

            return Ok(isUpdated);
        }

        [HttpPut]
        [Route("EditStatus")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> EditKanbanTaskStatus([FromBody] List<KanbanTaskStatusRequest> request)
        {
            var isUpdated = await _taskService.EditKanbanTaskStatusAsync(request);

            if (!isUpdated)
                return BadRequest();

            return Ok(isUpdated);
        }

        [HttpDelete]
        [Route("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteKanbanTaskById(int id)
        {
            var isDeleted = await _taskService.DeleteKanbanTaskByIdAsync(id);

            if (!isDeleted)
                return BadRequest();

            return Ok(isDeleted);
        }
    }
}
