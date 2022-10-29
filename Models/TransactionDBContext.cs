using Microsoft.EntityFrameworkCore;
using System.Transactions;

namespace Crud_BankTransactions.Models
{
    public class TransactionDBContext:DbContext
    {
        public TransactionDBContext(DbContextOptions<TransactionDBContext> options):base(options)
        {

        }

        public DbSet<TransactionsModel> Transactions { get; set; }
    }
}
