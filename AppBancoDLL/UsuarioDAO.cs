using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppBancoDominio;
using AppBancoADO;

namespace AppBancoDLL //Console_11_03 
{
    public class UsuarioDAO
    {
        private Banco db;
        public void Insert(Usuario usuario)
        {
            var strQuery = "";
            strQuery+="INSERT INTO tb_usuario(NomeUsu, Cargo, Data)";
            strQuery += string.Format("VALUES ('{0}','{1}',STR_TO_DATE('{2}','%d/%m/%Y %T'));", usuario.NomeUsu, usuario.Cargo, usuario.Data);


            using (db = new Banco())
            {
                db.ExecutaComando(strQuery);
            }
        }

        public void Atualizar(Usuario usuario)
        {

            var strQuery = "";
            strQuery += "UPDATE tb_usuario set ";
            strQuery += string.Format(" NomeUsu = '{0}', ", usuario.NomeUsu);
            strQuery += string.Format(" Cargo = '{0}', ", usuario.Cargo);
            strQuery += string.Format(" Data = STR_TO_DATE('{0}','%d/%m/%Y %T')", usuario.Data);
            strQuery += string.Format(" Where IdUsu = {0}", usuario.IdUsu);

            using (db = new Banco())
            {
                db.ExecutaComando(strQuery);
            }
        }
        public void Salvar (Usuario usuario)
        {
            if (usuario.IdUsu>0)
            {
                Atualizar(usuario);
            }
            else
            {
                Insert(usuario);
            }
        }
        public void Excluir(Usuario usuario)
        {
            using (db = new Banco())
            {
                var strQuery = string.Format(" Delete from tb_usuario where IdUsu = {0}", usuario.IdUsu);
                db.ExecutaComando(strQuery);
            }
        }

        public List<Usuario> Listar()
        {
            using (db = new Banco())
            {
                var strQuery = "Select * from tb_usuario;";
                var retorno = db.RetornaComando(strQuery);
                return ListaDeUsuario(retorno);
            }
        }

        public List<Usuario> ListaDeUsuario(MySqlDataReader retorno)
        {
            var usuarios = new List<Usuario>();
            while (retorno.Read())
            {
                var TempUsuario = new Usuario()
                {
                    IdUsu = int.Parse(retorno["IdUsu"].ToString()),
                    NomeUsu = retorno["NomeUsu"].ToString(),
                    Cargo = retorno["Cargo"].ToString(),
                    Data = DateTime.Parse(retorno["Data"].ToString())
                };
                usuarios.Add(TempUsuario);
            }
            retorno.Close();
            return usuarios;
        }

        public Usuario ListarId(int IdUsu)
        {
            using (db = new Banco())
            {
                var strQuery = string.Format("SELECT * FROM tb_usuario where IdUsu = {0}; ", IdUsu);
                var retorno = db.RetornaComando(strQuery);
                return ListaDeUsuario(retorno).FirstOrDefault();
            }
        }

    }
}
