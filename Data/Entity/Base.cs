using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    /// <summary>
    /// Base entity
    /// Must be extended by all entities
    /// </summary>
    public abstract class Base : IBase
    {
        /// <summary>
        /// Id of each entity
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Created Date of each entity
        /// </summary>
        public DateTimeOffset CreatedDate { get; set; }

        /// <summary>
        /// Deleted date of each entity
        /// </summary>
        public DateTimeOffset? IsDeleted { get; set; }

        public static void OnModelCreating<TEntity>(ModelBuilder modelBuilder)
        where TEntity : class, IBase
        {
            modelBuilder.Entity<TEntity>().HasKey(entity => entity.Id);
        }
    }
}
