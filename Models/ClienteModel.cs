using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NeorisLRE.Models
{
    /// <summary>
    /// Request para entidad cliente
    /// </summary>
    public class ClienteModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "El ESTADO es requerido.")]
        public string Estado { get; set; }
        /// <summary>
        /// Código deL cliente.
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "El código del cliente es requerido.")]
        public int IdCliente { get; set; }
        /// <summary>
        /// Código de la persona.
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "El código de la persona es requerido.")]
        public int IdPersona { get; set; }
        /// <summary>
        /// Nombre del Cliente.
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Nombre del cliente es requerida.")]
        [StringLength(150, MinimumLength = 10, ErrorMessage = "El nombre puede tener hasta 150 caracteres.")]
        public string Cliente { get; set; }
    }
}