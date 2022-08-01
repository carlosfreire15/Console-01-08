





using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using AppBancoDLL;
using AppBancoADO;
using AppBancoDominio;

namespace Console_11_03
{
    class Program
    {
        static void Main(string[] args)
        {
            var Banco = new Banco();
            var usuarioDAO = new UsuarioDAO();
            var usuario = new Usuario();

            var escolha = 0;
            
            //Console.WriteLine("Prescione o enter e escolhe uma das opções: 0, 1, 2, 3 ou 4");


            while (escolha == 0)
            {
                


                Console.WriteLine("------------------AppBanco------------------");
                Console.WriteLine("=         0 - Cadastrar Usuário            =");
                Console.WriteLine("=         1 - Editar Usuário               =");
                Console.WriteLine("=         2 - Excluir Usuário              =");
                Console.WriteLine("=         3 - Listar Usuario               =");
                Console.WriteLine("=         4 - Sair                         =");
                Console.WriteLine("============================================");
                Console.WriteLine("");
                Console.WriteLine("Qual opção você deseja?");
                var opcao = Console.ReadLine();
             
                switch (opcao)
                {
                    case "0":
                        Console.WriteLine("Digite o nome do usuário");
                        usuario.NomeUsu = Console.ReadLine();

                        Console.WriteLine("Digite o cargo do usuário");
                        usuario.Cargo = Console.ReadLine();

                        Console.WriteLine("Digite a data de nascimento do usuário");
                        usuario.Data = DateTime.Parse(Console.ReadLine());

                        usuarioDAO.Insert(usuario);

                        Console.WriteLine("");

                        Console.WriteLine("Usuário cadastrado com sucesso!");

                        Console.WriteLine("");

                        break;

                    case "1":
                        Console.WriteLine("Digite o nome do usuário");
                        usuario.NomeUsu = Console.ReadLine();

                        Console.WriteLine("Digite o cargo do usuário");
                        usuario.Cargo = Console.ReadLine();

                        Console.WriteLine("Digite a data de nascimento do usuário");
                        usuario.Data = DateTime.Parse(Console.ReadLine());

                        Console.WriteLine("Digite o ID (identificação) do usuário");
                        usuario.IdUsu = int.Parse(Console.ReadLine());

                        usuarioDAO.Atualizar(usuario);

                        Console.WriteLine("");

                        Console.WriteLine("Usuário Atualizado com sucesso!");

                        Console.WriteLine("");

                        break;
                    case "2":
                        Console.WriteLine("Digite o ID (identificação) do usuário");
                        usuario.IdUsu = int.Parse(Console.ReadLine());

                        usuarioDAO.Excluir(usuario);

                        Console.WriteLine("");

                        Console.WriteLine("Usuário excluído com sucesso!");

                        Console.WriteLine("");
                        break;
                    case "3":
                        Console.WriteLine("");
                        break;
                    case "4":
                        escolha = 1;
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Escolha uma das opções: 0, 1, 2, 3 ou 4");
                        
                        break;

                }


                if (opcao == "0" || opcao == "1" || opcao == "2" || opcao == "3")
                {
                    var leitor = usuarioDAO.Listar();

                    foreach (var usuarios in leitor)
                    {
                        Console.WriteLine("Id: {0} , Nome: {1} , Cargo: {2}, Data: {3}", usuarios.IdUsu, usuarios.NomeUsu, usuarios.Cargo, usuarios.Data);
                    };
                    Console.WriteLine("Aperte ENTER para fazer uma nova operação.");
                    Console.ReadLine();
                    Console.Clear();
                    
                }

               
            }
            Console.Write("Fechando operação...");
                Environment.Exit(0);
            
        } 
            
            
    } 
}

