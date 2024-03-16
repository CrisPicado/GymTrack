using Domain.Coaches;
using Domain.Routines;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Clients
{
    public class Client
    {
        public Client()
        {
            
        }

        public static Client Create(int id, string firstName, string lastName, DateTime birthDate,
            string email, string phoneNumber, bool active, double? height, double? weight)
        {
            return new()
            {
                Id = id,
                FirstName = firstName,
                LastName = lastName,
                BirthDate = birthDate,
                Email = email,
                PhoneNumber = phoneNumber,
                Active = active,
                Height = height,
                Weight = weight
            };
        }

        public static Client Create(int id, Client client)
        {
            return new()
            {
                Id = id,
                FirstName = client.FirstName,
                LastName = client.LastName,
                BirthDate = client.BirthDate,
                Email = client.Email,
                PhoneNumber = client.PhoneNumber,
                Active = client.Active,
                Height = client.Height,
                Weight = client.Weight
            };
        }

        [Key]
        public int Id { get; private set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(40, MinimumLength = 2)]
        public string FirstName { get; set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(40, MinimumLength = 2)]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Range(typeof(DateTime), minimum: "1900-01-01", maximum: "2024-01-01")]
        public DateTime BirthDate { get; set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(150, MinimumLength = 5)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(15, MinimumLength = 8)]
        public string PhoneNumber { get; set; }


        public double? Height { get; set; }

        public double? Weight { get; set; }

        [Required]
        public bool Active { get; set; }

        public List<Coach>  Coaches { get; set; }

        public List<Routine> Routines { get; set; }
    }
}
