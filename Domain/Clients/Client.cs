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

        public static Client Create(int id, string firstName, string lastName, string dni,
            string email, string phoneNumber, bool active)
        {
            return new()
            {
                Id = id,
                FirstName = firstName,
                LastName = lastName,
                Dni = dni,
                Email = email,
                PhoneNumber = phoneNumber,
                Active = active
            };
        }

        public static Client Create(int id, Client client)
        {
            return new()
            {
                Id = id,
                FirstName = client.FirstName,
                LastName = client.LastName,
                Dni = client.Dni,
                Email = client.Email,
                PhoneNumber = client.PhoneNumber,
                Active = client.Active
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

        [Required(AllowEmptyStrings = false)]
        [StringLength(11, MinimumLength = 9)]
        public string Dni { get; set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(150, MinimumLength = 5)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(15, MinimumLength = 8)]
        public string PhoneNumber { get; set; }

        [Required]
        public bool Active {  get; set; }
    }
}
