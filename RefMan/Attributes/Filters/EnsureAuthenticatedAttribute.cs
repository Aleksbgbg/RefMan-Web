namespace RefMan.Attributes.Filters
{
    public class EnsureAuthenticatedAttribute : EnsureAuthenticationAttributeBase
    {
        protected override bool IsAllowedAccess(bool isAuthenticated)
        {
            return isAuthenticated;
        }
    }
}