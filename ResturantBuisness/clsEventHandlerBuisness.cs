using sportDataLayer;

namespace ResturantBuisness
{
    public class clsEventHandlerBuisness
    {
        public static void createEventError(string message)
        {
            clsAppEventHandler.createNewEventLog(message);
        }
    }
}
