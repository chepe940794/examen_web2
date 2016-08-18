using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExamenApi.Models
{
    public class Productos
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Marca { get; set; }
        public string Familia { get; set; }
        public string CasaFabricacion { get; set; }
        public string TipoUnidad { get; set; }
        public string Departamento { get; set; }
        public bool Activo { get; set; }
        public string FechaIngreso { get; set; }
        public string Unidad { get; set; }
        public double Impuesto { get; set; }
    }
}