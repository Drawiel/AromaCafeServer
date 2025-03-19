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
    }
}
