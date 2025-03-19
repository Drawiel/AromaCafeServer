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
            catch (SqlException sqlException)
            {
                employee.idEmpleado = -1;
            }
            catch (InvalidOperationException invalidOperationException)
            {
                employee.idEmpleado = -1;
            }
            catch (EntityException entityException)
            {
                employee.idEmpleado = -1;
            }
            catch (Exception exception)
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
            catch (SqlException sqlException)
            {
                turnOpened = -1;
            }
            catch (InvalidOperationException invalidOperationException)
            {
                turnOpened = -1;
            }
            catch (EntityException entityException)
            {
                turnOpened = -1;
            }
            catch (Exception exception)
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
            catch (SqlException sqlException)
            {
                turnOpened = -1;
            }
            catch (InvalidOperationException invalidOperationException)
            {
                turnOpened = -1;
            }
            catch (EntityException entityException)
            {
                turnOpened = -1;
            }
            catch (Exception exception)
            {
                turnOpened = -1;
            }
            return turnOpened;
        }

        public static int UpdateProfile(Empleado updatedEmployee) {

            int profileUpdated = 0;

            try {
                using (var context = new AromaCafeBDEntities()) {
                    var update = (from employee in context.Empleado where employee.Correo == updatedEmployee.Correo select employee).Single();
                    update = updatedEmployee;
                    profileUpdated = 1;
                }
            } catch (SqlException sqlException) {
                profileUpdated = -1;
            } catch (InvalidOperationException invalidOperationException) {
                profileUpdated = -1;
            } catch (EntityException entityException) {
                profileUpdated = -1;
            } catch (Exception exception) {
                profileUpdated = -1;
            }
            return profileUpdated;
        }

        public static int DisableEmployee(int employeeId)
        {

            int profileDesabled = 0;

            try
            {
                using (var context = new AromaCafeBDEntities())
                {
                    var employee = context.Empleado.SingleOrDefault(e => e.idEmpleado == employeeId);

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
            catch (SqlException sqlException)
            {
                profileDesabled = -1;
            }
            catch (InvalidOperationException invalidOperationException)
            {
                profileDesabled = -1;
            }
            catch (EntityException entityException)
            {
                profileDesabled = -1;
            }
            catch (Exception exception)
            {
                profileDesabled = -1;
            }
            return profileDesabled;
        }

        public static Empleado GetEmployee(int employeeId)
        {
            try
            {
                using (var context = new AromaCafeBDEntities())
                {
                    var employeeEntity = context.Empleado.SingleOrDefault(e => e.idEmpleado == employeeId);

                    if (employeeEntity == null)
                        return null;

                    return new Employee
                    {
                        EmployeeId = employeeEntity.idEmpleado,
                        Name = employeeEntity.NombreEmpleado,
                        LastName = employeeEntity.ApellidoEmpleado,
                        Email = employeeEntity.Correo,
                        PostalCode = employeeEntity.CodigoPostal,
                        EmployeeAddress = employeeEntity.DireccionEmpleado,
                        Username = employeeEntity.Usuario,
                        EmployeeType = employeeEntity.TipoEmpleado
                    };
                }
            }
            catch (SqlException sqlException)
            {
                return null;
            }
            catch (InvalidOperationException invalidOperationException)
            {
                return null;
            }
            catch (EntityException entityException)
            {
                return null;
            }
            catch (Exception exception)
            {
                return null;
            }
        }

        public static List<Employee> GetAllEmployee()
        {
            try
            {
                using (var context = new AromaCafeBDEntities())
                {
                    return context.Empleado
                        .Select(e => new Employee
                        {
                            EmployeeId = e.idEmpleado,
                            Name = e.NombreEmpleado,
                            LastName = e.ApellidoEmpleado,
                            Email = e.Correo,
                            PostalCode = e.CodigoPostal,
                            EmployeeAddress = e.DireccionEmpleado,
                            Username = e.Usuario,
                            EmployeeType = e.TipoEmpleado
                        }).ToList();
                }
            }
            catch (SqlException sqlException)
            {
                return null;
            }
            catch (InvalidOperationException invalidOperationException)
            {
                return null;
            }
            catch (EntityException entityException)
            {
                return null;
            }
            catch (Exception exception)
            {
                return null;
            }
        }
    }
}
