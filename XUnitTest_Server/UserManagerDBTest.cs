using Xunit;
using DataAccess;

namespace XUnitTest_Server
{
    public class UserManagerDBTest
    {
        [Fact]
        public void TestAuthenticateSuccess()
        {
            string username = "zaidskate";
            string password = "12345";

            Empleado employee = UserManagerDB.Authenticate(username, password);
            Assert.NotEqual(0, employee.idEmpleado);
        }

        [Fact]
        public void TestCheckTurnOpenedSuccess()
        {
            string username = "zaidskate";

            int turnOpened = UserManagerDB.CheckTurnOpened(username);
            Assert.NotEqual(0, turnOpened);
        }

        [Fact]
        public void TestOpenTurnSuccess()
        {
            string username = "zaidskate";

            int turnOpened = UserManagerDB.OpenTurn(username);
            Assert.NotEqual(0, turnOpened);
        }

        [Fact]
        public void TestRegisterEmployeeSuccess()
        {
            Empleado employee = new Empleado
            {
                NombreEmpleado = "Zaid",
                ApellidoEmpleado = "Vazquez",
                DireccionEmpleado = "Andador Capricornio 34",
                Correo = "zaidskate@hotmail.com",
                CodigoAcceso = "54321",
                TipoEmpleado = "Mesero",
                Usuario = "zaidvr19",
            };

            int registered = UserManagerDB.RegisterEmployee(employee);
            Assert.Equal(1, registered);
        }

        [Fact]
        public void TestGetWorkingEmployeesSuccess()
        {
            Empleado employee = new Empleado
            {
                NombreEmpleado = "Zaid",
                ApellidoEmpleado = "Vazquez",
                DireccionEmpleado = "Andador Capricornio 34",
                Correo = "zaidskate@hotmail.com",
                CodigoAcceso = "54321",
                TipoEmpleado = "Mesero",
                Usuario = "zaidvr19",
            };
            List<Empleado> employeesExpected = new List<Empleado> { employee };
            List<Empleado> employeesObtained = UserManagerDB.GetWorkingEmployees();

            Assert.Equal(employeesExpected, employeesObtained);
        }
    }
}