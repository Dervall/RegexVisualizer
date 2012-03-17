using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Piglet.Lexer.Construction.DotNotation;
using RegexVisualizer.Models;

namespace RegexVisualizer.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Default/
        public ActionResult Index()
        {
            return View(new HomeModel { Regex = "" });
        }

        public JsonResult RegexToDot(string regex)
        {
            string dfaString = null;
            string nfaString = null;
            string error = null;
            try
            {
                DotNotation.GetDfaAndNfaGraphs(regex, out dfaString, out nfaString);                
            }
            catch (Exception)
            {
                error = "yes";
            }

            return new JsonResult { 
                Data = new
                {
                    Nfa = dfaString,
                    Dfa = nfaString,
                    Error = error
                }, 
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
    }
}
