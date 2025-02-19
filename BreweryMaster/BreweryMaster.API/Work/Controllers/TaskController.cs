using BreweryMaster.API.OrderModule.Models;
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
        private readonly IOrderService _orderService;

        public TaskController(ITaskService taskService, IOrderService orderService)
        {
            _taskService = taskService;
            _orderService = orderService;
        }

        [HttpGet]
        [Authorize]
        [Route("ByOwnerId")]
        [ProducesResponseType(typeof(IEnumerable<KanbanTaskResponse>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<KanbanTaskResponse>>> GetKanbanTasksByOwnerId()
        {
            var tasks = await _taskService.GetKanbanTasksByOwnerIdAsync(HttpContext.User);
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
            var createdTask = await _taskService.CreateKanbanTaskAsync(kanbanTask, HttpContext.User);
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

        [HttpPost]
        [Route("AddTestTasks")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> AddTestTasks()
        {
            try
            {
                var order = new OrderRequest()
                {
                    Capacity = 10,
                    ContainerId = 1,
                    RecipeId = 1,
                    TargetDate = DateTime.Now.AddDays(2),
                };

                var createdOrder = await _orderService.CreateOrderAsync(order, HttpContext.User);

                var kanbanTask = new KanbanTaskRequest()
                {
                    Title = "test title",
                    Summary = "test Summary",
                    StatusId = 1,
                    DueDate = DateTime.Now.AddDays(3),
                    AssignedToId = null,
                    OrderId = createdOrder.Id,
                };

                var createdTask = await _taskService.CreateKanbanTaskAsync(kanbanTask, HttpContext.User);
                return Ok(createdTask);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
