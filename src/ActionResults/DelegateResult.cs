using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace MVC.FluentInterface.ActionResults
{
	public class DelegateResult : ActionResult
	{
		private Action<ControllerContext> action;

		public DelegateResult(Action action)
			: this(context => action())
		{
		}

		public DelegateResult(Action<ControllerContext> action)
		{
			if (action == null) throw new ArgumentNullException("action");

			this.action = action;
		}

		public override void ExecuteResult(ControllerContext context)
		{
			if (context == null) throw new ArgumentNullException("context");

			action(context);
		}
	}
}
