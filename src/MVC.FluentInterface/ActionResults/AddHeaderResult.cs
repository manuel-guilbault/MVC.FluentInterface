using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace MVC.FluentInterface.ActionResults
{
	public class AddHeaderResult : ActionResult
	{
		protected readonly string header;
		protected readonly string value;

		public AddHeaderResult(string header, string value)
		{
			if (header == null) throw new ArgumentNullException("header");
			if (value == null) throw new ArgumentNullException("value");

			this.header = header;
			this.value = value;
		}

		public override void ExecuteResult(ControllerContext context)
		{
			if (context == null) throw new ArgumentNullException("context");

			context.HttpContext.Response.Headers[header] = value;
		}
	}
}
