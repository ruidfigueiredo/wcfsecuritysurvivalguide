/***
If you are wondering why anyone in their right mind would do this (have the UserInformation and UserInformationForWsBinding that do exacly the same thing), it's because a wcf service's behaviorConfiguration applies to the whole service.
So, if you want to provide a certificate for a service, you specify it for all endpoints (because it's set through a service behaviorConfiguration), hence the two equal services with different names, one with a service certificate set to enable wsHttpBinding with message security, and one without.
***/
namespace WCFSecuritySurvivalGuide.Services
{
    public class UserInformationForWsBinding : IUserInformation
    {
        private readonly UserInformation _userInformation;
        public UserInformationForWsBinding()
        {
            _userInformation = new UserInformation();
        }
        public UserInfo GetUserInformation()
        {
            return _userInformation.GetUserInformation();
        }
    }
}
