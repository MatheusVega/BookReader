using System;
using System.ComponentModel;

namespace BookReader.Models
{
    public class BookRead
    {
        [DisplayName("Código")]
        public int Id { get; set; }
        public virtual Book Book { get; set; }
        [DisplayName("Nome do Livro")]
        public int IdBK { get; set; }
        [DisplayName("Resumo")]
        public string Resume { get; set; }
        [DisplayName("Data de inicio")]
        public DateTime DateStart { get; set; }
        [DisplayName("Data do Termino")]
        public DateTime DateEnd { get; set; }
    }
}