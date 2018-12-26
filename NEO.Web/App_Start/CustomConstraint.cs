﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace NEO.Web
{
    public class CustomConstraint:IRouteConstraint
    {
        private readonly string _agent;

        public CustomConstraint(string agent)
        {
            _agent = agent;
        }

        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values,
            RouteDirection routeDirection)
        {
            return httpContext.Request.UserAgent != null && httpContext.Request.UserAgent.Contains(_agent);
        }
    }
}