/***
If you are wondering why anyone in their right mind would do this (have the UserInformation and UserInformationForTransportWithMessageCredential that do exacly the same thing), it's because a wcf service's behaviorConfiguration applies to the whole service.
So, if you want to provide a different type of authentication for a service, you specify it for all endpoints (because it's set through a service behaviorConfiguration), hence the two equal services with different names, one with a service custom authentication and one without.
***/
namespace WCFSecuritySurvivalGuide.Services
{
    public class UserInformationForTransportWithMessageCredential : IUserInformation
    {
        private readonly UserInformation _userInformation;
        public UserInformationForTransportWithMessageCredential()
        {
            _userInformation = new UserInformation();
        }
        public UserInfo GetUserInformation()
        {
            return _userInformation.GetUserInformation();
        }
    }
}
