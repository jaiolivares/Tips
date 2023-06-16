using SOLID.Model;

namespace SOLID._0___S.Solution
{
    internal interface INotificationService
    {
        bool EmailInvoice(Invoice invoice);
    }

    internal class NotificationService : INotificationService
    {
        public bool EmailInvoice(Invoice invoice)
        {
            //Code to email Invoice
            return true;
        }
    }
}