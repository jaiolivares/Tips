namespace SOLID._3___I.Solution
{
    internal class ProgramI
    {
        public void EjecutarProgramI()
        {
            BurgerOrderService service = new BurgerOrderService();
            service.OrderBurger(2);
        }
    }
}