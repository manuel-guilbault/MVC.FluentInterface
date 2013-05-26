using MVC.FluentInterface.ActionResults.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace MVC.FluentInterface.ActionResults
{
	public static class ActionResultBuilderExtensions
	{
		public static IBuilder Append(this IBuilder builder, Action action)
		{
			if (action == null) throw new ArgumentNullException("action");

			builder.Append(new DelegateResult(action));
			return builder;
		}

		public static IBuilder AppendDelegate(this IBuilder builder, Func<ActionResult, ActionResult> decorator)
		{
			return new DecoratingBuilder(builder, decorator);
		}
	}
}
