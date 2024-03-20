using Domain.Clients;
using Domain.Coaches;
using Domain.Exercises;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Domain.Routines
{
    public class Routine : Entity
    {
        public Routine()
        {
            
        }

        //public static Routine Create(int id, string name, string description, int sequenceNumber, List<Exercise> exercises)
        //{
        //    return new()
        //    {
        //        Id = id,
        //        Name = name,
        //        Description = description,
        //        SequenceNumber = sequenceNumber,
        //        Exercises = exercises
        //    };

        //}

        public static Routine Create(int id, string name, string description, int sequenceNumber, int coachId,  int clientId)
        {
            return new Routine
            {
                Id = id,
                Name = name,
                Description = description,
                SequenceNumber = sequenceNumber,
                CoachId = coachId,
                ClientId = clientId,

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
                ClientId = routine.ClientId,
                CoachId = routine.CoachId
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
        [JsonIgnore]
        public virtual Coach Coach { get; set; }

        public int ClientId { get; set; }
        [JsonIgnore]
        public virtual Client Client { get; set; }

        public virtual List<Exercise> Exercises { get; set; }
    }
}
