using MVC.FluentInterface.ActionResults.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace MVC.FluentInterface.ActionResults
{
	public static class Fluent
	{
		public static IBuilder ly
		{
			get { return new RootBuilder(); }
		}
	}
}
