namespace Expenses.Server.Entities
{
    public class Expense : BaseEntity
    {
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public virtual ExpenseCategory ExpenseCategory { get; set; }

    }
}