﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace MVC.FluentInterface.ActionResults.Builders
{
	public interface IBuilder
	{
		IRoot Root { get; }
		IBuilder Append(ActionResult result);
	}
}
