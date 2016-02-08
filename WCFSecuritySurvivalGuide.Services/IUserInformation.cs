using System.ServiceModel;

namespace WCFSecuritySurvivalGuide.Services
{
    [ServiceContract]
    public interface IUserInformation
    {
        [OperationContract]
        UserInfo GetUserInformation();
    }
}
