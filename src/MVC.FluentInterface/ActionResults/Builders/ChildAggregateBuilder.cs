using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace MVC.FluentInterface.ActionResults.Builders
{
	public class ChildAggregateBuilder : AggregateBuilderBase, IBuilder
	{
		protected readonly IBuilder parent;

		public ChildAggregateBuilder(IBuilder parent, params ActionResult[] results)
			: base(results)
		{
			if (parent == null) throw new ArgumentNullException("parent");

			this.parent = parent;
		}

		public override IRoot Root
		{
			get { return parent.Root; }
		}
	}
}
