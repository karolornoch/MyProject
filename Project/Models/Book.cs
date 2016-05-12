using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Models
{
    public class Book
    {
        public int ID { get; set; }
        public int CategoryID { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int PublicationDate { get; set; }
        public virtual Category Category { get; set; }

        public virtual ICollection<Rent> Rents { get; set; }
    }
}