﻿using AromaCafeService.Models;
using DataAccess;
using DataAccess.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                TipoEmpleado = employee.EmployeeType
            };

            int profileUpdated = UserManagerDB.UpdateProfile(updatedProfile);
            return profileUpdated;
        }

        public string RegisterEmployee(Employee employee) {
            string passwordGenerated = PasswordEncryptor.GeneratePassword();
            var employeeReceived = new Empleado
            {
                NombreEmpleado = employee.Name,
                ApellidoEmpleado = employee.LastName,
                Correo = employee.Email,
                Usuario = employee.Username,
                DireccionEmpleado = employee.EmployeeAddress,
                CodigoPostal = employee.PostalCode,
                TipoEmpleado = employee.EmployeeType,
                CodigoAcceso = passwordGenerated
            };
            string password = UserManagerDB.RegisterEmployee(employeeReceived);
            return password;
        }

        public int DisableEmployee(Employee employee)
        {
            int employeeDisabled = UserManagerDB.DisableEmployee(employee.EmployeeId);
            return employeeDisabled;
        }

        public List<Employee> GetAllEmployee()
        {
            List<Empleado> employeesList = UserManagerDB.GetAllEmployee();
            List<Employee> employees = employeesList
                .Select(e => new Employee
                {
                    Name = e.NombreEmpleado,
                    LastName = e.ApellidoEmpleado,
                    Email = e.Correo,
                    PostalCode = e.CodigoPostal,
                    EmployeeAddress = e.DireccionEmpleado,
                    EmployeeType = e.TipoEmpleado
                })
                .ToList();

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
                EmployeeType = employeeInformation.TipoEmpleado
            };

            return employee;
        }

    }
}
