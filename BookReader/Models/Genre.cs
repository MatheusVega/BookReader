using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BookReader.Models
{
    [Table("TB_GENRE")]
    public class Genre
    {
        public Genre()
        {
            Authors = new HashSet<Author>();
        }
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateCreate {get; set; }
        public virtual ICollection<Author> Authors {get; set; }


    }
}