using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID._0___S.Problem
{
    internal class OrderService
    {
        private void SaveOrder(Model.Order order)
        {
            try
            {
                this.InsertOrder(order);

                Model.Invoice invoce = this.CreateInvoice(order);

                this.EmailInvoice(invoce);

                File.WriteAllText(@"c:\InfoLog.txt", "The order hass been complete");
            }
            catch (Exception e)
            {
                File.WriteAllText(@"c:\ErrorLog.txt", e.Message);
            }
        }

        private bool InsertOrder(Model.Order order)
        {
            //Code to Insert the Order on the database
            return true;
        }

        private Model.Invoice CreateInvoice(Model.Order order)
        {
            //Code to Create Invoice
            return new Model.Invoice();
        }

        private bool EmailInvoice(Model.Invoice invoce)
        {
            //Code to email Invoice
            return true;
        }
    }
}