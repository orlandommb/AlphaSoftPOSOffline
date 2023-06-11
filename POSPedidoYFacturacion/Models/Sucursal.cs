using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlphaSoftPOSOffline.Models
{
    public class Sucursal
    {
        public int Id { get; set; }

        public int EmpresaId { get; set; }

        [ForeignKey("EmpresaId")]
        public Empresa Empresa { get; set; }

        public string Nombre { get; set; }

    }
}
