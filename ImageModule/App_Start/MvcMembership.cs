using System.Web.Mvc;
using MvcMembership;

[assembly: WebActivator.PreApplicationStartMethod(typeof(ImageModule.App_Start.MvcMembership), "Start")]

namespace ImageModule.App_Start
{
	public static class MvcMembership
	{
		public static void Start()
		{
			GlobalFilters.Filters.Add(new TouchUserOnEachVisitFilter());
		}
	}
}
