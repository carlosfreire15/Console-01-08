using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AppBancoDLL;


namespace WebMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var metodosUsuario = new UsuarioDAO();
            var TodosUsuario = metodosUsuario.Listar();
            return View(TodosUsuario);
        }

        
    }
}