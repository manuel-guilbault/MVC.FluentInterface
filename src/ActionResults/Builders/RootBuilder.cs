using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace MVC.FluentInterface.ActionResults.Builders
{
	public class RootBuilder : AggregateBuilderBase, IBuilder, IRoot
	{
		public RootBuilder(params ActionResult[] results)
			: base(results)
		{
		}

		public override IRoot Root
		{
			get { return this; }
		}

		public ActionResult Build()
		{
			return aggregate;
		}
	}
}
