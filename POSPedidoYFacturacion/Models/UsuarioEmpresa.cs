using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlphaSoftPOSOffline.Models
{
    public class UsuarioEmpresa
    {
        public Guid Id { get; set; }

        [Display(Name = "Usuario")]
        public string UsuarioId { get; set; }
        
        [ForeignKey(nameof(UsuarioId))]
        public Usuario Usuario { get; set; }

        [Display(Name = "Empresa")]
        public int EmpresaId { get; set; }
        
        [ForeignKey(nameof(EmpresaId))]
        public Empresa Empresa { get; set; }
    }
}