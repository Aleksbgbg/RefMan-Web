namespace RefMan.Attributes.Filters
{
    using System;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public abstract class EnsureAuthenticationAttributeBase : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!IsAllowedAccess(context.HttpContext.User.Identity.IsAuthenticated))
            {
                context.Result = new StatusCodeResult(403);
            }
        }

        protected abstract bool IsAllowedAccess(bool isAuthenticated);
    }
}