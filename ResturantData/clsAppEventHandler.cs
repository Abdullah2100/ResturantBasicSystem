using System;
using System.Configuration;
using System.Diagnostics;
namespace sportDataLayer
{
    public class clsAppEventHandler
    {

        private static void _createLogIfItNoteCreated(string appEventName)
        {
            try

            {
                if (!EventLog.Exists(appEventName))
                {

                    EventLog.CreateEventSource(appEventName, "Application");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }



        public static void createNewEventLog(string error)
        {
            string appEventName = ConfigurationManager.AppSettings["appEventName"];

            _createLogIfItNoteCreated(appEventName);
            EventLog.WriteEntry(appEventName, error);
        }
    }
}
