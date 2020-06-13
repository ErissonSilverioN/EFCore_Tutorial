using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using EFCoreTutorials.Models;

namespace EFCoreTutorials.DAL
{
    class Contexto : DbContext
    {
        public DbSet<Student> students { get; set; }
        public DbSet<Course> courses { get; set; }
        public DbSet<Teacher> teachers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS; Database=TutorialEFCoreDB; Trusted_Connection=True;");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
