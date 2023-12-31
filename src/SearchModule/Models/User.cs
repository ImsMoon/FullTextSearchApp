using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SearchModule.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public string FullDetails => FirstName +" "+ LastName +" | "+ Email +" |"+ Phone;
    }
}