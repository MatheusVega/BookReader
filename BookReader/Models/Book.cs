using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BookReader.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual Author Author { get; set; }
        public int IdAuthor { get; set; }
        public virtual Genre Genre { get; set; }
        public int IdGenre { get; set; }
        public string Indication { get; set; }
        public string Saga { get; set; }
        public DateTime DateCreate { get; set; }
        public int Flag { get; set; }
        public virtual ICollection<BookRead> BookReads { get; set; }
    }
}