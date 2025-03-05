using BudgetApp.Data.Common.Repositories;
using BudgetApp.Data.Common.Repositories.Interfaces;
using BudgetApp.Data.Components;
using BudgetApp.Data.Context;
using BudgetApp.Data.Exceptions;
using BudgetApp.Data.Transactions.Models;
using Microsoft.EntityFrameworkCore;

namespace BudgetApp.Data.Transactions.Repositories;

public class TransRepository : BaseRepository<Transaction, TransactionFilterModel>, ITransRepository
{
	private readonly AppDbContext _context;

	public TransRepository(AppDbContext context)
	{
		_context = context;
	}
	public async Task<Transaction>Create(Transaction transaction)
	{
		transaction.Date = DateTime.UtcNow;
		_context.Transactions.Add(transaction);
		await _context.SaveChangesAsync();
		return transaction;
	}
	public async Task<bool> Delete(int Id)
	{
		var trans = await _context.Transactions.FirstOrDefaultAsync(t=>t.Id == Id);
		_context.Transactions.Remove(trans);
		await _context.SaveChangesAsync();
		return true;
	}

	public async Task<Transaction> Get(int Id)
	{
		try
		{
			return await _context.Transactions.FirstOrDefaultAsync(x => x.Id == Id);
		}
		catch(BugalteryAPIException ex)
		{
			throw new BugalteryAPIException(500, "transaction_can_not_find");
		}
	}



	public async Task<Transaction> Update(Transaction transaction)
	{
		await _context.Transactions.Where(t => t.Id == transaction.Id)
			.ExecuteUpdateAsync(
			x => x.SetProperty(t => t.UserId, t => transaction.UserId)
			.SetProperty(x=>x.Amount,x=>transaction.Amount)
			.SetProperty(x=>x.User,x=>transaction.User)
			.SetProperty(x=>x.Date,x=>transaction.Date)
			.SetProperty(x=>x.Comment,x=>transaction.Comment)
			);
		return await _context.Transactions.AsNoTracking().FirstOrDefaultAsync(x => x.Id == transaction.Id);
	}

	protected override IQueryable<Transaction> GetQuery(TransactionFilterModel model)
	{
		var query = _context.Transactions.AsNoTracking();
		if(model.Id.HasValue)
		{
			query=query.Where(x=>x.Id==model.Id);
		}
		if (model.CategoryId.HasValue)
		{
			query = query.Where(x => x.CategoryId == model.CategoryId);
		}
		if (model.Amount.HasValue&& model.Amount.Value>0)
		{
			query = query.Where(x => x.Amount == model.Amount);
		}
		if(!string.IsNullOrEmpty(model.Type)&& !string.IsNullOrWhiteSpace(model.Type))
		{
			query = query.Where(x => EF.Functions.Like(x.Type.ToLower(),$"%{x.Type.Trim().ToLower()}%"));
		}
		return query;
	}
} 
