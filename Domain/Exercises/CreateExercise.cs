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
    public class CreateExercise
    {
        public string Name { get; set; }

        public string TargetZone { get; set; }

        public int? Sets { get; set; }

        public int? Repeats { get; set; }

        public double? Weight { get; set; }

        public int EquipmentId { get; set; }

        public List<EquipmentDTO> AvailableEquipments { get; set; }

        //public List<Routine> Routines { get; set; }
    }
}
