using System;
using System.ComponentModel;

namespace BookReader.Models
{
    public class Author
    {
        [DisplayName("Código")]
        public int Id { get; set; }
        [DisplayName("Nome")]
        public string Name { get; set; }
        [DisplayName("Gênero")]
        public virtual Genre Genre { get; set; }
        [DisplayName("Gênero")]
        public int IdGenre { get; set; }
        [DisplayName("Saga Principal")]
        public string MainSaga { get; set; }
        [DisplayName("Livro Favórito")]
        public string FavoriteBook { get; set; }
        [DisplayName("Data da Criação")]
        public DateTime DateCreate { get; set; }

    }
}