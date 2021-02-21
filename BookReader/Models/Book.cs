using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace BookReader.Models
{
    public class Book
    {
        [DisplayName("Código")]
        public int Id { get; set; }
        [DisplayName("Nome")]
        public string Name { get; set; }
        [DisplayName("Autor")]
        public virtual Author Author { get; set; }
        [DisplayName("Nome do Autor")]
        public int IdAuthor { get; set; }
        [DisplayName("Gênero")]
        public virtual Genre Genre { get; set; }
        [DisplayName("Nome do Gênero")]
        public int IdGenre { get; set; }
        [DisplayName("Indicação")]
        public string Indication { get; set; }
        [DisplayName("Saga")]
        public string Saga { get; set; }
        [DisplayName("Data da criação")]
        public DateTime DateCreate { get; set; }
        public int Flag { get; set; }
        public virtual ICollection<BookRead> BookReads { get; set; }
    }
}