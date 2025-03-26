using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using AromaCafeService.Models;

namespace AromaCafeService
{
    [ServiceContract]
    interface ILogInManager
    {
        [OperationContract]
        Employee ValidateCredentials(string username, string password);

        [OperationContract]
        int OpenTurn(string username);

        [OperationContract]
        int CloseTurn(string password);

        [OperationContract]
        int CheckTurnOpened(string username);
    }
}
