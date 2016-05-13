using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project.Models
{
    public class Book
    {
        public int ID { get; set; }
        public long ISBN { get; set; }
        [Required]
        [Display(Name = "Kategoria")]
        public int CategoryID { get; set; }
        [Required]
        [Display(Name = "Tytuł")]
        public string Title { get; set; }
        [Required]
        [Display(Name = "Autor")]
        public string Author { get; set; }
        [Required]
        [Display(Name = "Data Publikacji")]
        public int PublicationDate { get; set; }
        public virtual Category Category { get; set; }

        public virtual ICollection<Rent> Rents { get; set; }
    }
}