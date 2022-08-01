using AppBancoDominio;
using AppBancoDLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace WebMVC.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult Index()
        {
            var metodosUsuario = new UsuarioDAO();
            var TodosUsuario = metodosUsuario.Listar();
            return View(TodosUsuario);
        }

        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar (Usuario usuario)
        {
            //Importante para Data Anno.
            if(ModelState.IsValid)
            {
                var metodosUsuario = new UsuarioDAO();
                metodosUsuario.Insert(usuario);
                return RedirectToAction("Index");
            }
            return View(usuario);
        }

        public ActionResult Editar(int IdUsu)
        {
            var metodosUsuario = new UsuarioDAO();
            var usuario = metodosUsuario.ListarId(IdUsu);

            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        [HttpPost]
        public ActionResult Editar(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                var metodosUsuario = new UsuarioDAO();
                metodosUsuario.Atualizar(usuario);
                return RedirectToAction("Index");
            }
            return View(usuario);
        }

        public ActionResult Excluir(int IdUsu)
        {
            var metodosUsuario = new UsuarioDAO();
            var usuario = metodosUsuario.ListarId(IdUsu);

            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }
        
        //A action name serve para separar/especificar o nome de ação diferente do nome do método, normalmente resolvendo quando usa parâmetros iguais
        [HttpPost, ActionName("Excluir")]

        public ActionResult ExcluirConfirma(int IdUsu)
        {
            var metodosUsuario = new UsuarioDAO();
            Usuario usuario = new Usuario();
            usuario.IdUsu = IdUsu;
            metodosUsuario.Excluir(usuario);
            return RedirectToAction("Index");
        }

        public ActionResult Detalhes(int IdUsu)
        {
            var metodosUsuario = new UsuarioDAO();
            var usuario = metodosUsuario.ListarId(IdUsu);

            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }
    }
}