﻿using Domain.Clients;
using Domain.Routines;
using Shared.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;


namespace Domain.Coaches
{
    public class Coach : Entity
    {
        public Coach()
        {

        }

        public static Coach Create(int id, string firstName, string lastName,
            string email, string phoneNumber, bool active)
        {
            return new()
            {
                Id = id,
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                PhoneNumber = phoneNumber,
                Active = active
            };
        }

        public static Coach Create(int id, Coach client)
        {
            return new()
            {
                Id = id,
                FirstName = client.FirstName,
                LastName = client.LastName,
                Email = client.Email,
                PhoneNumber = client.PhoneNumber,
                Active = client.Active
            };
        }

        [Key]
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(40, MinimumLength = 2)]
        [JsonPropertyName("firstName")]
        public string FirstName { get; set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(40, MinimumLength = 2)]
        [JsonPropertyName("lastName")]
        public string LastName { get; set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(150, MinimumLength = 5)]
        [DataType(DataType.EmailAddress)]
        [JsonPropertyName("email")]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(15, MinimumLength = 8)]
        [JsonPropertyName("phoneNumber")]
        public string PhoneNumber { get; set; }

        [Required]
        [JsonPropertyName("active")]
        public bool Active { get; set; }

        [JsonIgnore]
        public virtual List<Routine> Routines { get; set; }

        [NotMapped]
        public string FullName => $"{FirstName} {LastName}";
    }
}
