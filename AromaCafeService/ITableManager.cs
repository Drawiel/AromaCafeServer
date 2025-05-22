using AromaCafeService.Models;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace AromaCafeService {

    [ServiceContract]
    interface ITableManager {
        [OperationContract]
        int ChargeBill(Charge charge);
        [OperationContract]
        int NewTable(TableCustomer table);
        [OperationContract]
        List<TableCustomer> GetActiveAndClosedTables();
        [OperationContract]
        List<SalesData> GetSalesReportByRange(DateTime fromDate, DateTime toDate);
        [OperationContract]
        List<SaleByWaiterData> GetSalesReportByWaiterRange(DateTime fromDate, DateTime toDate);
        [OperationContract]
        List<FinancialMovement> GetFinancialReportByRange(DateTime fromDate, DateTime toDate);


    }

}
