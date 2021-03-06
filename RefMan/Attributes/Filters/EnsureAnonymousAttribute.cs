﻿namespace RefMan.Attributes.Filters
{
    public class EnsureAnonymousAttribute : EnsureAuthenticationAttributeBase
    {
        protected override bool IsAllowedAccess(bool isAuthenticated)
        {
            return !isAuthenticated;
        }
    }
}