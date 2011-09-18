using System;
using System.Web.Mvc;
using System.Web.Routing;
using StructureMap;

namespace BookLibrary
{
	public class StructureMapControllerFactory : DefaultControllerFactory { 
		protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType) {
			if ((requestContext == null) || (controllerType == null))
				return null;

			return (Controller)ObjectFactory.GetInstance(controllerType);
		}
	}
}