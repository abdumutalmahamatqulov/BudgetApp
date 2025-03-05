using BudgetApp.Data.Categories.Models;
using BudgetApp.Data.Categories.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BudgetApp.Data.Categories.Controller;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class CategoryController : ControllerBase
{
	private readonly ICategoryService _categoryService;

	public CategoryController(ICategoryService categoryService)
	{
		_categoryService = categoryService;
	}
	[HttpGet("Get")]
	public async ValueTask<IActionResult> Get([FromQuery] int Id)
	{
		return Ok(await _categoryService.Get(Id));
	}
	[HttpGet("GetAll")]
	public async ValueTask<IActionResult> GetAll([FromQuery] CategoryFilterModel model)
	{
		return Ok(await _categoryService.GetAll(model));
	}
	[HttpPost("CreateCategory")]
	public async ValueTask<IActionResult> CreateCategory(CategoryCreateModel model)
	{
		return Ok(await _categoryService.Create(model));
	}

	[HttpPut("UpdateCategory")]
	public async ValueTask<IActionResult> UpdateCategory(CategoryUpdateModel model)
	{
		return Ok(await _categoryService.UpdateModel(model));
	}
	[HttpDelete("Detele")]

	public async ValueTask<IActionResult> Detele(int id)
	{
		return Ok(await _categoryService.Delete(id));
	}
}
