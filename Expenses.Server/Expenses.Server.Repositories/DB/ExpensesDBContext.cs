using Expenses.Server.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expenses.Server.Repositories.DB
{
    public class ExpensesDBContext : DbContext
    {
        public ExpensesDBContext(DbContextOptions<ExpensesDBContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<ExpenseCategory> ExpenseCategories { get; set; }
        public DbSet<Income> Income { get; set; }
        public DbSet<IncomeCategory> IncomeCategories { get; set; }
    }
}
