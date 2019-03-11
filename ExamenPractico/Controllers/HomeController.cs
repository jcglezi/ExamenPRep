using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ExamenPractico.Models;
using ExamenPractico.Models.Entidades;
using Newtonsoft.Json;

namespace ExamenPractico.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index()
        {
            HttpClient httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync("https://samples.openweathermap.org/data/2.5/weather?lat=19&lon=-99&appid=b6907d289e10d714a6e88b30761fae22");
            var temperatura = JsonConvert.DeserializeObject<Temperatura>(json);
            var temperaturaC = Convert.ToDecimal(temperatura.main.temp) - 32 *(5/9);
            temperatura.main.temp = temperaturaC.ToString();
            return View(temperatura);
        }

        public ActionResult Contacto()
        {
            ViewBag.Message = "Creado por: Jose Carlos Gonzalez Ibarra";

            return View();
        }

        public ActionResult ObtenerPuntoInteres()
        {
            using (ExamenPracticoBD contexto = new ExamenPracticoBD())
            {
                var listaPuntoInteres = contexto.PuntosInteres.Select(a => new {
                    PuntoInteres = a.PuntoInteres,
                    Latitud = a.Latitud,
                    Longitud = a.Longitud,
                    Descripcion = a.Descripcion,
                    Venta = a.Venta,
                    Zona = a.Zona.Descripcion,
                    IdZona = a.IdZona
                }).ToList();

                if(listaPuntoInteres.Count > 0)
                    return Json(new
                    {
                        Resultado = true,
                        DatosPuntosInteres = listaPuntoInteres,
                    }, JsonRequestBehavior.AllowGet);
                else
                    return Json(new
                    {
                        Resultado = false,
                        Error = "No existen datos",
                    }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult ObtenerSumaZonas()
        {
            var listaZonas = new List<string>();
            var listaSumaZonas = new List<string>();

            using (ExamenPracticoBD contexto = new ExamenPracticoBD())
            {
                var listaPuntoInteres = contexto.PuntosInteres.Select(a => new {
                    PuntoInteres = a.PuntoInteres,
                    Latitud = a.Latitud,
                    Longitud = a.Longitud,
                    Descripcion = a.Descripcion,
                    Venta = a.Venta,
                    Zona = a.Zona.Descripcion,
                    IdZona = a.IdZona
                }).ToList();

                var ventas = listaPuntoInteres.GroupBy(x => x.Zona).Select(x => new
                {
                    zona = x.Key,
                    total = x.Sum(y => y.Venta)
                }).ToList();

                var lSumaZonas = ventas.Select(v => new { nombre = v.zona, totalS = v.total });

                foreach(var zona in lSumaZonas)
                {
                    listaZonas.Add(zona.nombre);
                    listaSumaZonas.Add(zona.totalS.ToString());
                }

                if (ventas.Count > 0)
                    return Json(new
                    {
                        Resultado = true,
                        Zonas = listaZonas,
                        SumaZonas = listaSumaZonas
                    }, JsonRequestBehavior.AllowGet);
                else
                    return Json(new
                    {
                        Resultado = false,
                        Error = "No existen datos",
                    }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}