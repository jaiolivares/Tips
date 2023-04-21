namespace SOLID._0___S.Solution
{
    internal interface IInvoiceService
    {
        Model.Invoice CreateInvoice(Model.Order order);
    }

    internal class InvoiceService : IInvoiceService
    {
        public Model.Invoice CreateInvoice(Model.Order order)
        {
            return new Model.Invoice();
        }
    }
}