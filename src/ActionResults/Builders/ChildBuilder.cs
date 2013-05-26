using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace MVC.FluentInterface.ActionResults.Builders
{
	public abstract class ChildBuilder : IBuilder
	{
		protected readonly IBuilder parent;

		public ChildBuilder(IBuilder parent)
		{
			if (parent == null) throw new ArgumentNullException("parent");

			this.parent = parent;
		}

		public IRoot Root
		{
			get { return parent.Root; }
		}

		public abstract IBuilder Append(ActionResult result);
	}
}
