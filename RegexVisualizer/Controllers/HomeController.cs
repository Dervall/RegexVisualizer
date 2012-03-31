using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Piglet.Lexer.Construction;
using Piglet.Lexer.Construction.DotNotation;
using RegexVisualizer.Models;

namespace RegexVisualizer.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(HomeModel model)
        {
            if (model.Regex == null)
            {
                model = new HomeModel {Regex = "", DfaSize = 150, NfaSize = 150, Minimize = true };
            }
            return View(model);
        }

        public JsonResult RegexToDot(string regex, bool minimize, string testInput)
        {
            string dfaString = null;
            string nfaString = null;
            string error = "";
            try
            {
                DotNotation.GetDfaAndNfaGraphs(regex, testInput, minimize, out dfaString, out nfaString);                
            }
            catch (LexerConstructionException e)
            {
                error = e.Message;
            }
            catch (Exception)
            {
                error = "Illegal expression";
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
