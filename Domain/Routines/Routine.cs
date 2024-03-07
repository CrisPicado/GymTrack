using Domain.Clients;
using Domain.Coaches;
using Domain.Exercises;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Routines
{
    public class Routine
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int Sets {  get; set; }

        [Required]
        public int Repeats { get; set; }

        [Required]
        public double Weight { get; set; }

        [Required]
        public double Height { get; set; }

        [Required]
        public TimeSpan Duration { get; set; }

        public List<Client> Clients { get; set; }

        public List<Coach> Coaches { get; set; }

        public List<Exercise> Exercises { get; set; }
    }
}
