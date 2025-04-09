using ExpenseTracker.ViewModels;

namespace ExpenseTracker.Services
{
    public interface IExpenseService
    {
        void AddExpense(ExpenseViewModel expense);
        List<ExpenseViewModel> GetAllExpenses();
        List<ExpenseViewModel> GetExpensesByCategory(string category);
        decimal GetTotalAmountByPeriod(DateTime startDate, DateTime endDate);
    }
}