using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    /// <summary>
    /// Customer entity
    /// </summary>
    public class Customer : Base
    {
        /// <summary>
        /// Customer Name and Surname
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Customer Phone Number
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Customer Email
        /// </summary>
        public string Email { get; set; }

        public static void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().Property(property => property.Name).HasMaxLength(11);

            modelBuilder.Entity<Customer>().Property(property => property.Phone).HasMaxLength(30);

            modelBuilder.Entity<Customer>().Property(property => property.Email).HasMaxLength(100);
        }
    }
}
