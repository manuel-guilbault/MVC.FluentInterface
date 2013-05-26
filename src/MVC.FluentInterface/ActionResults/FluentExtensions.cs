using MVC.FluentInterface.ActionResults.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace MVC.FluentInterface.ActionResults
{
	public static class FluentExtensions
	{
		public static IBuilder Header(this IBuilder builder, string header, string value)
		{
			return builder.Append(new AddHeaderResult(header, value));
		}

		public static IBuilder Do(this IBuilder builder, Action action)
		{
			return builder.Append(new DelegateResult(action));
		}

		public static IBuilder Do(this IBuilder builder, Action<ControllerContext> action)
		{
			return builder.Append(new DelegateResult(action));
		}

		public static IBuilder Do(this IBuilder builder, Func<ActionResult> action)
		{
			return builder.Append(new DelegateResultDecorator(action));
		}

		public static IBuilder Status(this IBuilder builder, int status)
		{
			return builder.Append(new HttpStatusCodeResult(status));
		}

		public static ActionResult Build(this IBuilder builder)
		{
			return builder.Root.Build();
		}
	}
}
