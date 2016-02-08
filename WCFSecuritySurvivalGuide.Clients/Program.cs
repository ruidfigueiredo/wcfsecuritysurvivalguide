using System;
using System.ServiceModel;
using System.ServiceModel.Security;
using WCFSecuritySurvivalGuide.Services;

namespace WCFSecuritySurvivalGuide.Clients
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var channelFactory = new ChannelFactory<IUserInformation>("basic"))
            {
                Console.WriteLine("Creating the channel for basic");
                var proxy = channelFactory.CreateChannel();
                PrintUserInformation(proxy);
            }

            Console.WriteLine(new string('-', 80));

            using (var channelFactory = new ChannelFactory<IUserInformation>("transportSecurityWithWindowsCredentials"))
            {
                Console.WriteLine("Creating the channel for transportSecurityWithWindowsCredentials");
                var proxy = channelFactory.CreateChannel();

                PrintUserInformation(proxy);
            }

            Console.WriteLine(new string('-', 80));

            using (var channelFactory = new ChannelFactory<IUserInformation>("transportWithMessageCredential"))
            {
                Console.WriteLine("Creating the channel for transportWithMessageCredential");

                channelFactory.Credentials.UserName.UserName = @"johndoe";
                channelFactory.Credentials.UserName.Password = "P@ssw0rd";
                var proxy = channelFactory.CreateChannel();

                try {
                    PrintUserInformation(proxy);
                }catch(MessageSecurityException ex)
                {
                    if (ex.InnerException != null)
                        Console.WriteLine("This is the FaultException message that you threw in your UserNamePasswordValidator: " + ex.InnerException.Message);
                    else
                        throw;
                }
            }

            Console.WriteLine(new string('-', 80));

            //To use the wsHttpConfiguration you have to make sure you have certificate for it
            /*using (var channelFactory = new ChannelFactory<IUserInformation>("wsHttpConfiguration"))
            {
                Console.WriteLine("Creating the channel for wsHttpConfiguration");
                var proxy = channelFactory.CreateChannel();

                PrintUserInformation(proxy);
            }*/

            Console.WriteLine("Done");
            Console.ReadLine();
        }

        private static void PrintUserInformation(IUserInformation proxy)
        {
            Console.WriteLine("Calling the service");
            var userInfo = proxy.GetUserInformation();
            Console.WriteLine("Username from SecurityServiceContext: " + userInfo.SecurityServiceContextUsername);
            Console.WriteLine("Username from Thread's CurrentPrincial: " + userInfo.ThreadCurrentPrincipalUsername);
        }
    }
}
