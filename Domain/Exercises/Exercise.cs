using Domain.Equipments;
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

        public static Exercise Create( int id, string name, string workzone)
        {
            return new()
            {
                Id = id,
                Name = name,
                WorkZone = workzone
            };     
        }

        public static Exercise Create(int id, Exercise exercise)
        {
            return new()
            {
                Id = id,
                Name = exercise.Name,
                WorkZone = exercise.WorkZone
            };
        }

        [Key]
        public int Id {  get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string WorkZone { get; set; }

        public List<Equipment> Equipments { get; private set; }
    }
}
