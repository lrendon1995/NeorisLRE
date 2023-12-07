
using NeorisLRE.BO.Cliente;
using NeorisLRE.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NeorisLRE.Code
{
    internal static class ClienteCode
    {
        internal static string CrearCliente(ClienteModel objeto)
        {
            var json = JsonConvert.SerializeObject(objeto);
            return ClienteEntidad.GrabarCliente(JsonConvert.DeserializeObject<DTO.ClienteDTO>(json));
        }
    }
}