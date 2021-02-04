using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BookReader.DAL
{
    public class ExecutaSP
    {
        public SqlTransaction Transacao;

        public SqlConnection Conexao;

        public SqlCommand[] Comando;

        public string Dbg;

        public string NomeSP;

        public SqlCommand Comando_Log;

        public ExecutaSP(string SP, SqlConnection _Conexao = null)
        {

            //Pegar a conexao da classe existente

            Comando = new SqlCommand[1];

            if (_Conexao == null)
            {
                throw new Exception("Informar a conexão");
            }
            else
            {
                Conexao = _Conexao;

                Comando[0] = new SqlCommand(SP, Conexao);


                Transacao = Conexao.BeginTransaction();
                Comando[0].CommandType = CommandType.StoredProcedure;
                Comando[0].Transaction = Transacao;
                Comando[0].Parameters.Clear();

            }




        }

        public void AddSP(string SP)
        {
            Array.Resize(ref Comando, Comando.Length + 1);


            Comando[(Comando.Length - 1)] = new SqlCommand(SP, Conexao);
            Comando[(Comando.Length - 1)].CommandType = CommandType.StoredProcedure;
            Comando[(Comando.Length - 1)].Transaction = Transacao;
            Comando[(Comando.Length - 1)].Parameters.Clear();

        }

        public void addParam(string param, object valor, int c = 0)
        {
            Comando[c].Parameters.AddWithValue(param, valor);
            // Warning!!! Optional parameters not supported


        }

        public void addParam(SqlParameter param, int c = 0)
        {
            Comando[c].Parameters.Add(param);
        }

        public void addParamOutput(string param, System.Data.SqlDbType sqldbtype, int c = 0)
        {
            Comando[c].Parameters.Add(param, sqldbtype).Direction = ParameterDirection.Output;
            // Warning!!! Optional parameters not supported
        }

        public void addParamOutputVarChar(string param, System.Data.SqlDbType sqldbtype, int tamanho, int c = 0)
        {
            Comando[c].Parameters.Add(param, sqldbtype, tamanho).Direction = ParameterDirection.Output;
            // Warning!!! Optional parameters not supported
        }

        public void Executa(int c = 0, int Usuario_Log = -1000)
        {
            try
            {
                Comando[c].CommandTimeout = 520000; //5 minutos
                Comando[c].ExecuteNonQuery();

            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception exe)
            {
                Transacao.Rollback();
                Comando[c].Dispose();
                Conexao.Close();

            }
        }

        public int ExecutaComRet(int c = 0, int Usuario_Log = -1000)
        {
            try
            {
                Comando[c].CommandTimeout = 520000; //5 minutos
                return Comando[c].ExecuteNonQuery();

            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception e)
            {
                Transacao.Rollback();
                Comando[c].Dispose();
                Conexao.Close();
                throw e;
            }
        }

        public void Confirma()
        {
            try
            {
                Transacao.Commit();
            }
            catch (Exception)
            {
                Transacao.Rollback();
                Conexao.Close();
                Conexao.Dispose();
                Conexao = null;
                Comando = null;
                Comando_Log = null;

            }
            Conexao.Close();
            Conexao.Dispose();
            Conexao = null;
            Comando = null;
            Comando_Log = null;
        }
    }
}