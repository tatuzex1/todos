using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Todo.Domain.Entities;

namespace Todo.Domain.Infra.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {           
        }

        public DbSet<TodoItem> Todos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TodoItem>().Property(td => td.Id);
            modelBuilder.Entity<TodoItem>()
                        .Property(td => td.User)
                        .HasMaxLength(120);

            modelBuilder.Entity<TodoItem>()
                        .Property(td => td.Title)
                        .HasMaxLength(160);
                        


        }
    }
}
