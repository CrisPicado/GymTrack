using Domain.Exercises;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Equipments
{
    public class Equipment : Entity
    {

        public Equipment()
        {

        }

        public static Equipment Create(int id, string name, string description)
        {
            return new()
            {
                Id = id,
                Name = name,
                Description = description
            };
        }

        public static Equipment Create(int id, Equipment equipment)
        {
            return new()
            {
                Id = id,
                Name = equipment.Name,
                Description = equipment.Description
            };
        }

        [Key]
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(40, MinimumLength = 2)]
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(100, MinimumLength = 2)]
        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonIgnore]
        public virtual List<Exercise> Exercises { get; set; }
    }
}
