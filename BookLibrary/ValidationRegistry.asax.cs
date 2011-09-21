using BookLibrary.ViewModels;
using FluentValidation;
using StructureMap.Configuration.DSL;

namespace BookLibrary
{
	public class ValidationRegistry : Registry
	{
		public ValidationRegistry()
		{
			For<IValidator<CreateBook>>().Singleton().Use<CreateBookValidator>();
		}
	}
}