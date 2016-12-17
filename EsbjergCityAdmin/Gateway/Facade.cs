using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gateway.Models;
using Gateway.ServiceGateways;

namespace Gateway
{
    public class Facade
    {
        private IServiceGateway<Order> _orderServiceGateway;
        private IServiceGateway<Event> _eventServiceGateway;
        private IServiceGateway<GiftCard> _giftCardServiceGateway;

        public IServiceGateway<Order> GetOrderGateway()
        {
            return _orderServiceGateway ?? (_orderServiceGateway = new OrderServiceGateway());
        }

        public IServiceGateway<GiftCard> GetGiftCardGateway()
        {
            return _giftCardServiceGateway ?? (_giftCardServiceGateway = new GiftCardServiceGateway());
        }

        public IServiceGateway<Event> GetEventGateway()
        {
            return _eventServiceGateway ?? (_eventServiceGateway = new EventServiceGateway());
        }
    }
}
