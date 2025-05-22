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
        public List<SalesData> GetSalesReportByRange(DateTime fromDate, DateTime toDate)
        {
            var salesList = SalesManagerDB.GetSalesByDateRange(fromDate, toDate);

            int index = 1;
            return salesList.Select(s => new SalesData
            {
                Index = index++,
                TableName = s.TableName,
                PeopleCount = s.PeopleCount,
                Total = s.Total,
                PaymentMethod = s.PaymentMethod,
                SaleDate = s.SaleDate
            }).ToList();
        }

        public List<SaleByWaiterData> GetSalesReportByWaiterRange(DateTime fromDate, DateTime toDate)
        {
            var salesList = SalesManagerDB.GetSalesByWaiterInDateRange(fromDate, toDate);

            int index = 1;
            return salesList.Select(s => new SaleByWaiterData
            {
                Index = index++,
                FullName = s.FullName,
                TotalSale = s.TotalSale
            }).ToList();
        }
        public List<FinancialMovement> GetFinancialReportByRange(DateTime fromDate, DateTime toDate)
        {
            var movementList = SalesManagerDB.GetFinancialMovementsByDateRange(fromDate, toDate);

            int index = 1;
            return movementList.Select(m => new FinancialMovement
            {
                Index = index++,
                Monto = m.Monto,
                Fecha = m.Fecha,
                Movimiento = m.Movimiento
            }).ToList();
        }


    }
}
