using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Project.Models
{
    public class Rent
    {
        public int ID { get; set; }
        public int BookID { get; set; }
        public int ReaderID { get; set; }
        [Display(Name = "Data wypożyczenia")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateOfRent { get; set; }
        [Display(Name = "Data zwrotu")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateOfReturn { get; set; }

        public virtual Book Books { get; set; }
        public virtual Reader Readers { get; set; }
    }
}