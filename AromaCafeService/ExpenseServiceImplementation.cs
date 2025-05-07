using AromaCafeService.Models;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AromaCafeService {
    public partial class ServiceImplementation : IExpenseManager {
        public List<Expense> GetAllExpensesByDay(DateTime date)
        {
            var gastos = BalanceManagerDB.ObtainExpensesByDay(date);
            if (gastos == null)
                return new List<Expense>();

            return gastos.Select(g => new Expense
            {
                ExpenseId = g.Id,
                Amount = g.Monto,
                DateTime = g.Fecha
            }).ToList();
        }

        public int RegisterExpense(Expense expense) {
            var newExpense = new Gastos {
                Monto = expense.Amount,
                Fecha = expense.DateTime,
            };
            return BalanceManagerDB.RegisterExpense(newExpense);
        }
    }
}
