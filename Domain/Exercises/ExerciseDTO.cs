using Domain.Equipments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exercises
{
    public class ExerciseDTO
    {
        public ExerciseDTO(int id, string name, string targetZone, int? sets, int? repeats, double? weight, int equipmentId, Equipment equipment)
        {
            Id = id;
            Name = name;
            TargetZone = targetZone;
            Sets = sets;
            Repeats = repeats;
            Weight = weight;
            EquipmentId = equipmentId;
            Equipment = equipment;

        }

        public int Id { get; private set; }

        public string Name { get; set; }

        public string TargetZone {  get; set; }

        public int? Sets { get; set; }

        public int? Repeats { get; set; }

        public double? Weight { get; set; }

        public int EquipmentId { get; set; }

        public Equipment Equipment { get; set; }
    }
}
