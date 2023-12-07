using NeorisLRE.BO.Cliente;
using NeorisLRE.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NeorisLRE.Code
{
    internal static class MovimientoCode
    {
        internal static string CrearMovimiento(MovimientoModel objeto)
        {
            var json = JsonConvert.SerializeObject(objeto);
            return MovimientoEntidad.GrabarMovimiento(JsonConvert.DeserializeObject<DTO.MovimientoDTO>(json));
        }
    }
}