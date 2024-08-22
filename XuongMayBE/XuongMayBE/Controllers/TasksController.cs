using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XuongMayBE.Data;
using XuongMayBE.Repositories;

namespace XuongMayBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IProductionLineRepository _productionLineRepository;
        private readonly ILogger<TasksController> _logger;

        public TasksController(ITaskRepository taskRepository, IProductionLineRepository productionLineRepository, ILogger<TasksController> logger)
        {
            _taskRepository = taskRepository;
            _productionLineRepository = productionLineRepository;
            _logger = logger;
        }

        // GET: api/Tasks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskDTO>>> GetTasks()
        {
            try
            {
                var tasks = await _taskRepository.GetAllAsync();
                var taskDTOs = tasks.Select(t => new TaskDTO
                {
                    TaskID = t.TaskID,
                    TaskName = t.TaskName,
                    LineID = t.LineID
                });
                return Ok(taskDTOs);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching tasks");
                return StatusCode(500, "An error occurred while processing your request");
            }
        }

        // GET: api/Tasks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TaskDTO>> GetTask(int id)
        {
            try
            {
                var task = await _taskRepository.GetByIdAsync(id);
                if (task == null)
                {
                    return NotFound();
                }

                var taskDTO = new TaskDTO
                {
                    TaskID = task.TaskID,
                    TaskName = task.TaskName,
                    LineID = task.LineID
                };

                return Ok(taskDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while fetching task with id {id}");
                return StatusCode(500, "An error occurred while processing your request");
            }
        }

        // POST: api/Tasks
        [HttpPost]
        public async Task<ActionResult<TaskDTO>> CreateTask(TaskDTO taskDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                // Kiểm tra xem ProductionLine có tồn tại không
                var productionLine = await _productionLineRepository.GetByIdAsync(taskDTO.LineID);
                if (productionLine == null)
                {
                    ModelState.AddModelError("LineID", "ProductionLine không tồn tại");
                    return BadRequest(ModelState);
                }

                var task = new Tasks
                {
                    TaskName = taskDTO.TaskName,
                    LineID = taskDTO.LineID
                };

                await _taskRepository.AddAsync(task);

                taskDTO.TaskID = task.TaskID;

                return CreatedAtAction(nameof(GetTask), new { id = task.TaskID }, taskDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while creating a new task");
                return StatusCode(500, "An error occurred while processing your request");
            }
        }

        // PUT: api/Tasks/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTask(int id, TaskDTO taskDTO)
        {
            if (id != taskDTO.TaskID)
            {
                return BadRequest("ID mismatch");
            }

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var existingTask = await _taskRepository.GetByIdAsync(id);
                if (existingTask == null)
                {
                    return NotFound();
                }

                // Kiểm tra xem ProductionLine có tồn tại không
                var productionLine = await _productionLineRepository.GetByIdAsync(taskDTO.LineID);
                if (productionLine == null)
                {
                    ModelState.AddModelError("LineID", "ProductionLine không tồn tại");
                    return BadRequest(ModelState);
                }

                existingTask.TaskName = taskDTO.TaskName;
                existingTask.LineID = taskDTO.LineID;

                await _taskRepository.UpdateAsync(existingTask);

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while updating task with id {id}");
                return StatusCode(500, "An error occurred while processing your request");
            }
        }

        // DELETE: api/Tasks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            try
            {
                var task = await _taskRepository.GetByIdAsync(id);
                if (task == null)
                {
                    return NotFound();
                }

                await _taskRepository.DeleteAsync(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while deleting task with id {id}");
                return StatusCode(500, "An error occurred while processing your request");
            }
        }
    }
}