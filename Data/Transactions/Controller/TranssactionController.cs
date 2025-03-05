using System.Security.Claims;
using BudgetApp.Data.Components;
using BudgetApp.Data.Transactions.Models;
using BudgetApp.Data.Transactions.Repositories;
using BudgetApp.Data.Transactions.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BudgetApp.Data.Transactions.Controller;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class TranssactionController : ControllerBase
{
	private readonly ITransService _transService;

	public TranssactionController(ITransService transactionRepository)
	{
		_transService = transactionRepository;
	}
	[HttpGet]
	public async Task<IActionResult>GetById(int id)
	{
		return Ok(await _transService.Get(id));
	}
	[HttpGet("GetAllTransactions")]
	public async Task<IActionResult> GetAllTrans([FromQuery]TransactionFilterModel model)
	{
		return Ok(await _transService.GetAll(model));
	}
	[HttpPost]
	public async Task<IActionResult>AddTrans([FromForm]TransactionCreateModel model)
	{
		//var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
		//model.UserId = userId;
		return Ok(await _transService.Create(model) );
	}
	[HttpPut]
	public async Task<IActionResult>Edit(TransactionUpdateModel model)
	{
		return Ok(await _transService.Update(model));
	}
	[HttpDelete]
	public async Task <IActionResult>Remove(int id)
	{
		return Ok(await _transService.Delete(id));
	}

}
