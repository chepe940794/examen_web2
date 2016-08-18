using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExamenApi.Models
{
    public class Clientes
    {
        [Key]
        public int Id { get; set; }
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string FechaNacimiento { get; set; }
        public string Direccion { get; set; }
        public string EstadoCivil { get; set; }
        public string Sexo { get; set; }
        public string FechaIngreso { get; set; }
        public string Tipo { get; set; }
        public double Descuento { get; set; }
    }
}