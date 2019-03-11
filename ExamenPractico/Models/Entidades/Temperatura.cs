using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamenPractico.Models.Entidades
{
    public class Temperatura
    {
        public Main main { get; set; }
    }

    public class Main
    {
        public string temp { get; set; }
        public string pressure { get; set; }
        public string humidity { get; set; }
        public string temp_min { get; set; }
        public string temp_max { get; set; }
        public string sea_level { get; set; }
        public string grnd_level { get; set; }
    }
}