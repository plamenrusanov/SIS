﻿using System.Runtime.CompilerServices;
using SIS.Framework.ActionsResults;
using SIS.Framework.ActionsResults.Contracts;
using SIS.Framework.Utilities;
using SIS.Framework.Views;
using SIS.HTTP.Requests;

namespace SIS.Framework.Controllers
{
    public abstract class Controller
    {
        public IHttpRequest Request { get; set; }

        protected IViewable View([CallerMemberName] string viewName = "")
        {
            var controllerName = ControllerUtilities.GetControllerName(this);

            var viewFullyQualifiedName = ControllerUtilities
                .GetViewFullyQualifiedName(controllerName, viewName);

            var view = new View(viewFullyQualifiedName);

            return new ViewResult(view);
        }

        protected IRedirectable RedirectToAction(string redirectUrl)
            => new RedirectResult(redirectUrl);
    }
}
