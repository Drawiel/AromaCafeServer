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
        int CloseTable(int tableId);
        [OperationContract]
        List<TableCustomer> GetActiveAndClosedTables();
    }

}
