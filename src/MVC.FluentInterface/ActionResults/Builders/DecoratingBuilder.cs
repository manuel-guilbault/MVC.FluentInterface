using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace MVC.FluentInterface.ActionResults.Builders
{
	public class DecoratingBuilder : ChildBuilder
	{
		private readonly Func<ActionResult, ActionResult> decorator;

		public DecoratingBuilder(IBuilder parent, Func<ActionResult, ActionResult> decorator)
			: base(parent)
		{
			if (decorator == null) throw new ArgumentNullException("decorator");

			this.decorator = decorator;
		}

		public override IBuilder Append(ActionResult result)
		{
			if (result == null) throw new ArgumentNullException("result");

			var childrenBuilder = new ChildAggregateBuilder(this, result);
			parent.Append(decorator(childrenBuilder.AggregateResult));

			return childrenBuilder;
		}
	}
}
