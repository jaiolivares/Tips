﻿using SOLID.Model;

namespace SOLID._0___S.Solution
{
    internal class OrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly INotificationService _notificationService;
        private readonly IInvoiceService _invoiceService;
        private readonly ILoggerService _loggerService;

        public OrderService(IOrderRepository orderRepository,
                            INotificationService notificationService,
                            IInvoiceService invoiceService,
                            ILoggerService loggerService)
        {
            _orderRepository = orderRepository;
            _notificationService = notificationService;
            _invoiceService = invoiceService;
            _loggerService = loggerService;
        }

        public void SaveOrder(Order order)
        {
            try
            {
                _orderRepository.InsertOrder(order);

                var invoice = _invoiceService.CreateInvoice(order);

                _notificationService.EmailInvoice(invoice);

                _loggerService.Info("The order hass been complete");
            }
            catch (Exception e)
            {
                _loggerService.Error(e.Message, e);
            }
        }
    }
}