using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class FinancialMovementDTO
    {
        public float Monto { get; set; }
        public string Fecha { get; set; }
        public string Movimiento { get; set; } // "Ingreso", "Gasto", "Venta"
    }

}
