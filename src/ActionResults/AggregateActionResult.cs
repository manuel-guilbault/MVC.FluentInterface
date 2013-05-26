using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace MVC.FluentInterface.ActionResults
{
	public class AggregateActionResult : ActionResult, IEnumerable<ActionResult>
	{
		private List<ActionResult> results;

		public AggregateActionResult(params ActionResult[] results)
			: this(results.AsEnumerable())
		{
		}

		public AggregateActionResult(IEnumerable<ActionResult> results)
		{
			if (results == null) throw new ArgumentNullException("results");

			this.results = new List<ActionResult>(results);
		}

		public void Add(ActionResult result)
		{
			if (result == null) throw new ArgumentNullException("result");

			results.Add(result);
		}

		public override void ExecuteResult(ControllerContext context)
		{
			if (context == null) throw new ArgumentNullException("context");

			foreach (var result in results)
			{
				result.ExecuteResult(context);
			}
		}

		public IEnumerator<ActionResult> GetEnumerator()
		{
			return results.GetEnumerator();
		}

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}
