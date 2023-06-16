using SOLID.Model;

namespace SOLID._0___S.Problem
{
    internal class OrderService
    {
        private void SaveOrder(Order order)
        {
            try
            {
                this.InsertOrder(order);

                Invoice invoce = this.CreateInvoice(order);

                this.EmailInvoice(invoce);

                File.WriteAllText(@"c:\InfoLog.txt", "The order hass been complete");
            }
            catch (Exception e)
            {
                File.WriteAllText(@"c:\ErrorLog.txt", e.Message);
            }
        }

        private bool InsertOrder(Order order)
        {
            //Code to Insert the Order on the database
            return true;
        }

        private Invoice CreateInvoice(Order order)
        {
            //Code to Create Invoice
            return new Invoice();
        }

        private bool EmailInvoice(Invoice invoce)
        {
            //Code to email Invoice
            return true;
        }
    }
}