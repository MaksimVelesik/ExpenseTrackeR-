using ExpenseTracker.ViewModels;

namespace ExpenseTracker.Services
{
    public class ExpenseService : IExpenseService
    {
        private readonly List<ExpenseViewModel> _expenses = new();

        public void AddExpense(ExpenseViewModel expense)
        {
            expense.Id = _expenses.Count + 1;
            _expenses.Add(expense);
        }

        public List<ExpenseViewModel> GetAllExpenses()
        {
            return _expenses;
        }

        public List<ExpenseViewModel> GetExpensesByCategory(string category)
        {
            return _expenses.Where(e => e.Category == category).ToList();
        }

        public decimal GetTotalAmountByPeriod(DateTime startDate, DateTime endDate)
        {
            return _expenses
                .Where(e => e.Date >= startDate && e.Date <= endDate)
                .Sum(e => e.Amount);
        }
    }
}