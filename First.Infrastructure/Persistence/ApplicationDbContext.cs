using First.Application.Abstractions;
using First.Domain.Tables.Models;
using First.Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options)
        {
            Database.Migrate();
        }

        public DbSet<Student> Students { get ; set; }
        public DbSet<Teacher> Teachers { get ; set ; }
        //public DbSet<Room> Rooms { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DbSet<Group> Groups { get ; set ; }
        public DbSet<Attendance> Attendances { get ; set ; }
        public DbSet<Faculty> Faculties { get ; set ; }
        public DbSet<User> Users { get ; set ; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.ApplyConfiguration(new StudentConfiguration());
            modelBuilder.ApplyConfiguration(new GroupConfiguration());
        }


        
    }
}
