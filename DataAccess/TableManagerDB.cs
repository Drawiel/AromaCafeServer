using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess {
    public class TableManagerDB {
        public static int ChargeBill(Cobro cobro) {
            try {
                using (var context = new AromaCafeBDEntities()) {
                    var newCobro = new Cobro {
                        idMesa = cobro.idMesa,
                        TotalCobro = cobro.TotalCobro,
                        Fecha = cobro.Fecha,
                        TipoPago = cobro.TipoPago,
                    };

                    var gastoNuevo = context.Cobro.Add(newCobro);

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
