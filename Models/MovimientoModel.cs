using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NeorisLRE.Models
{
    public class MovimientoModel
    {
        public int IdMovimiento { get; set; }
        public DateTime Fecha { get; set; }
        public short IdTipoMovimiento { get; set; }
        public double Valor { get; set; }
        public double Saldo { get; set; }
        public short IdCliente { get; set; }
    }
}