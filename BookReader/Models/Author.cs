using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BookReader.Models
{
    public class Author
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual Genre Genre { get; set; }
        public int IdGenre { get; set; }
        public string MainSaga { get; set; }
        public string FavoriteBook { get; set; }
        public DateTime DateCreate { get; set; }

    }
}