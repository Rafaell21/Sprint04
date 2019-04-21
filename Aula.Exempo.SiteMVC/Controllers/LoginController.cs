using Aula.Exempo.SiteMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Aula.Exempo.SiteMVC.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        // POST: Login
        [HttpPost]
        public ActionResult Index([Bind(Include = "Email,Senha")] Usuario usuarios)
        {

            if (String.IsNullOrEmpty(usuarios.Email) || String.IsNullOrEmpty(usuarios.Senha))
            {
                return RedirectToAction("Index", "Home");
            }
           
            return View();


        }
    }
}