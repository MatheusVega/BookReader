using System;
using System.Data;
using System.Data.SqlClient;

namespace BookReader.DAL
{
    public class SelectSP
    {
        public SqlConnection Conexao { get; set; }
        public SqlCommand Comando { get; set; }
        public SqlDataAdapter dataAdapter { get; set; }
        public DataTable sDataTable { get; set; }
        public SqlTransaction Transacao { get; set; }
        private bool ConexaoEnviada { get; set; }
        public string Dbg { get; set; }

        public SelectSP(string SP, SqlConnection _Conexao = null, SqlTransaction _Transacao = null)
        {
            if (_Conexao == null)
            {
                Conexao conexaoBase = new Conexao();
                conexaoBase.Conectar();

                Conexao = conexaoBase.VoltaConexaoAberta();


            }
            else
            {
                ConexaoEnviada = true;
                Conexao = _Conexao;
                Transacao = _Transacao;
            }


            Comando = new SqlCommand(SP, Conexao);
            Comando.CommandType = CommandType.StoredProcedure;

            if (ConexaoEnviada)
            {
                Comando.Transaction = Transacao;
            }

            Comando.Parameters.Clear();

            if (!ConexaoEnviada)
            {
                Conexao.Close();
            }

            Dbg = SP;

        }

        public void addParam(string param, object valor)
        {
            Comando.Parameters.AddWithValue(param, valor);

            Dbg = Dbg + "\n" + param + " = " + valor + ",";
        }

        public void addParam(SqlParameter param)
        {
            Comando.Parameters.Add(param);
        }

        public void addParamOutput(string param, System.Data.SqlDbType sqldbtype)
        {
            Comando.Parameters.Add(param, sqldbtype).Direction = ParameterDirection.Output;
        }

        public void addParamOutputVarChar(string param, System.Data.SqlDbType sqldbtype, int tamanho)
        {
            Comando.Parameters.Add(param, sqldbtype, tamanho).Direction = ParameterDirection.Output;
        }

        public void Executa(int Usuario_Log = -1000)
        {
            try
            {

                dataAdapter = new SqlDataAdapter();
                sDataTable = new DataTable();
                dataAdapter.SelectCommand = Comando;
                Comando.CommandTimeout = 520000; //5 minutos
                dataAdapter.Fill(sDataTable);



            }
            catch (Exception ex)
            {

                Comando.Dispose();
                Conexao.Close();
                throw new Exception(ex.Message);

            }

            Comando.Dispose();
            if (!ConexaoEnviada)
            {
                Conexao.Close();
            }
        }
    }
}