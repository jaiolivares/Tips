namespace SOLID._0___S.Solution
{
    internal interface INotificationService
    {
        bool EmailInvoice(Model.Invoice invoice);
    }

    internal class NotificationService : INotificationService
    {
        public bool EmailInvoice(Model.Invoice invoice)
        {
            //Code to email Invoice
            return true;
        }
    }
}