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

        [Fact]
        public void TestUpdateProfileSuccess() {
            Empleado employee = new Empleado {
                idEmpleado = 2,
                NombreEmpleado = "Eduardo",
                ApellidoEmpleado = "Perez",
                DireccionEmpleado = "Calle Falsa 34",
                Correo = "juanperez@emal.com",
                TipoEmpleado = "Gerente",
                Usuario = "jperez",
            };
            
            int employeesObtained = UserManagerDB.UpdateProfile(employee);

            Assert.Equal(1, employeesObtained);
        }

        [Fact]
        public void TestUpdateAccessCodeProfileSuccess() {
            Empleado employee = new Empleado {
                idEmpleado = 2,
                CodigoAcceso = "54321"
            };

            int employeesUpdated = UserManagerDB.UpdateProfile(employee);

            Assert.Equal(1, employeesUpdated);
        }

        [Fact]
        public void TestGetEmployeeSuccess() {

            Empleado employeesObtained = UserManagerDB.GetEmployee(2);

            Assert.Equal(2, employeesObtained.idEmpleado);
        }

        [Fact]
        public void TestGetAllEmployeeSuccess() {

            List<Empleado> employeesObtained = UserManagerDB.GetAllEmployee();

            Assert.NotEmpty(employeesObtained);
        }
    }
}