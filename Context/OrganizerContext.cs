using Microsoft.EntityFrameworkCore;
using TrilhaApiDesafio.Models;

namespace TrilhaApiDesafio.Context
{
    /// <summary>
    /// Represents the database context for organizers.
    /// </summary>
    public class OrganizerContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OrganizerContext"/> class.
        /// </summary>
        /// <param name="options">The options for this context.</param>
        public OrganizerContext(DbContextOptions<OrganizerContext> options) : base(options)
        {

        }

        /// <summary>
        /// Gets or sets the DbSet of custom tasks.
        /// </summary>
        public DbSet<CustomTask> CustomTasks { get; set; }
    }
}

