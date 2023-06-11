using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlphaSoftPOSOffline.Models
{
    public class Area
    {
        public int EmpresaId { get; set; }

        [ForeignKey("EmpresaId")]
        public Empresa Empresa { get; set; }
        
        public int SucursalId { get; set; }

        [ForeignKey("SucursalId")]
        public Sucursal Sucursal { get; set; }
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre del Area es obligatorio!")]
        public string Nombre { get; set; }

        public List<Mesa> Mesas { get; set; }

    }
}
