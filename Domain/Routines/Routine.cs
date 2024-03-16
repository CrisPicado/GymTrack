using Domain.Clients;
using Domain.Coaches;
using Domain.Exercises;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Domain.Routines
{
    public class Routine
    {
        public Routine()
        {
            
        }

        public static Routine Create(int id, string name, string description, int sequenceNumber, List<Exercise> exercises)
        {
            return new()
            {
                Id = id,
                Name = name,
                Description = description,
                SequenceNumber = sequenceNumber,
                Exercises = exercises
            };

        }

        public static Routine Create(int id, string name, string description, int sequenceNumber, List<Exercise> exercises, List<Client> clients, Coach coach)
        {
            return new Routine
            {
                Id = id,
                Name = name,
                Description = description,
                SequenceNumber = sequenceNumber,
                Exercises = exercises,
                Clients = clients,
                CoachId = coach.Id,
                Coach = coach
            };
        }

        public static Routine Create(int id, Routine routine)
        {
            return new Routine
            {
                Id = id,
                Name = routine.Name,
                Description = routine.Description,
                SequenceNumber = routine.SequenceNumber,
                Exercises = routine.Exercises,
                Clients = routine.Clients,
                CoachId = routine.Coach.Id,
                Coach = routine.Coach
            };
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int SequenceNumber { get; set; }

        public int CoachId { get; set; }
        public Coach Coach { get; set; }

        public List<Client> Clients { get; set; }

        public List<Coach> Coaches { get; set; }

        public List<Exercise> Exercises { get; set; }
    }
}
