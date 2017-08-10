using Redes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Redes.Controllers
{
    public class RegistroController : Controller
    {
        // GET: Registro
        public ActionResult Registrar()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Registro user)
        {
            RedSocialEntities redocialEntities = new RedSocialEntities();
            redocialEntities.Registro.Add(user);
            redocialEntities.SaveChanges();
            string message = string.Empty;
            switch (user.id)
            {
                case -1:
                    message = "Username already exists.\\nPlease choose a different username.";
                    break;
                case -2:
                    message = "Supplied email address has already been used.";
                    break;
                default:
                    message = "Registration successful.\\nUser Id: " + user.id.ToString();
                    break;
            }
            ViewBag.Message = message;

            return View(user);
        }
    }
}