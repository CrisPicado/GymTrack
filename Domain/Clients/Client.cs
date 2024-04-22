using Domain.Routines;
using Shared.Domain;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Domain.Clients
{
    public class Client : Entity
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

        [Required]
        [DataType(DataType.Date)]
        [Range(typeof(DateTime), minimum: "1900-01-01", maximum: "2024-01-01")]
        [JsonPropertyName("birthDate")]
        public DateTime BirthDate { get; set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(150, MinimumLength = 5)]
        [DataType(DataType.EmailAddress)]
        [JsonPropertyName("email")]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(15, MinimumLength = 8)]
        [DataType(DataType.PhoneNumber)]
        [JsonPropertyName("phoneNumber")]
        public string PhoneNumber { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "La altura debe ser mayor que cero.")]
        [JsonPropertyName("height")]
        public double? Height { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "El peso debe ser mayor que cero.")]
        [JsonPropertyName("weight")]
        public double? Weight { get; set; }

        [Required]
        [JsonPropertyName("active")]
        public bool Active { get; set; }

        [JsonIgnore]
        public virtual List<Routine> Routines { get; set; }

        [NotMapped]
        public string FullName => $"{FirstName} {LastName}";
    }
}
