using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Test.Controllers
{
    public class IndexController : Controller
    {
        // GET: Index
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ValidateData(string username, string password)
        {
            var msg = "Bienvenido " + username + " " + password;
            var script = "";

            if (username == "daniel" && password == "123")
            {
                script = "<script languaje='javascript'>" +
                            "window.location.href = '/Index/Home' " +
                         "</script>";

                Session["username"] = username;

            } else
            {
                script = "<script languaje='javascript'>" +
                            "alert('Las credenciales no coinciden')" +
                         "</script>";
            }

            return Content(script);
        }

        public ActionResult Home()
        {
            if (Session["username"] != null)
            {
                return View();
            } else
            {
                return Content("<script languaje='javascript' type='text/javascript'> " +
                                    "alert('Sesion cerrada o no existe');" +
                                    "window.location.href='/Index';" +
                                "</script>");
            }

        }

        public void CloseSession()
        {
            Session["username"] = null;
            Response.Redirect("/Index/Home");
        }
    }
}