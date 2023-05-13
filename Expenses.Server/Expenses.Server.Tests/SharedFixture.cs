
using Expenses.Server.Repositories.DB;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expenses.Server.Tests
{
    internal class SharedFixture : IDisposable
    {
        private readonly SqliteConnection _connection;
        public SharedFixture()
        {
            _connection = new SqliteConnection("DataSource=:memory:");
            _connection.Open();
        }
        public void Dispose() => this._connection.Dispose();
        public ExpensesDBContext CreateContext()
        {
            var result = new ExpensesDBContext(new DbContextOptionsBuilder<ExpensesDBContext>()
                .UseSqlite(_connection)
                .Options);
            result.Database.EnsureCreated();
            return result;
        }
    }
}
