using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expenses.Server.Entities
{
    public class Income : BaseEntity
    {
        public int Net { get; set; }
        public int IncomeCategoryId { get; set; }
        public virtual IncomeCategory IncomeCategory { get; set; }
    }
}
