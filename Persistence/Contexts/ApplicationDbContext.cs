using Application.Contexts;
using Domain.Clients;
using Domain.Coaches;
using Domain.Exercises;
using Domain.Equipments;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Routines;

namespace Persistence.Contexts
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options) { }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Coach> Coaches { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<Routine> Routines { get; set; }

        public void Save()
        {
            this.SaveChanges();
        }

    }
}
