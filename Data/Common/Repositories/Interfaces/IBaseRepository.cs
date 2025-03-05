using BudgetApp.Data.Components;
using BudgetApp.Data.Pages;

namespace BudgetApp.Data.Common.Repositories.Interfaces;

public interface IBaseRepository<TEntity, TFilter> where TEntity : Auditable where TFilter : PaginationParams
{
	Task<List<TEntity>> GetByFilter(TFilter model, string[] includes = null);
}
