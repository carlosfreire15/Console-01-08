using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace AppBancoDominio //Console_11_03 
{
    public class Usuario
    {

        [DisplayName("ID do usuário")]
        public int IdUsu { get; set; }

        [DisplayName("Nome do usuário")]

        public string NomeUsu { get; set; }

        [DisplayName("Cargo do usuário")]

        public string Cargo { get; set; }

        [DisplayName("Data de nascimento do usuário")]

        public DateTime Data { get; set; }
       
    }
}
