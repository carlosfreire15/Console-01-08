using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_11_03
{
    class UsuarioDAO
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
            str //Parou aqui
        }
    }
}
