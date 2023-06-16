using SOLID.Model;

namespace SOLID._4___D.Problem
{
    internal class DataDogService
    {
        public void LogEvent(string message)
        {
            //Code to event on DataDog
        }
    }

    internal class OrderService
    {
        public readonly DataDogService _dataDogService;

        public OrderService(DataDogService dataDogService)
        {
            _dataDogService = dataDogService;
        }

        public void GenerateOrder(Order order)
        {
            //TODO: código para crear la orden

            //Send notification to datadog
            _dataDogService.LogEvent("The Order was successfully created");
        }
    }
}