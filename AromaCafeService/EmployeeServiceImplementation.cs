using AromaCafeService.Models;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AromaCafeService {
    public class EmployeeServiceImplementation : IEmployeeManager{

        public int UpdateProfile(Employee employee) {
            var updatedProfile = new Empleado {
                NombreEmpleado = employee.Name,
                ApellidoEmpleado = employee.LastName,
                Correo = employee.Email,
                Usuario = employee.Username,
                DireccionEmpleado = employee.EmployeeAddress,
                CodigoPostal = employee.PostalCode,
                TipoEmpleado = employee.EmployeeType
            };

            int profileUpdated = UserManagerDB.UpdateProfile(updatedProfile);
            return profileUpdated;
        }

        public int RegisterEmployee(Employee employee) {
            var employeeReceived = new Empleado
            {
                NombreEmpleado = employee.Name,
                ApellidoEmpleado = employee.LastName,
                Correo = employee.Email,
                Usuario = employee.Username,
                DireccionEmpleado = employee.EmployeeAddress,
                CodigoPostal = employee.PostalCode,
                TipoEmpleado = employee.EmployeeType
            };
            
            int employeeRegistered = UserManagerDB.RegisterEmployee(employeeReceived);
            return employeeRegistered;
        }

        public int DisableEmployee(Employee employee)
        {
            int employeeDisabled = UserManagerDB.DisableEmployee(employee.employeeId);
            return employeeDisabled;
        }

        public List<Employee> GetAllEmployee()
        {
            return UserManagerDB.GetAllEmployee();
        }

        public Employee GetEmployeeInformation(int employeeId)
        {
            return UserManagerDB.GetEmployee(employeeId);
        }
    }
}
