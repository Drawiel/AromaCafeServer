using AromaCafeService.Models;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AromaCafeService {
    public partial class ServiceImplementation : IExpenseManager {
        public int RegisterExpense(Expense expense) {
            var newExpense = new Gastos {
                Monto = expense.Amount,
                Fecha = expense.DateTime,
            };
            return BalanceManagerDB.RegisterExpense(newExpense);
        }
    }
}
