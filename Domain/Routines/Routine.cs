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
                ClientId = clientId

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
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 100 characters")]
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [StringLength(255, MinimumLength = 10, ErrorMessage = "Description must be between 10 and 255 characters")]
        [JsonPropertyName("description")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Sequence number is required")]
        [JsonPropertyName("sequenceNumber")]
        public int SequenceNumber { get; set; }

        [JsonPropertyName("coachId")]
        public int CoachId { get; set; }

        //[JsonIgnore]
        [JsonPropertyName("coach")]
        public virtual Coach Coach { get; set; }

        [JsonPropertyName("clientId")]
        public int ClientId { get; set; }

        //[JsonIgnore]
        [JsonPropertyName("client")]
        public virtual Client Client { get; set; }

        [JsonPropertyName("exercises")]
        public virtual List<Exercise> Exercises { get; set; }
    }
}
