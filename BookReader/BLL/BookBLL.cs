﻿using BookReader.DAL;
using BookReader.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Mvc;

namespace BookReader.BLL
{
    public class BookBLL
    {
        private BookContext context;

        public BookBLL()
        {
            context = new BookContext();
        }

        public IList<Book> List()
        {
            return context.TB_BOOK.ToList();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
        public void Remove(string codigo)
        {
            var list = context.TB_BOOK.ToList();
            Book book = list.First(x => x.Id == int.Parse(codigo));
            context.TB_BOOK.Remove(book);
            context.SaveChanges();
        }
        public DataTable Authors()
        {
            Conexao conexao = new Conexao();
            conexao.Conectar();

            SelectSP selAuthor = new SelectSP("BOOK_SP_SEL_AUTHORS", conexao.VoltaConexaoAberta());
            selAuthor.Executa();

            return selAuthor.sDataTable;
        }

        public List<SelectListItem> ListAuthors()
        {
            List<SelectListItem> listAuthor = new List<SelectListItem>();
            SelectSP selAuthor = new SelectSP("BOOK_SP_SEL_AUTHORS");
            selAuthor.Executa();

            foreach (DataRow author in selAuthor.sDataTable.Rows)
            {
                listAuthor.Add(new SelectListItem
                {
                    Value = author.Field<int>("AUT_ID").ToString(),
                    Text = author.Field<string>("AUT_NAME")
                });
            }

            return listAuthor;
        }

        public List<SelectListItem> ListGenres()
        {
            List<SelectListItem> listGenre = new List<SelectListItem>();
            SelectSP selGenre = new SelectSP("BOOK_SP_SEL_GENRES");
            selGenre.Executa();

            foreach (DataRow genre in selGenre.sDataTable.Rows)
            {
                listGenre.Add(new SelectListItem
                {
                    Value = genre.Field<int>("GEN_ID").ToString(),
                    Text = genre.Field<string>("GEN_NAME")
                });
            }

            return listGenre;
        }

        public JArray GetBook()
        {
            var arr = new JArray();

            //Instaciamento da proc e adição de paramentros
            SelectSP selBook = new SelectSP("BOOK_SP_SEL_BOOK");

            try
            {
                selBook.Executa();
                if (selBook.sDataTable.Rows.Count == 0)
                {
                    return arr;
                }
                else
                {
                    foreach (DataRow dr in selBook.sDataTable.Rows)
                    {

                        arr.Add(new JObject(
                            new JProperty("Id", dr.Field<int>("BK_ID")),
                            new JProperty("BkName", dr.Field<string>("BK_NAME")),
                            new JProperty("AutName", dr.Field<string>("AUT_NAME")),
                            new JProperty("GenName", dr.Field<string>("GEN_NAME")),
                            new JProperty("BkIndication", dr.Field<string>("BK_INDICATION")),
                            new JProperty("BkSaga", dr.Field<string>("BK_SAGA")),
                            new JProperty("BkDate", dr.Field<DateTime>("BK_DATE_CREATE").ToShortDateString()),
                            new JProperty("BkFlag", dr.Field<int>("BK_FLAG"))
                        ));
                    }
                    return arr;
                }

            }
            catch (Exception ex)
            {
                return arr;
            }
        }

        public void AddBook(Book book)
        {

            Conexao conexao = new Conexao();
            conexao.Conectar();

            ExecutaSP executa = new ExecutaSP("BOOK_SP_INS_BOOK", conexao.VoltaConexaoAberta());
            try
            {
                executa.addParam("@NAME", book.Name);
                executa.addParam("@IDAUT", book.IdAuthor);
                executa.addParam("@IDGEN", book.IdGenre);
                executa.addParam("@INDICATION", book.Indication);
                executa.addParam("@SAGA", book.Saga.ToString());
                executa.addParam("@DATE", book.DateCreate);

                executa.Executa();
                executa.Confirma();
            }
            catch (Exception ex)
            {

            }
        }
        public JArray DetailsBook(int id)
        {
            var arr = new JArray();

            SelectSP selBook = new SelectSP("BOOK_SP_SEL_DETAILS_BOOK");
            selBook.addParam("ID", id);

            try
            {
                selBook.Executa();
                if (selBook.sDataTable.Rows.Count == 0)
                {
                    return arr;
                }
                else
                {
                    foreach (DataRow dr in selBook.sDataTable.Rows)
                    {

                        arr.Add(new JObject(
                            new JProperty("BkId", dr.Field<int>("BK_ID")),
                            new JProperty("BkName", dr.Field<string>("BK_NAME")),
                            new JProperty("BkIndication", dr.Field<string>("BK_INDICATION")),
                            new JProperty("BkSaga", dr.Field<string>("BK_SAGA")),
                            new JProperty("BkDate", dr.Field<DateTime?>("BK_DATE_CREATE").ToString()), 
                            new JProperty("BkFlag", dr.Field<int>("BK_FLAG")),
                            new JProperty("AutName", dr.Field<string>("AUT_NAME")),
                            new JProperty("AutSaga", dr.Field<string>("AUT_MAIN_SAGA")),
                            new JProperty("AutFavBook", dr.Field<string>("AUT_FAVORITE_BOOK")),
                            new JProperty("GenName", dr.Field<string>("GEN_NAME")),
                            new JProperty("GenDes", dr.Field<string>("GEN_DESCRIPTION")),
                            new JProperty("BkrResume", dr.Field<string>("BKR_RESUME")),
                            new JProperty("BkrDateStart",dr.Field<DateTime?>("BKR_DATESTART").ToString()),
                            new JProperty("BkrDateEnd", dr.Field<DateTime?>("BKR_DATEEND").ToString())
                        ));
                    }
                    return arr;
                }

            }
            catch (Exception ex)
            {
                return arr;
            }
        }

        public void UpdBook(Book book,BookRead bookRead)
        {

            Conexao conexao = new Conexao();
            conexao.Conectar();

            ExecutaSP executa = new ExecutaSP("BOOK_SP_UPD_BOOK", conexao.VoltaConexaoAberta());
            try
            {
                executa.addParam("@ID", book.Id);
                executa.addParam("@NAME", book.Name);
                executa.addParam("@INDICATION", book.Indication);
                executa.addParam("@SAGA", book.Saga);
                executa.addParam("@RESUME", bookRead.Resume);
                executa.addParam("@DATESTART", bookRead.DateStart);
                executa.addParam("@DATEEND", bookRead.DateEnd);


                executa.Executa();
                executa.Confirma();
            }
            catch (Exception ex)
            {

            }
        }
    }
}