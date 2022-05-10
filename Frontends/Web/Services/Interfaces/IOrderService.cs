using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Models.Orders;

namespace Web.Services.Interfaces
{
    public interface IOrderService
    {
        /// <summary>
        /// Senkron İletişim-direk ordermicroservisine istek yapılacak
        /// </summary>
        /// <param name="checkoutInfoInput"></param>
        /// <returns></returns>
        Task<OrderCreatedViewModel> CreateOrder(CheckoutInfoInput checkoutInfoInput);

        /// <summary>
        /// Asenkron İletişim-Sipariş Bilgileri rabbitMQ'ya gönderilecek
        /// </summary>
        /// <param name="checkoutInfoInput"></param>
        /// <returns></returns>
        Task<OrderSuspendViewModel> SuspendOrder(CheckoutInfoInput checkoutInfoInput);

        Task<List<OrderViewModel>> GetOrder();
    }
}
