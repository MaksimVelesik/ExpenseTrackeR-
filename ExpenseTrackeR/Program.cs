var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<ExpenseTracker.Services.IExpenseService, ExpenseTracker.Services.ExpenseService>();

var app = builder.Build();

app.UseRouting();

if (app.Environment.IsDevelopment())
{
}

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Expenses}/{action=Index}/{id?}");

app.Run();