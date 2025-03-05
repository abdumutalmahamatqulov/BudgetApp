using BudgetApp.Data.Categories.Models;
using BudgetApp.Data.Common.Repositories;
using BudgetApp.Data.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace BudgetApp.Data.Categories.Repositories;
using BudgetApp.Data.Context;

using BudgetApp.Data.Components;

public class CategoryRepository : BaseRepository<Category, CategoryFilterModel>, ICategoryRepository
{
	private readonly AppDbContext _appDbContext;

	public CategoryRepository(AppDbContext appDbContext)
	{
		_appDbContext = appDbContext;
	}
	public async Task<Category> Create(Category entity)
	{
		_appDbContext.Categories.Add(entity);
		await _appDbContext.SaveChangesAsync();
		return entity;
	}

	public async Task<Category> Delete(int id)
	{
		var deletetransaction = await _appDbContext.Transactions.Where(x => x.CategoryId == id).ToListAsync();
		foreach (var transcation in deletetransaction)
		{
			_appDbContext.Transactions.Remove(transcation);
		}
		var category = await _appDbContext.Categories.FirstOrDefaultAsync(c => c.Id == id);
		_appDbContext.Categories.Remove(category);
		await _appDbContext.SaveChangesAsync();
		return category;
	}

	public async Task<Category> Get(int id)
	{
		try
		{
			return await _appDbContext.Categories.FirstOrDefaultAsync(c => c.Id == id);
		}
		catch (BugalteryAPIException ex)
		{
			throw new BugalteryAPIException(500, "category_can_not_Find");
		}
	}
	public async Task<Category> Update(Category entity)
	{
		await _appDbContext.Categories.Where(c => c.Id == entity.Id)
			.ExecuteUpdateAsync(
			c => c.SetProperty(c => c.Name, c => entity.Name)
			);
		return await _appDbContext.Categories.AsNoTracking().FirstOrDefaultAsync(c => c.Id == entity.Id);
	}
	protected override IQueryable<Category> GetQuery(CategoryFilterModel model)
	{
		var query = _appDbContext.Categories.AsNoTracking();
		if (model.Id.HasValue)
		{
			query = query.Where(x => x.Id == model.Id);
		}
		if (!string.IsNullOrEmpty(model.Name) && !string.IsNullOrWhiteSpace(model.Name))
		{
			query = query.Where(x => EF.Functions.Like(x.Name.ToLower(), $"%{model.Name.Trim().ToLower()}%"));
		}
		return query;
	}
}
