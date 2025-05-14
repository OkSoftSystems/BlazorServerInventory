using System.Security.Claims;

namespace WebUI.Components.Layout.Identity
{
    // This service is used to show or hide element from user
    public class CustomAuthorizationService : ICustomAuthorizationService
    {
        public bool CustomClaimChecker(ClaimsPrincipal user, string specificClaim)
        {
            if (!user.Identity!.IsAuthenticated) return false;

            var getClaim = user.HasClaim(x => x.Type == specificClaim);
            if(!getClaim) return false;

            var getState = user.Claims.FirstOrDefault(x => x.Type == specificClaim)!.Value;
            return Convert.ToBoolean(getState) is true;
        }
    }
}
