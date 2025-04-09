using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AromaCafeService {
    public partial class ServiceImplementation : IExpenseManager {
        public int RegisterExpense(float amount, DateTime dateTime) {

            return BalanceManagerDB.RegisterExpense(amount, dateTime);
        }
    }
}
