﻿using System.Web.Mvc;
using System.Web.Routing;
using FluentValidation.Mvc;

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

			Bootstrapper.Config();

			SetupFluentValidationHooks();
		}
		
		private static void SetupFluentValidationHooks()
		{
			ModelValidatorProviders.Providers.Add(new FluentValidationModelValidatorProvider(new StructureMapValidatorFactory()));
			DataAnnotationsModelValidatorProvider.AddImplicitRequiredAttributeForValueTypes = false;
		}

		private void SetupRavenDb()
		{
			var documentStore = new Raven.Client.Document.DocumentStore {ConnectionStringName = "RavenDB"};
			documentStore.Initialize();
			Application["DocumentStore"] = documentStore;
		}
	}
}
