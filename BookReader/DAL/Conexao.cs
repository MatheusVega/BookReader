using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace BookReader.DAL
{
    public class Conexao
    {
        private SqlConnection sqlConn;
        private SqlTransaction transaction = null;
        private SqlCommand sqlcomandoTrans = null;
        public string FlagDanfe { get; set; }



        public SqlConnection VoltaConexaoAberta()
        {
            return this.sqlConn;
        }



        public void Conectar()
        {
            sqlConn = new SqlConnection("Server = tcp:book.database.windows.net, 1433; Initial Catalog = BookReader; Persist Security Info = False; User ID = matheusveiga; Password = m68695412@; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;");
            sqlConn.Open();
            string teste;
            teste = sqlConn.State.ToString();
        }


        public void FecharConexao()
        {
            sqlConn.Close();
            sqlConn.Dispose();
        }

        public void ComandoSql(string sSql)
        {
            SqlCommand sqlcomando = new SqlCommand(sSql, sqlConn);
            sqlcomando.CommandTimeout = 5000;
            sqlcomando.ExecuteNonQuery();
        }

        public DataTable ComandoSqlDt(string sSql)
        {
            SqlDataAdapter adapter = new SqlDataAdapter(sSql, sqlConn);
            DataTable dataSet = new DataTable();
            adapter.SelectCommand.CommandTimeout = 5000;
            adapter.SelectCommand.Prepare();
            adapter.Fill(dataSet);

            return dataSet;
        }

        public DataTable ComandoSqlDtee(string sSql)
        {
            //SqlCommand sqll = new SqlCommand();
            //sqll.BeginExecuteNonQuery();
            SqlDataAdapter adapter = new SqlDataAdapter(sSql, sqlConn);

            DataTable dataSet = new DataTable();
            adapter.Fill(dataSet);
            return dataSet;
        }

        public bool StatusConexao()
        {
            if (sqlConn == null)
            {
                return false;
            }
            else if (sqlConn.State.ToString().ToUpper() == "OPEN")
                return true;
            else
                return false;
        }

        public void BeginTrans(string transacao)
        {
            transaction = sqlConn.BeginTransaction(transacao);
            sqlcomandoTrans = new SqlCommand();
            sqlcomandoTrans.Connection = sqlConn;
            sqlcomandoTrans.Transaction = transaction;
        }

        public void Commit()
        {
            transaction.Commit();
            MatarTransacao();
        }

        public void Rollback()
        {
            if (transaction != null)
                transaction.Rollback();
            MatarTransacao();
        }

        private void MatarTransacao()
        {
            MatarComandoTrans();
            transaction.Dispose();
            transaction = null;

        }

        private void MatarComandoTrans()
        {
            sqlcomandoTrans.Dispose();
            sqlcomandoTrans = null;
        }

    }
}