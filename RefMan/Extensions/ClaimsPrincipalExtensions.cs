﻿namespace RefMan.Extensions
{
    using System.Security.Claims;

    public static class ClaimsPrincipalExtensions
    {
        public static bool IsLoggedIn(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal.FindFirst(ClaimTypes.NameIdentifier) != null;
        }

        public static string ReadUsername(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal.FindFirst(ClaimTypes.Name)
                                  .Value;
        }

        public static long ReadId(this ClaimsPrincipal claimsPrincipal)
        {
            return long.Parse(claimsPrincipal.FindFirst(ClaimTypes.NameIdentifier).Value);
        }
    }
}