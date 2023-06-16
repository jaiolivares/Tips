using SOLID.Model;

namespace SOLID._0___S.Solution
{
    internal interface IInvoiceService
    {
        Invoice CreateInvoice(Order order);
    }

    internal class InvoiceService : IInvoiceService
    {
        public Invoice CreateInvoice(Order order)
        {
            return new Invoice();
        }
    }
}