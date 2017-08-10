using Redes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Redes.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ViewResult Index(Login login)
        {
            if (ModelState.IsValid)  
            {
                if (login.checkUser(login.correo, login.contraseña))  
                {
                    return View("Show", login);  
                }
                else
                {
                    ViewBag.Message = "Invalid Username or Password";
                    return View();  
                }
            }
            else
            {
                return View(); // Return the same view with validation errors.
            }
        }
    }
}