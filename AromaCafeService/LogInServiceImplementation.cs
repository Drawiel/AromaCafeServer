using AromaCafeService.Models;
using DataAccess;
using System;

namespace AromaCafeService
{
    public partial class ServiceImplementation : ILogInManager
    {
        public int CheckTurnOpened(string username)
        {
            return UserManagerDB.CheckTurnOpened(username);
        }

        public int OpenTurn(string username)
        {
            int turnOpened = UserManagerDB.OpenTurn(username);
            return turnOpened;
        }

        public Employee ValidateCredentials(string username, string password)
        {
            Empleado employeeObtained = UserManagerDB.Authenticate(username, password);
            Employee employeeSerialized = new Employee();
            employeeSerialized.EmployeeId = employeeObtained.idEmpleado;
            employeeSerialized.Username = employeeObtained.Usuario;
            employeeSerialized.Password = employeeObtained.CodigoAcceso;
            employeeSerialized.Name = employeeObtained.NombreEmpleado + " " + employeeObtained.ApellidoEmpleado;
            return employeeSerialized;
        }
    }
}
