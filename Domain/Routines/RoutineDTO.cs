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
    public class RoutineDTO : Entity
    {
        public RoutineDTO() { }

        public RoutineDTO(int id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int SequenceNumber { get; set; }

        public int CoachId { get; set; }
        public Coach Coach { get; set; }

        public int ClientId { get; set; }
        public Client Client { get; set; }

        public List<Exercise> Exercises { get; set; }

    }
}
