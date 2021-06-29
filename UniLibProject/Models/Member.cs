using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniLibProject.Models
{
    class Member
    {
        [Key]
        public int Id { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public DateTime DateJoined { get; set; }
        public DateTime DateCharge { get; set; }
        public long charge { get; set; }


    }
}
