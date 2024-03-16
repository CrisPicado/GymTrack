using Domain.Equipments;
using Domain.Routines;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exercises
{
    public class Exercise
    {
        public Exercise()
        {
            
        }

        public static Exercise Create(int id, string name, string targetZone, int? sets, int? repeats, double? weight, List<Equipment> equipments)
        {
            return new Exercise
            {
                Id = id,
                Name = name,
                TargetZone = targetZone,
                Sets = sets,
                Repeats = repeats,
                Weight = weight,
                Equipments = equipments,
                Routines = new List<Routine>()
            };     
        }

        public static Exercise Create(int id, Exercise exercise)
        {
            return new Exercise
            {
                Id = id,
                Name = exercise.Name,
                TargetZone = exercise.TargetZone,
                Sets = exercise.Sets,
                Repeats = exercise.Repeats,
                Weight = exercise.Weight,
                Equipments = exercise.Equipments,
                Routines = new List<Routine>()
            };
        }

        [Key]
        public int Id {  get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string TargetZone { get; set; }

        public int? Sets { get; set; }

        public int? Repeats { get; set; }

        public double? Weight { get; set; }

        public int? DurationInSeconds { get; set; }

        public List<Equipment> Equipments { get; set; }

        public List<Routine> Routines { get; set; } 
    }
}
