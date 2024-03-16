using Domain.Exercises;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Equipments
{
    public class Equipment
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
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public List<Exercise> exercises { get; set; }
    }
}
