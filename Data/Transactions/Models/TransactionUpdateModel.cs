
namespace BudgetApp.Data.Transactions.Models;

using System.ComponentModel.DataAnnotations;
using BudgetApp.Data.Components;

public class TransactionUpdateModel
{
	public int Id { get; set; }
	public int? UserId { get; set; }
	public int? CategoryId { get; set; }
	public string? Comment { get; set; }
	[Required]
	public string Type { get; set; }
	[Required]
	public decimal Amount { get; set; }
	public string? FullName { get; set; }

	public string? Email { get; set; }
	public string? CategoryName { get; set; }
	public string? PasswordHash { get; set; }
	public DateTime Date { get; set; }
	public Transaction ToEntity()
	{
		return new Transaction()
		{
			Id=this.Id,
			Amount = this.Amount,
			Comment = this.Comment,
			Type=this.Type,
			Date = this.Date,
		};
	}
}
//using AutoMapper;

//public class MappingProfile : Profile
//{
//	public MappingProfile()
//	{
//		CreateMap<TransactionUpdateModel, Transaction>()
//			.ForMember(dest => dest.UpdateAt, opt => opt.MapFrom(src => DateTime.UtcNow));
//	}
//}