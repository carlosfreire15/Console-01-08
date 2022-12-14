using System;
using System.Configuration;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace AppBancoADO //Console_11_03 
{
    public class Banco : IDisposable
    {
        private readonly MySqlConnection conexao;
        public Banco()
        {
            conexao = new MySqlConnection(ConfigurationManager.ConnectionStrings["conexao"].ConnectionString);
            conexao.Open();
        }

        public void ExecutaComando (string StrQuery)
        {
            var vComando = new MySqlCommand
            {
                CommandText = StrQuery,
                CommandType = CommandType.Text,
                Connection = conexao
            };
            vComando.ExecuteNonQuery();
        }

        public MySqlDataReader RetornaComando(string StrQuery)
        { 
            {
                var comando = new MySqlCommand(StrQuery, conexao);
                return comando.ExecuteReader();
            };
        }
        public void Dispose()
        {
            if (conexao.State == ConnectionState.Open)
            conexao.Close();
        }
    }
}
