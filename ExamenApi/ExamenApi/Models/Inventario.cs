using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExamenApi.Models
{
    public class Inventario
    {
        [Key]
        public int Id { get; set; }
        public string Cantidad { get; set; }
        public string CantidadMinima { get; set; }
        public string CantidadMaxima { get; set; }
        public string Tipo { get; set; }

        public int ProductosID { get; set; }
        public virtual Productos Productos { get; set; }
    }
}