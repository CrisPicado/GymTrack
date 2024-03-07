using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contexts
{
    public interface IApplicationDbContext
    {
        DbSet<Entrenador> Entrenador { get; set; }
        DbSet<Rutina> Rutina { get; set; }
        DbSet<Usuarios> Usuarios { get; set; }
        DbSet<Ejercicio> Ejercicios { get; set; }
        void Save();
    }
}
