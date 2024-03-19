using Domain.Clients;
using Domain.Coaches;
using Domain.Equipments;
using Domain.Exercises;
using Domain.Routines;
using Microsoft.EntityFrameworkCore;


namespace Application.Contexts
{
    public interface IApplicationDbContext
    {

        DbSet<Client> Clients { get; set; }
        DbSet<Coach> Coaches { get; set; }
        //DbSet<Equipment> Equipments { get; set; }
        DbSet<Exercise> Exercises { get; set; }
        //DbSet<Routine> Routines { get; set; }

        void Save();
    }
}
