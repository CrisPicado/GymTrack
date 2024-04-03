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
        public int Id { get; set; }

        [Required]
        [JsonInclude]
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [Required]
        [JsonInclude]
        [JsonPropertyName("targetZone")]
        public string TargetZone { get; set; }

        [JsonInclude]
        [JsonPropertyName("sets")]
        public int? Sets { get; set; }

        [JsonInclude]
        [JsonPropertyName("repeats")]
        public int? Repeats { get; set; }

        [JsonInclude]
        [JsonPropertyName("weight")]
        public double? Weight { get; set; }

        [JsonIgnore]
        [JsonPropertyName("equipmentId")]
        public int EquipmentId { get; set; }

        [JsonInclude]
        [JsonPropertyName("equipment")]
        public Equipment Equipment { get; set; }

        [JsonIgnore]
        public virtual List<Routine> Routines { get; set; }
    }
}
