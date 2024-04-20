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
using Application.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Domain.Authorization;

namespace Infrastructure.Contexts
{
    public class ApplicationIdentityDbContext : IdentityDbContext, IApplicationIdentityDbContext
    {

        public ApplicationIdentityDbContext(DbContextOptions<ApplicationIdentityDbContext> options) 
            : base(options) 
        {

        }
        public DbSet<Permission> Permissions { get; set; }

    }
}
