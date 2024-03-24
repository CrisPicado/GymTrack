using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Coaches
{
    public class CoachDTO
    {
        public CoachDTO() 
        {

        }

        public CoachDTO(int id, string fullName) 
        {
            Id = id;
            FullName = fullName;
        }

        public int Id { get; set; }
        public string FullName { get; set; }
    }
}
