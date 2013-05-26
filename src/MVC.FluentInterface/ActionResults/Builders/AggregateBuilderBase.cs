using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace MVC.FluentInterface.ActionResults.Builders
{
	public abstract class AggregateBuilderBase : IBuilder, IEnumerable<ActionResult>
	{
		protected readonly AggregateActionResult aggregate;

		public AggregateBuilderBase(params ActionResult[] results)
		{
			if (results == null) throw new ArgumentNullException("results");

			aggregate = new AggregateActionResult(results);
		}

		public abstract IRoot Root { get; }

		public AggregateActionResult AggregateResult
		{
			get { return aggregate; }
		}

		public virtual IBuilder Append(ActionResult result)
		{
			if (result == null) throw new ArgumentNullException("result");

			aggregate.Add(result);
			return this;
		}

		public IEnumerator<ActionResult> GetEnumerator()
		{
			return aggregate.GetEnumerator();
		}

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}
