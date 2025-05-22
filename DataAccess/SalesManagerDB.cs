using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Data.SqlClient;
using System.Linq;

namespace DataAccess
{
    public class SalesManagerDB
    {
        public static List<SalesDataDTO> GetSalesByDateRange(DateTime startDate, DateTime endDate)
        {
            var result = new List<SalesDataDTO>();
            try
            {
                using (var context = new AromaCafeBDEntities())
                {
                    result = (from cobro in context.Cobro
                              join mesa in context.Mesa on cobro.idMesa equals mesa.idMesa
                              where cobro.Fecha >= startDate && cobro.Fecha <= endDate
                              select new
                              {
                                  mesa.NombreMesa,
                                  mesa.NumeroPersonas,
                                  cobro.TotalCobro,
                                  cobro.TipoPago,
                                  cobro.Fecha
                              }).AsEnumerable()  // Cambia aquí a ejecución en memoria
                              .Select(c => new SalesDataDTO
                              {
                                  TableName = c.NombreMesa,
                                  PeopleCount = c.NumeroPersonas ?? 0,
                                  Total = (float)c.TotalCobro,
                                  PaymentMethod = c.TipoPago,
                                  SaleDate = c.Fecha.HasValue ? c.Fecha.Value.ToString("dd/MM/yyyy") : "Fecha no disponible"
                              })
                              .ToList();
                }


            }
            catch (SqlException)
            {
                result = new List<SalesDataDTO>();
            }
            catch (InvalidOperationException)
            {
                result = new List<SalesDataDTO>();
            }
            catch (EntityException)
            {
                result = new List<SalesDataDTO>();
            }
            catch (Exception e)
            {
                result = new List<SalesDataDTO>();
            }

            return result;
        }

        public static List<SaleByWaiterDTO> GetSalesByWaiterInDateRange(DateTime startDate, DateTime endDate)
        {
            var result = new List<SaleByWaiterDTO>();
            try
            {
                using (var context = new AromaCafeBDEntities())
                {
                    result = (from pedido in context.Pedido
                              join empleado in context.Empleado on pedido.idEmpleado equals empleado.idEmpleado
                              join mesa in context.Mesa on pedido.idMesa equals mesa.idMesa
                              join cobro in context.Cobro on mesa.idMesa equals cobro.idMesa
                              where cobro.Fecha >= startDate && cobro.Fecha <= endDate
                              select new
                              {
                                  empleado.NombreEmpleado,
                                  empleado.ApellidoEmpleado,
                                  pedido.SubtotalPedido
                              })
                              .AsEnumerable() // Forzamos ejecución en memoria
                              .GroupBy(p => p.NombreEmpleado + " " + p.ApellidoEmpleado)
                              .Select(g => new SaleByWaiterDTO
                              {
                                  FullName = g.Key,
                                  TotalSale = (float)g.Sum(x => x.SubtotalPedido)
                              })
                              .ToList();
                }

            }
            catch (SqlException)
            {
                result = new List<SaleByWaiterDTO>();
            }
            catch (InvalidOperationException)
            {
                result = new List<SaleByWaiterDTO>();
            }
            catch (EntityException)
            {
                result = new List<SaleByWaiterDTO>();
            }
            catch (Exception)
            {
                result = new List<SaleByWaiterDTO>();
            }

            return result;
        }

        public static List<FinancialMovementDTO> GetFinancialMovementsByDateRange(DateTime startDate, DateTime endDate)
        {
            var result = new List<FinancialMovementDTO>();

            try
            {
                using (var context = new AromaCafeBDEntities())
                {
                    // Ventas desde Cobro
                    var ventas = (from c in context.Cobro
                                  where c.Fecha == startDate
                                  select new { c.TotalCobro, c.Fecha })
                                 .AsEnumerable() // aquí pasamos a memoria
                                 .Select(c => new FinancialMovementDTO
                                 {
                                     Monto = (float)c.TotalCobro,
                                     Fecha = c.Fecha.HasValue ? c.Fecha.Value.ToString("dd/MM/yyyy") : "Fecha no disponible",
                                     Movimiento = "Venta"
                                 })
                                 .ToList();

                    // Ingresos
                    var ingresos = (from i in context.Ingresos
                                    where i.Fecha == startDate
                                    select new { i.Monto, i.Fecha })
                                   .AsEnumerable()
                                   .Select(i => new FinancialMovementDTO
                                   {
                                       Monto = (float)i.Monto,
                                       Fecha = i.Fecha.ToString("dd/MM/yyyy"),
                                       Movimiento = "Ingreso"
                                   })
                                   .ToList();

                    // Gastos
                    var gastos = (from g in context.Gastos
                                  where g.Fecha == startDate
                                  select new { g.Monto, g.Fecha })
                                 .AsEnumerable()
                                 .Select(g => new FinancialMovementDTO
                                 {
                                     Monto = (float)g.Monto,
                                     Fecha = g.Fecha.ToString("dd/MM/yyyy"),
                                     Movimiento = "Gasto"
                                 })
                                 .ToList();

                    // Unir todas las listas
                    result = ventas
                             .Concat(ingresos)
                             .Concat(gastos)
                             .ToList();
                }
            }
            catch (SqlException)
            {
                result = new List<FinancialMovementDTO>();
            }
            catch (InvalidOperationException)
            {
                result = new List<FinancialMovementDTO>();
            }
            catch (EntityException)
            {
                result = new List<FinancialMovementDTO>();
            }
            catch (Exception)
            {
                result = new List<FinancialMovementDTO>();
            }

            return result;
        }


    }
}
