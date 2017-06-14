using Frapid.Configuration.Events.Interfaces;
using Serilog;
using System;

namespace Frapid.Configuration.Events
{
    public class DefaultEventManager
    {
        private static string EventManager = System.Configuration.ConfigurationManager.AppSettings["EventManager"];
        private const string amazon = "amazonsqs";
        private const string local = "local";
        static IEventManager manager = null;


        public static IEventManager GetInstance()
        {
            if (manager == null)
            {
                try
                {
                    switch (EventManager)
                    {
                        case amazon:
                            manager = new AmazonEventManager();
                            break;
                        case local:
                        default:
                            manager = new EasyMQEventManager();
                            break;
                    }
                }
                catch (Exception e)
                {
                    Log.Error("{error}", e);
                }
            }
            return manager;
        }
    }
}
