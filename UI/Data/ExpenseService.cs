using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UI.Context;
using UI.Model;

namespace UI.Data
{
    public class ExpenseService
    {
        public List<Expense> GetExpenseList()
        {
            using (var context = new VaultDBContext())
            {
                var expenseList = context.Expenses.Where(x => x.Date.Month == DateTime.Today.Month).ToList();
                return expenseList;
            }
        }
        public List<Expense> GetExpenseListByDate(DateTime date)
        {
            using (var context = new VaultDBContext())
            {
                var expenseList = context.Expenses.Where(x => x.Date.Month == date.Date.Month).ToList();
                return expenseList;
            }
        }

        public void UpdateExpense(Expense item)
        {
            using (var context = new VaultDBContext())
            {
                context.Expenses.Update(item);
                context.SaveChanges();
            }

        }
        public void InsertExpense(ExpenseInsertModel item)
        {

            using (var context = new VaultDBContext())
            {
                Expense expense = new()
                {
                    Amount = item.Amount,
                    Description = item.Description,
                    IsCredit = item.IsCredit,
                    IsPaid = false,
                    Date = item.Date.Date
                };

                context.Expenses.Add(expense);
                context.SaveChanges();
            }

        }

        public void DeleteExpense(Expense item)
        {
            using (var context = new VaultDBContext())
            {
                context.Remove(item);
                context.SaveChanges();
            }
        }
    }
}
