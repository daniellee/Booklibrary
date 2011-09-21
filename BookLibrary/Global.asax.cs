using System;
using System.Web.Mvc;
using System.Web.Routing;
using BookLibrary.ViewModels;
using FluentValidation;
using FluentValidation.Mvc;
using StructureMap;
using StructureMap.Configuration.DSL;

namespace BookLibrary
{
	public class MvcApplication : System.Web.HttpApplication
	{
		public static void RegisterGlobalFilters(GlobalFilterCollection filters)
		{
			filters.Add(new HandleErrorAttribute());
		}

		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			routes.MapRoute(
				"Default", // Route name
				"{controller}/{action}/{id}", // URL with parameters
				new {controller = "Books", action = "Index", id = UrlParameter.Optional} // Parameter defaults
				);

		}

		protected void Application_Start()
		{
			AreaRegistration.RegisterAllAreas();

			RegisterGlobalFilters(GlobalFilters.Filters);
			RegisterRoutes(RouteTable.Routes);

			SetupRavenDb();

			ObjectFactory.Configure(scanner => scanner.AddRegistry(new ValidationRegistry()));
			var factory = new StructureMapValidatorFactory();
			//Tell MVC to use FV for validation
			ModelValidatorProviders.Providers.Add(new FluentValidationModelValidatorProvider(factory));
			DataAnnotationsModelValidatorProvider.AddImplicitRequiredAttributeForValueTypes = false;

			Bootstrapper.Config();
		}

		private void SetupRavenDb()
		{
			var documentStore = new Raven.Client.Document.DocumentStore {ConnectionStringName = "RavenDB"};
			documentStore.Initialize();
			Application["DocumentStore"] = documentStore;
		}
	}

	public class ValidationRegistry : Registry
	{
		public ValidationRegistry()
		{
			For<IValidator<CreateBook>>().Singleton().Use<CreateBookValidator>();
		}
	}

	public class StructureMapValidatorFactory : ValidatorFactoryBase
	{
		public override IValidator CreateInstance(Type validatorType)
		{
			return ObjectFactory.TryGetInstance(validatorType) as IValidator;
		}
	}
}
