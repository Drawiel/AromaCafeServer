using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using AromaCafeService.Models;

namespace AromaCafeService {

    [ServiceContract]
    interface IEmployeeManager {

        [OperationContract]
        int UpdateProfile(Employee employee);

        [OperationContract]
        string RegisterEmployee(Employee employee);

        [OperationContract]
        int DisableEmployee(Employee employee);

        [OperationContract]
        List<Employee> GetAllEmployee();

        [OperationContract]
        Employee GetEmployeeInformation(int employeeId);

        [OperationContract]
        int UpdateAccessCodeProfile(Employee employee);
    }
}
