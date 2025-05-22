using AromaCafeService.Models;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
        public int NewTable(TableCustomer table)
        {
            string tableName = table.TableName;
            int numberPeople = table.NumberPeople;

            return TableManagerDB.NewTable(tableName, numberPeople);
        }
        public List<TableCustomer> GetActiveAndClosedTables()
        {
            var mesas = TableManagerDB.GetActiveAndClosedTablesList();

            return mesas.Select(m => new TableCustomer
            {
                TableId = m.idMesa,
                TableName = m.NombreMesa,
                NumberPeople = (int)m.NumeroPersonas,
                TableStatus = m.EstadoMesa
            }).ToList();
        }

        public int CloseTable(int tableId)
        {
            int closed = TableManagerDB.CloseTable(tableId);
            return closed;
        }
    }
}
