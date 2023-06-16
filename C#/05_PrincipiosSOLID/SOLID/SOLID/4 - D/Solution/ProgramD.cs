using SOLID.Model;

namespace SOLID._4___D.Solution
{
    internal class ProgramD
    {
        public void EjecutarProgramD()
        {
            Order order = new Order();

            OrderService service = new OrderService(new DataDogService());
            service.GenerateOrder(order);
        }
    }
}