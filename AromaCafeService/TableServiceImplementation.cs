using AromaCafeService.Models;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AromaCafeService {
    partial class ServiceImplementation : ITableManager {
        public int ChargeBill(Charge charge) {
            var newCobro = new Cobro {
                idMesa = charge.TableId,
                TotalCobro = charge.TotalCharge,
                TipoPago = charge.TypePayment,
                Fecha = charge.Date
            };
            return TableManagerDB.ChargeBill(newCobro);
        }
    }
}
