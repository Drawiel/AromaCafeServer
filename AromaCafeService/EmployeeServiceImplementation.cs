using AromaCafeService.Models;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AromaCafeService {
    public partial class ServiceImplementation : IEmployeeManager{

        public int UpdateProfile(Employee employee) {
            var updatedProfile = new Empleado {
                NombreEmpleado = employee.Name,
                ApellidoEmpleado = employee.LastName,
                Correo = employee.Email,
                Usuario = employee.Username,
                DireccionEmpleado = employee.EmployeeAddress,
                CodigoPostal = employee.PostalCode,
                TipoEmpleado = employee.EmployeeType,
                idEmpleado = employee.EmployeeId
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
            int employeeDisabled = UserManagerDB.DisableEmployee(employee.EmployeeId);
            return employeeDisabled;
        }

        public List<Employee> GetAllEmployee()
        {
            List<Empleado> employeesList = UserManagerDB.GetAllEmployee();
            List<Employee> employees = new List<Employee>();

            foreach (Empleado e in employeesList) {
                Employee employee = new Employee {
                    Name = e.NombreEmpleado,
                    LastName = e.ApellidoEmpleado,
                    Email = e.Correo,
                    PostalCode = e.CodigoPostal,
                    EmployeeAddress = e.DireccionEmpleado,
                    EmployeeType = e.TipoEmpleado,
                    Username = e.Usuario,
                    EmployeeId = e.idEmpleado
                };
                employees.Add(employee);
            }
            return employees;
        }

        public Employee GetEmployeeInformation(int employeeId)
        {
            Empleado employeeInformation = UserManagerDB.GetEmployee(employeeId);
            Employee employee = new Employee() {
                Name = employeeInformation.NombreEmpleado,
                LastName = employeeInformation.ApellidoEmpleado,
                Email = employeeInformation.Correo,
                PostalCode = employeeInformation.CodigoPostal,
                EmployeeAddress = employeeInformation.DireccionEmpleado,
                EmployeeType = employeeInformation.TipoEmpleado,
                Username = employeeInformation.Usuario
            };

            return employee;
        }

        public int UpdateAccessCodeProfile(Employee employee) {
            var updatedProfile = new Empleado {
                CodigoAcceso = employee.Password,
                idEmpleado = employee.EmployeeId
            };

            int profileUpdated = UserManagerDB.UpdateAccessCodeProfile(updatedProfile);
            return profileUpdated;
        }

    }
}
