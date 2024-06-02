using Microsoft.AspNetCore.Mvc;
using TrilhaApiDesafio.Context;
using TrilhaApiDesafio.Models;

namespace TrilhaApiDesafio.Controllers
{
    /// <summary>
    /// Controller for managing custom tasks.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class CustomTaskController : ControllerBase
    {
        private readonly OrganizerContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomTaskController"/> class.
        /// </summary>
        /// <param name="context">The database context.</param>
        public CustomTaskController(OrganizerContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retrieves a custom task by its ID.
        /// </summary>
        /// <param name="id">The ID of the custom task.</param>
        /// <returns>Returns IActionResult containing the custom task with the specified ID.</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var customTask = _context.CustomTasks.Find(id);

            if (customTask == null)
                return NotFound();
            else
                return Ok(customTask);
        }

        /// <summary>
        /// Retrieves all custom tasks.
        /// </summary>
        /// <returns>Returns IActionResult containing all custom tasks.</returns>
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var customTasks = _context.CustomTasks.ToList();

            return Ok(customTasks);
        }

        /// <summary>
        /// Retrieves custom tasks by title.
        /// </summary>
        /// <param name="title">The title to search for.</param>
        /// <returns>Returns IActionResult containing custom tasks that match the specified title.</returns>
        [HttpGet("GetByTitle")]
        public IActionResult GetByTitle(string title)
        {
            var customTasks = _context.CustomTasks.Where(x => x.Title.Contains(title));
            return Ok(customTasks);
        }

        /// <summary>
        /// Retrieves custom tasks by date.
        /// </summary>
        /// <param name="date">The date to search for.</param>
        /// <returns>Returns IActionResult containing custom tasks that match the specified date.</returns>
        [HttpGet("GetByDate")]
        public IActionResult GetByDate(DateTime date)
        {
            var customTasks = _context.CustomTasks.Where(x => x.Date.Date == date.Date);
            return Ok(customTasks);
        }

        /// <summary>
        /// Retrieves custom tasks by status.
        /// </summary>
        /// <param name="status">The status to search for.</param>
        /// <returns>Returns IActionResult containing custom tasks that match the specified status.</returns>
        [HttpGet("GetByStatus")]
        public IActionResult GetByStatus(EnumCustomTaskStatus status)
        {
            var customTasks = _context.CustomTasks.Where(x => x.Status == status);
            return Ok(customTasks);
        }

        /// <summary>
        /// Creates a new custom task.
        /// </summary>
        /// <param name="customTask">The custom task to create.</param>
        /// <returns>Returns IActionResult containing the created custom task.</returns>
        [HttpPost]
        public IActionResult Create(CustomTask customTask)
        {
            if (customTask.Date == DateTime.MinValue)
                return BadRequest(new { Error = "Custom task date cannot be empty" });

            _context.Add(customTask);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = customTask.Id }, customTask);
        }

        /// <summary>
        /// Updates an existing custom task.
        /// </summary>
        /// <param name="id">The ID of the custom task to update.</param>
        /// <param name="customTask">The updated custom task data.</param>
        /// <returns>Returns IActionResult containing the updated custom task.</returns>
        [HttpPut("{id}")]
        public IActionResult Update(int id, CustomTask customTask)
        {
            var existingCustomTask = _context.CustomTasks.Find(id);

            if (existingCustomTask == null)
                return NotFound();

            if (customTask.Date == DateTime.MinValue)
                return BadRequest(new { Error = "Custom task date cannot be empty" });

            existingCustomTask.Title = customTask.Title;
            existingCustomTask.Description = customTask.Description;
            existingCustomTask.Date = customTask.Date;
            existingCustomTask.Status = customTask.Status;

            _context.CustomTasks.Update(existingCustomTask);
            _context.SaveChanges();
            return Ok(existingCustomTask);
        }

        /// <summary>
        /// Deletes a custom task by its ID.
        /// </summary>
        /// <param name="id">The ID of the custom task to delete.</param>
        /// <returns>Returns IActionResult indicating the result of the delete operation.</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existingCustomTask = _context.CustomTasks.Find(id);

            if (existingCustomTask == null)
                return NotFound();

            _context.CustomTasks.Remove(existingCustomTask);
            _context.SaveChanges();

            return NoContent();
        }
    }
}

