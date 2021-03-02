using BookReader.DAL;
using BookReader.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookReader.BLL
{
    public class BookReadBLL
    {
        private BookContext context;

        public BookReadBLL()
        {
            context = new BookContext();
        }

        public IList<BookRead> List()
        {
            List<BookRead> LisstBookRead = context.TB_BOOK_READ.ToList();

            return LisstBookRead;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
        public string AddBookRead(int id, string resume, DateTime start, DateTime end)
        {
            string response;
            Conexao conexao = new Conexao();
            conexao.Conectar();
            try
            {
                ExecutaSP executaSP = new ExecutaSP("BOOK_SP_INS_BOOK_READ", conexao.VoltaConexaoAberta());
                executaSP.addParam("@ID", id);
                executaSP.addParam("@RESUME", resume);
                executaSP.addParam("@START", start);
                executaSP.addParam("@END", end);

                executaSP.Executa();
                executaSP.Confirma();

                response = "Ok";
                return response;
            }
            catch (Exception ex)
            {
                response = ex.ToString();
                return response;
            }


        }
    }
}