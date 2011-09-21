using System;
using FluentValidation;
using StructureMap;

namespace BookLibrary
{
	public class StructureMapValidatorFactory : ValidatorFactoryBase
	{
		public override IValidator CreateInstance(Type validatorType)
		{
			return ObjectFactory.TryGetInstance(validatorType) as IValidator;
		}
	}
}