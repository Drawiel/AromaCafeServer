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

        public static int RegisterEmployee(Empleado employeeReceived)
        {
            int employeeRegistered = 0;

            try
            {
                using (var context = new AromaCafeBDEntities())
                {
                    var employee = context.Empleado.Add(employeeReceived);
                    if (employee != null)
                    {
                        employeeRegistered = 1;
                    }
                }
            }
            catch (SqlException)
            {
                employeeRegistered = -1;
            }
            catch (InvalidOperationException)
            {
                employeeRegistered = -1;
            }
            catch (EntityException)
            {
                employeeRegistered = -1;
            }
            catch (Exception)
            {
                employeeRegistered = -1;
            }
            return employeeRegistered;
        }

        public static int UpdateProfile(Empleado updatedEmployee) {

            int profileUpdated = 0;

            try {
                using (var context = new AromaCafeBDEntities()) {
                    var update = (from employee in context.Empleado where employee.idEmpleado == updatedEmployee.idEmpleado select employee).Single();
                    update.NombreEmpleado = updatedEmployee.NombreEmpleado;
                    update.ApellidoEmpleado = updatedEmployee.ApellidoEmpleado;
                    update.Correo = updatedEmployee.Correo;
                    update.TipoEmpleado = updatedEmployee.TipoEmpleado;
                    update.DireccionEmpleado = updatedEmployee.DireccionEmpleado;
                    update.Usuario = updatedEmployee.Usuario;
                    update.CodigoAcceso = updatedEmployee.CodigoAcceso;
                    update.CodigoPostal = updatedEmployee.CodigoPostal;
                    update.DireccionEmpleado = updatedEmployee.DireccionEmpleado;
                    profileUpdated = context.SaveChanges();
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
    }
}
