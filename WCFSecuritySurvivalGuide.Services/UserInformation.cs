using System.ServiceModel;
using System.Threading;

namespace WCFSecuritySurvivalGuide.Services
{
    public class UserInformation : IUserInformation
    {
        public UserInfo GetUserInformation()
        {
            var sscUsername = ServiceSecurityContext.Current != null ? ServiceSecurityContext.Current.PrimaryIdentity.Name : "N/A";
            var username = string.IsNullOrWhiteSpace(Thread.CurrentPrincipal.Identity.Name) ? "N/A" : Thread.CurrentPrincipal.Identity.Name;
            return new UserInfo
            {
                SecurityServiceContextUsername = sscUsername,
                ThreadCurrentPrincipalUsername = username
            };
        }
    }
}
