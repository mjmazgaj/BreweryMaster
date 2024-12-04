using BreweryMaster.API.Work.Models;
using BreweryMaster.API.Work.Models.Dtos;
using BreweryMaster.API.Work.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BreweryMaster.API.Work.Controllers
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
        [ProducesResponseType(typeof(IEnumerable<KanbanTask>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<KanbanTask>>> GetKanbanTasksByOwnerId(int ownerId)
        {
            var tasks = await _taskService.GetKanbanTasksByOwnerIdAsync(ownerId);

            if (tasks == null || !tasks.Any())
                return NotFound();

            return Ok(tasks);
        }

        [HttpGet]
        [Route("ByOrderId")]
        [ProducesResponseType(typeof(IEnumerable<KanbanTask>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<KanbanTask>>> GetKanbanTasksByOrderId(int orderId)
        {
            var tasks = await _taskService.GetKanbanTasksByOrderIdAsync(orderId);

            if (tasks == null || !tasks.Any())
                return NotFound();

            return Ok(tasks);
        }

        [HttpGet]
        [Route("{id:int}")]
        [ProducesResponseType(typeof(KanbanTask), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<KanbanTask>> GetKanbanTaskById(int id)
        {
            var task = await _taskService.GetKanbanTaskByIdAsync(id);

            if (task == null)
                return NotFound();

            return Ok(task);
        }

        [HttpPost]
        [ProducesResponseType(typeof(KanbanTask), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<KanbanTask>> CreateKanbanTask([FromBody] KanbanTask kanbanTask)
        {
            var createdTask = await _taskService.CreateKanbanTaskAsync(kanbanTask);
            return CreatedAtAction(nameof(GetKanbanTaskById), new { id = createdTask.Id }, createdTask);
        }

        [HttpPut]
        [Route("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> EditKanbanTask(int id, [FromBody] KanbanTask kanbanTask)
        {
            if (!await _taskService.EditKanbanTaskAsync(id, kanbanTask))
                return NotFound();

            return Ok();
        }

        [HttpPut]
        [Route("EditStatus")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> EditKanbanTaskStatus([FromBody] List<KanbanTaskStatusSaveRequest> request)
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
