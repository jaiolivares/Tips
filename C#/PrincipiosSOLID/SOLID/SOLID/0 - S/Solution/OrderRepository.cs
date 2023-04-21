namespace SOLID._0___S.Solution
{
    internal interface IOrderRepository
    {
        public bool InsertOrder(Model.Order order);
    }

    internal class OrderRepository : IOrderRepository
    {
        public bool InsertOrder(Model.Order order)
        {
            //Code to Insert the Order on the database
            return true;
        }
    }
}