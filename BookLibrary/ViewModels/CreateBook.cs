using System.ComponentModel.DataAnnotations;
using FluentValidation;

namespace BookLibrary.ViewModels
{
	
	public class CreateBook
	{
		public string Title { get; set; }
	}

	public class CreateBookValidator : AbstractValidator<CreateBook>
	{
		public CreateBookValidator()
		{
			RuleFor(r => r.Title).NotEmpty().WithMessage("Must have title");
		}
	}
}