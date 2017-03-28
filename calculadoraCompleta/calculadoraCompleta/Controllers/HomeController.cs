using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace calculadoraCompleta.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            Session["visor"] = 0; // força a aparecer um ZERO no visor
            Session["aux"] = 0;
            Session["oper"] = 0;
            return View();
        }
        // POST: Home
        [HttpPost]
        public ActionResult Index(string bt, string visor, string aux, string oper)
        {
            // qual o botão que foi pressionado?
            switch (bt)
            {
                case "0":
                    
                    break;

                case "1":
                case "2":
                case "3":
                case "4":
                case "5":
                case "6":
                case "7":
                case "8":
                case "9":
                    visor = Convert.ToDouble(visor) * 10 + Convert.ToDouble(bt) + "";
                    break;

                case ".":
                    if (visor.Contains("."))
                    {
                        break;
                    }
                    else
                    {
                        visor = Convert.ToDouble(visor) + ".";
                    }

                    break;

                case "C":
                    visor = "0";
                    Session["aux"] = 0;
                    Session["oper"] = 0;
                    break;

                case "+":
                    Session["oper"] = 1;
                    Session["aux"] = visor;
                    visor = "0";
                    break;

                case "-":
                    Session["oper"] = 2;
                    Session["aux"] = visor;
                    visor = "0";
                    break;

                case "/":
                    Session["oper"] = 3;
                    Session["aux"] = visor;
                    visor = "0";
                    break;

                case "*":
                    Session["oper"] = 4;
                    Session["aux"] = visor;
                    visor = "0";
                    break;

                case "+/-":
                    visor = Convert.ToDouble(visor) * -1 + "";
                    break;

                case "=":
                    oper = Session["oper"].ToString();
                    aux = Session["aux"].ToString();
                    switch (oper)
                    {
                        case "1":
                            visor = Convert.ToDouble(visor) + Convert.ToDouble(aux) + "";
                            break;

                        case "2":
                            visor = Convert.ToDouble(visor) - Convert.ToDouble(aux) + "";
                            break;

                        case "3":
                            visor = Convert.ToDouble(visor) / Convert.ToDouble(aux) + "";
                            break;

                        case "4":
                            visor = Convert.ToDouble(visor) * Convert.ToDouble(aux) + "";
                            break;

                        default:
                            break;
                    }
                    break;

                default:
                    break;
            }

            Session["visor"] = visor;

            return View();
        }
        }
}