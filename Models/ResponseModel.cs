using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NeorisLRE.Models
{
    /// <summary>
    /// Respuesta Generica para API
    /// </summary>
    public class ResponseModel
    {
        /// <summary>
        /// Código de la respuesta, 0 (cero) si la respuesta es OK.
        /// </summary>
        public int Codigo { get; set; }
        /// <summary>
        /// Mensaje que muestra la razón del error.
        /// </summary>
        public string Mensaje { get; set; }

        /// <summary>
        /// Devuelve el ID o código esperado de alguna inserción o actualziación
        /// </summary>
        public string Referencia { get; set; }
    }
}