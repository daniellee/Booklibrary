using System.Web;
using System.Web.Mvc;
using Raven.Client.Document;
using StructureMap;

namespace BookLibrary
{
	public static class Bootstrapper
	{
		public static void Config()
		{
			ControllerBuilder.Current
				.SetControllerFactory(new StructureMapControllerFactory());

			ObjectFactory.Initialize(x =>
					{
						x.For<DocumentStore>().Use(() => (DocumentStore)HttpContext.Current.Application["DocumentStore"]);
						x.Scan(y =>
								{
									y.TheCallingAssembly();
									y.WithDefaultConventions();
								});
						x.AddRegistry(new ValidationRegistry());
					}
				);

		}
	}
}