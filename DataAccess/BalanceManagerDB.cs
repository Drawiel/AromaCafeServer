using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Core;
using System.Data.SqlClient;

namespace DataAccess {
    public class BalanceManagerDB {
        public static int RegisterExpense(Gastos gasto) {
            try {
                using (var context = new AromaCafeBDEntities()) {
                    var newGasto = new Gastos {
                        Fecha = gasto.Fecha,
                        Monto = gasto.Monto,
                    };

                    var gastoNuevo = context.Gastos.Add(newGasto);

                    int result;
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
