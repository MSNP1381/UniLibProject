using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniLibProject.Models
{
    class Book
    {
  [System.ComponentModel.DataAnnotations.Key]
        public int Id { get; set; }
        public string BookName { get; set; }
        public int BookCode { get; set; }
        public string Author { get; set; }
        public string Genere { get; set; }
        public DateTime BorrowedDate { get; set; }
    }
}
