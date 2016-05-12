using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project.Models
{
    public class Reader
    {
        public int ID { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Imie nie moze być dluższe niż 50 znoków.")]
        [Display(Name = "Imię")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Nazwisko")]
        [StringLength(50, ErrorMessage = "Nazwisko nie moze być dluższe niż 50 znoków.")]
        public string Surname { get; set; }
        public ICollection<Rent> Rents { get; set; }
    }
}