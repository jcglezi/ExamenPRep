using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExamenPractico.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult ObtenerPuntoInteres()
        {
            using (DB_GEOModels geoModel = new DB_GEOModels())
            {
                var listPInteres = geoModel.PUNTOS_INTERES.Select(p => new {
                    PInteresID = p.PInteresID,
                    Latitud = p.Latitud,
                    Longitud = p.Longitud,
                    Descripcion = p.Descripcion,
                    Venta = p.Venta,
                    Zona = p.ZONA.Descripcion,
                    ZonaID = p.ZonaID
                }).ToList();
                return Json(new { data = listPInteres }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}