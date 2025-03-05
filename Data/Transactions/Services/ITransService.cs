using BudgetApp.Data.Common.Repositories.Interfaces;
using BudgetApp.Data.Components;
using BudgetApp.Data.Pages;
using BudgetApp.Data.Transactions.Models;

namespace BudgetApp.Data.Transactions.Services;

public interface ITransService
{
	ValueTask<TransactionModel> Get(int Id);
	ValueTask<TransactionModel> Create(TransactionCreateModel model);
	ValueTask<TransactionModel> Update(TransactionUpdateModel model);
	ValueTask<PagedResult<TransactionModel>> GetAll(TransactionFilterModel filter);
	ValueTask<bool> Delete(int Id);
}
