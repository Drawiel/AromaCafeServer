using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess {
    public class TableManagerDB {

        public static int NewTable(string tableName, int numberPeople)
        {
            try
            {
                using (var context = new AromaCafeBDEntities())
                {
                    var newTable = new Mesa
                    {
                        NombreMesa = tableName,
                        NumeroPersonas = numberPeople,
                        EstadoMesa = "Abierta"
                    };

                    var gastoNuevo = context.Mesa.Add(newTable);

                    int result;
                    return result = context.SaveChanges();

                }
            }
            catch (SqlException)
            {
                return -1;
            }
            catch (InvalidOperationException)
            {
                return -1;
            }
            catch (EntityException)
            {
                return -1;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public static List<Mesa> GetActiveAndClosedTablesList()
        {
            try
            {
                using (var context = new AromaCafeBDEntities())
                {
                    var tables = context.Mesa
                        .Where(m => m.EstadoMesa == "Abierta" || m.EstadoMesa == "Cerrada")
                        .OrderBy(m => m.NombreMesa)  // Optional: order by table name
                        .ToList();

                    return tables;
                }
            }
            catch (SqlException)
            {
                return new List<Mesa>();
            }
            catch (InvalidOperationException)
            {
                return new List<Mesa>();
            }
            catch (EntityException)
            {
                return new List<Mesa>();
            }
            catch (Exception)
            {
                return new List<Mesa>();
            }
        }

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

                    var mesa = context.Mesa.FirstOrDefault(m => m.idMesa == cobro.idMesa);
                    mesa.EstadoMesa = "Cerrado";

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
