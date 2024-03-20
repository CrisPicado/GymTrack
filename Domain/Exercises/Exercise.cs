using Domain.Equipments;
using Domain.Routines;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Exercises
{
    public class Exercise : Entity
    {
        public Exercise()
        {
            
        }

        public static Exercise Create(int id, string name, string targetZone, int? sets, int? repeats, double? weight, int equipmentId)
        {
            return new Exercise
            {
                Id = id,
                Name = name,
                TargetZone = targetZone,
                Sets = sets,
                Repeats = repeats,
                Weight = weight,
                EquipmentId = equipmentId
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
                EquipmentId = exercise.EquipmentId
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

        public int EquipmentId { get; set; }

        [JsonIgnore]
        public virtual Equipment Equipment { get; set; }

        [JsonIgnore]
        public virtual List<Routine> Routines { get; set; } 
    }
}
