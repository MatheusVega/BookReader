using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [DisplayName("Código")]
        public int Id { get; set; }
        [DisplayName("Nome")]
        public string Name { get; set; }
        [DisplayName("Descrição")]
        public string Description { get; set; }
        [DisplayName("Data da Criação")]
        public DateTime DateCreate { get; set; }
        public virtual ICollection<Author> Authors { get; set; }


    }
}