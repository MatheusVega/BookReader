using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookReader.Models
{
    public class Read
    {
        public int Id { get; set; }
        public virtual Book Book { get; set; }
        public int IdBook { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public string Note { get; set; }
        public string Type { get; set; }
        public DateTime DateCreate { get; set; }

    }
}