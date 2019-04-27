using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CavalloDiUnaSolaCellula.Models;
using System.Xml.XPath;
using System.Xml.Linq;

namespace CavalloDiUnaSolaCellula.Controllers
{
    public class HomeController : Controller
    {
        //Collega DB
        CavalloDiUnaSolaCellulaEntities db = new CavalloDiUnaSolaCellulaEntities();

        public ActionResult Index()
        {
            var menu = from m in db.tab_mappa 
                       select m;
            return View(menu.ToList());
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult ChiSono()
        {
            Random RandomClass = new Random();
            int RandomNumber = RandomClass.Next(1, 5);
            string foto = "";
            switch (RandomNumber)
            {
                case 1:
                    foto = "Milano 2004";
                break;
                case 2:
                    foto = "Vienna 2005";
                break;
                case 3:
                    foto = "Vienna 2005";
                break;
                case 4:
                    foto = "Grecia";
                break;
                case 5:
                    foto = "Puglia";
                break;
            }
            ViewData["didascalia"] = foto;
            ViewData["foto"] = "../../Images/CavalloMorto" + RandomNumber.ToString() + ".png";

            return View();    
        }

        public ActionResult Lavoro()
        {
            return View();
        }

        public ActionResult NonLavoro()
        {
            var musica = from m in db.random10Pezzi
                            select m;
            return View(musica.ToList());
        }
        
        public ActionResult Contatti()
        {
            return View();
        }
  
        public ActionResult Archivio()
        {
            var lastProgetto = (from p in db.tab_progetti
                                orderby p.fine descending
                                select p).FirstOrDefault();
            ViewData["ultimoAggiornamento"] = lastProgetto.fine.ToShortDateString();
            var contaProgetti = (from p in db.tab_progetti
                                 select p.id_progetto).Count();
            var clienti = (from p in db.tab_progetti
                             select p.cliente_descrizione).Distinct();


            ViewData["contaProgetti"] = contaProgetti.ToString();
            return View(clienti.ToList());
        }

        public ActionResult Soluzioni()
        {
            var lastProgetto = (from p in db.tab_progetti
                                orderby p.fine descending
                                select p).FirstOrDefault();
            var categoria = (from p in db.tab_progetti
                                select p.categoria).Distinct();

            //return View(menu.ToList());
            ViewData["ultimoAggiornamento"] = lastProgetto.fine.ToShortDateString();
            return View(categoria.ToList());
        }

        public ActionResult Impazzuto_D1()
        {
            return View();
        }

        public ActionResult Impazzuto_D2()
        {
            return View();
        }
        public ActionResult Impazzuto_D3()
        {
            return View();
        }
        public ActionResult Impazzuto_D4()
        {
            return View();
        }
        public ActionResult Impazzuto_D5()
        {
            return View();
        }

    }
}
