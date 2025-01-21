using BreweryMaster.API.Work.Models;
using BreweryMaster.API.WorkModule.Models;
using BreweryMaster.API.WorkModule.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BreweryMaster.API.WorkModule.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet]
        [Authorize]
        [Route("ByOwnerId")]
        [ProducesResponseType(typeof(IEnumerable<KanbanTaskResponse>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<KanbanTaskResponse>>> GetKanbanTasksByOwnerId(string ownerId)
        {
            var tasks = await _taskService.GetKanbanTasksByOwnerIdAsync(ownerId);
            return Ok(tasks);
        }

        [HttpGet]
        [Route("ByOrderId")]
        [ProducesResponseType(typeof(IEnumerable<KanbanTaskResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<KanbanTaskResponse>>> GetKanbanTasksByOrderId(int orderId)
        {
            var tasks = await _taskService.GetKanbanTasksByOrderIdAsync(orderId);

            if (tasks == null || !tasks.Any())
                return NotFound();

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
            var createdTask = await _taskService.CreateKanbanTaskAsync(kanbanTask);
            return CreatedAtAction(nameof(GetKanbanTaskById), new { id = createdTask.Id }, createdTask);
        }

        [HttpPut]
        [Route("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> EditKanbanTask(int id, [FromBody] KanbanTaskUpdateRequest kanbanTask)
        {
            if (!await _taskService.EditKanbanTaskAsync(id, kanbanTask))
                return NotFound();

            return Ok();
        }

        [HttpPut]
        [Route("EditStatus")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> EditKanbanTaskStatus([FromBody] List<KanbanTaskStatusRequest> request)
        {
            if (!await _taskService.EditKanbanTaskStatusAsync(request))
                return BadRequest();

            return Ok();
        }

        [HttpDelete]
        [Route("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteKanbanTaskById(int id)
        {
            if (!await _taskService.DeleteKanbanTaskByIdAsync(id))
                return NotFound();

            return Ok();
        }
    }
}
