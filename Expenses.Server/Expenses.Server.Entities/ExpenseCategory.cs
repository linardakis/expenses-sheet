using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expenses.Server.Entities
{
    public class ExpenseCategory : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
