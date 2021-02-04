using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookReader.Models
{
    public class BookRead
    {
        public int Id { get; set; }
        public virtual Book Book { get; set; }
        public int IdBK { get; set; }
        public string Resume { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
    }
}