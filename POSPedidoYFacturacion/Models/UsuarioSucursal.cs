using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlphaSoftPOSOffline.Models
{
    public class UsuarioSucursal
    {
        public Guid Id { get; set; }

        [Display(Name = "Usuario")]
        public string UsuarioId { get; set; }
        
        [ForeignKey(nameof(UsuarioId))]
        public Usuario Usuario { get; set; }

        [Display(Name = "Sucursal")]
        public int SucursalId { get; set; }
        
        [ForeignKey(nameof(SucursalId))]
        public Sucursal Sucursal { get; set; }
    }
}