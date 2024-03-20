using Domain.Clients;
using Domain.Coaches;
using Domain.Exercises;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Routines
{
    public class UpdateRoutine
    {
        public int Id {  get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int SequenceNumber { get; set; }

        public int CoachId { get; set; }

        public int ClientId { get; set; }

        public List<int> ExerciseIds { get; set; }
    }
}
