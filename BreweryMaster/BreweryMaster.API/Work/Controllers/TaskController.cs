using BreweryMaster.API.SharedModule.Validators;
using BreweryMaster.API.Work.Models;
using BreweryMaster.API.Work.Models.Requests;
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
        private readonly IOrderService _orderService;

        public TaskController(ITaskService taskService, IOrderService orderService)
        {
            _taskService = taskService;
            _orderService = orderService;
        }

        [HttpGet]
        [Authorize(Roles = "employee")]
        [ProducesResponseType(typeof(Dictionary<string, KanbanTaskGroupResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<Dictionary<string, KanbanTaskGroupResponse>>?> GetKanbanTasksByOwnerId([FromQuery] KanbanTaskFilterRequest? request)
        {
            var tasks = await _taskService.GetKanbanTasksByOwnerIdAsync(request);
            return Ok(tasks);
        }

        [HttpGet]
        [Route("{id:int}")]
        [Authorize(Roles = "employee")]
        [ProducesResponseType(typeof(KanbanTaskResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<KanbanTaskResponse>> GetKanbanTaskById([MinIntValidation] int id)
        {
            var task = await _taskService.GetKanbanTaskByIdAsync(id);

            if (task == null)
                return NotFound();

            return Ok(task);
        }

        [HttpPost]
        [Authorize(Roles = "brewer,supervisor")]
        [ProducesResponseType(typeof(KanbanTaskResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<KanbanTaskResponse>> CreateKanbanTask([FromBody] KanbanTaskRequest kanbanTask)
        {
            var userIdentity = HttpContext?.User?.Identity;

            if (userIdentity is null || !userIdentity.IsAuthenticated)
                return Unauthorized();

            var createdTask = await _taskService.CreateKanbanTaskAsync(kanbanTask, HttpContext?.User);

            if (createdTask == null)
                return Unauthorized();

            return CreatedAtAction(nameof(GetKanbanTaskById), new { id = createdTask.Id }, createdTask);
        }

        [HttpPost]
        [Route("Template")]
        [Authorize(Roles = "brewer,supervisor")]
        [ProducesResponseType(typeof(IEnumerable<KanbanTaskResponse>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<IEnumerable<KanbanTaskResponse>>> CreateKanbanTaskTemplates(KanbanTaskTemplateRequest request)
        {
            var userIdentity = HttpContext?.User?.Identity;

            if (userIdentity is null || !userIdentity.IsAuthenticated)
                return Unauthorized();

            var createdTasks = await _taskService.CreateKanbanTaskTemplates(request, HttpContext?.User);

            if (createdTasks == null)
                return Unauthorized();

            return Ok(createdTasks);
        }

        [HttpPatch]
        [Route("{id:int}")]
        [Authorize(Roles = "brewer,supervisor")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<ActionResult> EditKanbanTask([MinIntValidation] int id, [FromBody] KanbanTaskUpdateRequest kanbanTask)
        {
            var isUpdated = await _taskService.EditKanbanTaskAsync(id, kanbanTask);

            if (!isUpdated)
                return NotFound();

            return Ok(isUpdated);
        }

        [HttpPatch]
        [Route("EditStatus")]
        [Authorize(Roles = "employee")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<ActionResult> EditKanbanTaskStatus([FromBody] List<KanbanTaskStatusRequest> request)
        {
            var isUpdated = await _taskService.EditKanbanTaskStatusAsync(request);

            if (!isUpdated)
                return NotFound();

            return Ok(isUpdated);
        }

        [HttpPatch]
        [Route("Delete/{id:int}")]
        [Authorize(Roles = "brewer,supervisor")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteKanbanTaskById([MinIntValidation] int id)
        {
            var isDeleted = await _taskService.DeleteKanbanTaskByIdAsync(id);

            if (!isDeleted)
                return NotFound();

            return Ok(isDeleted);
        }
    }
}
