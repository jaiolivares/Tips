using SOLID.Model;

namespace SOLID._4___D.Solution
{
    internal class OrderService
    {
        public readonly IEventNotificationService _eventNotificationService;

        public OrderService(IEventNotificationService eventNotificationService)
        {
            _eventNotificationService = eventNotificationService;
        }

        public void GenerateOrder(Order order)
        {    //TODO: código para crear la orden
            //Send notification to datadog
            _eventNotificationService.LogEvent("The Order was successfully created");
        }
    }
}