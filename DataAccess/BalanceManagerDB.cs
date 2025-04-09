using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Core;
using System.Data.SqlClient;

namespace DataAccess {
    public class BalanceManagerDB {
        public static int RegisterExpense(float amount, DateTime dateTime) {

            int result = 0;

            try {
                using (var context = new AromaCafeBDEntities()) {
                    var gasto = new Gastos {
                        Fecha = dateTime,
                        Monto = amount,
                    };

                    var gastoNuevo = context.Gastos.Add(gasto);
                    return result = context.SaveChanges();
                    
                }
            } catch (SqlException) {
                return -1;
            } catch (InvalidOperationException) {
                return -1;
            } catch (EntityException) {
                return -1;
            } catch (Exception) {
                return -1;
            }
        }
    }
}
