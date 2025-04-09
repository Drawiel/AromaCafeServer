using AromaCafeService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace AromaCafeService {

    [ServiceContract]
    interface ITableManager {
        [OperationContract]
        int ChargeBill(Charge charge);
    }
}
