using System.IdentityModel.Selectors;
using System.ServiceModel;

namespace WCFSecuritySurvivalGuide.Services
{
    public class CustomUserNameAndPasswordValidator : UserNamePasswordValidator
    {
        public override void Validate(string userName, string password)
        {
            if (userName == "johndoe" && password == "P@ssw0rd")
                return;

            throw new FaultException("Invalid Username and/or Password");
        }
    }
}
