using Microsoft.AspNetCore.Mvc;
using ExpenseTracker.ViewModels;
using ExpenseTracker.Services;

namespace ExpenseTracker.Controllers
{
    public class ExpensesController : Controller
    {
        private readonly IExpenseService _expenseService;

        public ExpensesController(IExpenseService expenseService)
        {
            _expenseService = expenseService;
        }

        public IActionResult Index()
        {
            var expenses = _expenseService.GetAllExpenses();
            return View(expenses);
        }

        [Route("Expenses/Filter/{category}")]
        public IActionResult Filter(string category)
        {
            var expenses = _expenseService.GetExpensesByCategory(category);
            return View("Index", expenses);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(ExpenseViewModel expense)
        {
            if (ModelState.IsValid)
            {
                _expenseService.AddExpense(expense);
                TempData["SuccessMessage"] = "Расход успешно добавлен!";
                return RedirectToAction("Index");
            }
            return View(expense);
        }

        public IActionResult TotalByPeriod(DateTime? startDate, DateTime? endDate)
        {
            var start = startDate ?? DateTime.Today.AddMonths(-1);
            var end = endDate ?? DateTime.Today;
            var total = _expenseService.GetTotalAmountByPeriod(start, end);
            ViewBag.TotalAmount = total;
            ViewBag.StartDate = start;
            ViewBag.EndDate = end;
            return View("Index", _expenseService.GetAllExpenses());
        }
    }
}