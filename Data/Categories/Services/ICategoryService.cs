using BudgetApp.Data.Categories.Models;
using BudgetApp.Data.Pages;

namespace BudgetApp.Data.Categories.Services;

public interface ICategoryService
{
	ValueTask<CategoryModel> Get(int id);
	ValueTask<CategoryModel> Create(CategoryCreateModel model);
	ValueTask<CategoryModel> UpdateModel(CategoryUpdateModel model);
	ValueTask<PagedResult<CategoryModel>> GetAll(CategoryFilterModel filter);
	ValueTask<bool> Delete(int id);
}
