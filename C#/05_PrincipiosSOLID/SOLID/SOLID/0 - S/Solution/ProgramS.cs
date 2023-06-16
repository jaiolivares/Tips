using SOLID.Model;

namespace SOLID._0___S.Solution
{
    public class ProgramS
    {
        public void EjecutarProgramS()
        {
            Console.WriteLine("Hello, World!");

            // create dependencies
            var orderRepository = new OrderRepository();
            var notificationService = new NotificationService();
            var invoiceService = new InvoiceService();
            var loggerService = new LoggerService();

            // create OrderService instance
            var orderService = new OrderService(orderRepository, notificationService, invoiceService, loggerService);

            // create order
            var order = new Order();

            // call SaveOrder method
            orderService.SaveOrder(order);
        }
    }
}