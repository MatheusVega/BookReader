using BookReader.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace BookReader.BLL
{
    public class GenreBLL
    {
        private BookContext context;

        public GenreBLL()
        {
            context = new BookContext();
        }

        public void Add(Genre genre)
        {
            context.TB_GENRE.Add(genre);
            context.SaveChanges();
        }
        public IList<Genre> List()
        {
            List<Genre> ListaGenre = context.TB_GENRE.ToList();

            return ListaGenre;
        }
        public List<SelectListItem> GetGenre()
        {
            var listaOpcoes = Enum.GetValues(typeof(Genre)).Cast<Genre>().Select(v => new SelectListItem
            {
                Text = v.Description,
                Value = (v).ToString()
            }).ToList();


            return listaOpcoes;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
        public void Remove(string codigo)
        {
            var list = context.TB_GENRE.ToList();
            Genre genre = list.First(x => x.Id == int.Parse(codigo));
            context.TB_GENRE.Remove(genre);
            context.SaveChanges();
        }
        public void Update(Genre genre)
        {
            var list = context.TB_GENRE.ToList();
            var GenreEdit = list.First(x => x.Id == genre.Id);
            GenreEdit.Name = genre.Name;
            GenreEdit.Description = genre.Description;
            GenreEdit.DateCreate = genre.DateCreate;
            context.SaveChanges();
        }
    }
}