using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExamenApi.Models
{
    public class Facturas
    {
        [Key]
        public int Id { get; set; }
        public double MontoTotal { get; set; }
        public double SubTotal { get; set; }
        public string Detalle { get; set; }

        public int ClienteID { get; set; }
        public virtual Clientes Cliente { get; set; }

        public int ProductosID { get; set; }
        public virtual ICollection<Productos> Productos { get; set; }

        public int InventarioID { get; set; }
        public virtual Inventario Inventario { get; set; }
    }
}