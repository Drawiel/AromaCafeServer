using DataAccess.Helpers;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public static class UserManagerDB
    {
        public static Empleado Authenticate(string username, string password)
        {
            string hashedPassword = PasswordEncryptor.HashPassword(password);
            Empleado employee = new Empleado();
            try
            {
                using (var context = new AromaCafeBDEntities())
                {
                    employee = context.Empleado.FirstOrDefault(a => a.Usuario == username && a.CodigoAcceso == password);
                }
            } 
            catch (SqlException)
            {
                employee.idEmpleado = -1;
            }
            catch (InvalidOperationException)
            {
                employee.idEmpleado = -1;
            }
            catch (EntityException)
            {
                employee.idEmpleado = -1;
            }
            catch (Exception)
            {
                employee.idEmpleado = -1;
            }
            return employee;
        }

        public static int CheckTurnOpened(string username)
        {
            int turnOpened = 0;
            try
            {
                using (var context = new AromaCafeBDEntities())
                {
                    var employee = context.Empleado.FirstOrDefault(e => e.Usuario == username);
                    if (employee != null)
                    {
                        if ((bool)employee.EnTurno)
                        {
                            turnOpened = 1;
                        }
                    }
                }
            }
            catch (SqlException)
            {
                turnOpened = -1;
            }
            catch (InvalidOperationException)
            {
                turnOpened = -1;
            }
            catch (EntityException)
            {
                turnOpened = -1;
            }
            catch (Exception)
            {
                turnOpened = -1;
            }
            return turnOpened;
        }

        public static int OpenTurn(string username)
        {
            int turnOpened = 0;
            try
            {
                using (var context = new AromaCafeBDEntities())
                {
                    var employee = context.Empleado.FirstOrDefault(e => e.Usuario == username);
                    if (employee != null)
                    {
                        employee.EnTurno = true;
                        context.SaveChanges();
                        turnOpened = 1;
                    }
                }
            }
            catch (SqlException)
            {
                turnOpened = -1;
            }
            catch (InvalidOperationException)
            {
                turnOpened = -1;
            }
            catch (EntityException)
            {
                turnOpened = -1;
            }
            catch (Exception)
            {
                turnOpened = -1;
            }
            return turnOpened;
        }

        public static string RegisterEmployee(Empleado employeeReceived)
        {
            string employeeRegistered = "error";

            try
            {
                using (var context = new AromaCafeBDEntities())
                {
                    var employee = context.Empleado.Add(employeeReceived);
                    if (employee != null)
                    {
                        employeeRegistered = employeeReceived.CodigoAcceso;
                        context.SaveChanges();
                    }
                }
            }
            catch (SqlException)
            {
                employeeRegistered = "error";
            }
            catch (InvalidOperationException)
            {
                employeeRegistered = "error";
            }
            catch (EntityException)
            {
                employeeRegistered = "error";
            }
            catch (Exception)
            {
                employeeRegistered = "error";
            }
            return employeeRegistered;
        }

        public static int UpdateProfile(Empleado updatedEmployee) {

            int profileUpdated = 0;

            try {
                using (var context = new AromaCafeBDEntities()) {
                    var update = (from employee in context.Empleado where employee.Correo == updatedEmployee.Correo select employee).Single();
                    update = updatedEmployee;
                    profileUpdated = 1;
                }
            } catch (SqlException) {
                profileUpdated = -1;
            } catch (InvalidOperationException) {
                profileUpdated = -1;
            } catch (EntityException) {
                profileUpdated = -1;
            } catch (Exception) {
                profileUpdated = -1;
            }
            return profileUpdated;
        }

        public static int DisableEmployee(int employeeId)
        {

            int profileDisabled = 0;

            try
            {
                using (var context = new AromaCafeBDEntities())
                {
                    var employee = context.Empleado.FirstOrDefault(e => e.idEmpleado == employeeId);

                    if (employee != null)
                    {
                        employee.TipoEmpleado = "Inhabil"; 
                        context.SaveChanges();
                        profileDisabled = 1; 
                    }
                    else
                    {
                        profileDisabled = -2; 
                    }
                }
            }
            catch (SqlException )
            {
                profileDisabled = -1;
            }
            catch (InvalidOperationException )
            {
                profileDisabled = -1;
            }
            catch (EntityException)
            {
                profileDisabled = -1;
            }
            catch (Exception)
            {
                profileDisabled = -1;
            }
            return profileDisabled;
        }

        public static Empleado GetEmployee(int employeeId)
        {
            try
            {
                using (var context = new AromaCafeBDEntities())
                {
                    var employee = context.Empleado.FirstOrDefault(e => e.idEmpleado == employeeId);

                    if (employee == null)
                        return null;

                    return employee;
                }
            }
            catch (SqlException)
            {
                return null;
            }
            catch (InvalidOperationException)
            {
                return null;
            }
            catch (EntityException)
            {
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static List<Empleado> GetAllEmployee()
        {
            try
            {
                using (var context = new AromaCafeBDEntities())
                {
                    return context.Empleado.ToList();
                }
            }
            catch (SqlException)
            {
                return null;
            }
            catch (InvalidOperationException)
            {
                return null;
            }
            catch (EntityException)
            {
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static List<Empleado> GetWorkingEmployees()
        {
            List<Empleado> employees = new List<Empleado>();
            try
            {
                using (var context = new AromaCafeBDEntities())
                {
                    employees = (List<Empleado>)context.Empleado.Where(e => e.EnTurno == true);
                }
            }
            catch (SqlException)
            {
                employees = null;
            }
            catch (InvalidOperationException)
            {
                employees = null;
            }
            catch (EntityException)
            {
                employees = null;
            }
            catch (Exception)
            {
                employees = null;
            }
            return employees;
        }

        public static int CloseTurn(string password)
        {
            int turnClosed = 0;
            try
            {
                using (var context = new AromaCafeBDEntities())
                {
                    var employee = context.Empleado.FirstOrDefault(e => e.CodigoAcceso == password);
                    if (employee != null)
                    {
                        employee.EnTurno = false;
                        context.SaveChanges();
                        turnClosed = 1;
                    }
                }
            }
            catch (SqlException)
            {
                turnClosed = -1;
            }
            catch (InvalidOperationException)
            {
                turnClosed = -1;
            }
            catch (EntityException)
            {
                turnClosed = -1;
            }
            catch (Exception)
            {
                turnClosed = -1;
            }
            return turnClosed;
        }
        
        public static List<string> GetAllPasswords()
        {
            List<string> passwords = new List<string>();
            try
            {
                using (var context = new AromaCafeBDEntities())
                {
                    passwords = context.Empleado.Select(e => e.CodigoAcceso).ToList();
                }
            }
            catch (SqlException)
            {
                passwords = null;
            }
            catch (InvalidOperationException)
            {
                passwords = null;
            }
            catch (EntityException)
            {
                passwords = null;
            }
            catch (Exception)
            {
                passwords = null;
            }
            return passwords;
        }
    }
}
