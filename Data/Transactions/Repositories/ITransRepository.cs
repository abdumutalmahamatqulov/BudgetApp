using BudgetApp.Data.Common.Repositories.Interfaces;
using BudgetApp.Data.Components;
using BudgetApp.Data.Transactions.Models;

namespace BudgetApp.Data.Transactions.Repositories;

public interface ITransRepository : IBaseRepository<Transaction, TransactionFilterModel>
{
	Task<Transaction> Create(Transaction transaction);
	Task<bool> Delete(int Id);
	Task<Transaction>Update(Transaction transaction);
	Task<Transaction> Get(int Id);
	Task<int> GetCount(TransactionFilterModel model);
	Task<List<Transaction>> GetByFilter(TransactionFilterModel model, string[] includes = null);
}
