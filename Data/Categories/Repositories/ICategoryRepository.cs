using BudgetApp.Data.Categories.Models;
using BudgetApp.Data.Common.Repositories.Interfaces;
namespace BudgetApp.Data.Categories.Repositories;
using BudgetApp.Data.Components;

public interface ICategoryRepository : IBaseRepository<Category, CategoryFilterModel>
{
	Task<Category> Create(Category entity);
	Task<Category> Update(Category entity);

	Task<Category> Delete(int id);
	Task<Category> Get(int id);
	Task<List<Category>> GetByFilter(CategoryFilterModel model, string[] includes = null);
	Task<int> GetCount(CategoryFilterModel model);
}
