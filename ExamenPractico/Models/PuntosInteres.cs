//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ExamenPractico.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class PuntosInteres
    {
        public int PuntoInteres { get; set; }
        public Nullable<decimal> Latitud { get; set; }
        public Nullable<decimal> Longitud { get; set; }
        public string Descripcion { get; set; }
        public Nullable<decimal> Venta { get; set; }
        public Nullable<int> IdZona { get; set; }
    
        public virtual Zona Zona { get; set; }
        public virtual Zona Zona1 { get; set; }
    }
}
