namespace SOLID._3___I.Problem
{
    internal class BurgerOrderService : IFoodOrderService
    {
        public void OrderBurger(int quantity)
        {
            //Code to order a Burger
        }

        public void OrderSteak(int quantity)
        {
            throw new NotImplementedException("Can't order a salad from this service");
        }

        public void OrderSalad(int quantity)
        {
            throw new NotImplementedException("Can't order a salad from this service");
        }
    }
}