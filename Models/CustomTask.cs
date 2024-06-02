using System;

namespace TrilhaApiDesafio.Models
{
    /// <summary>
    /// Represents a custom task.
    /// </summary>
    public class CustomTask
    {
        /// <summary>
        /// Gets or sets the ID of the task.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the title of the task.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the description of the task.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the date of the task.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Gets or sets the status of the task.
        /// </summary>
        public EnumCustomTaskStatus Status { get; set; }
    }
}

