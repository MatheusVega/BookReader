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

    }
}