using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gateway.Models;

namespace Gateway.ServiceGateways
{
    public class CustomerServiceGateway : IServiceGateway<Customer>
    {
        public Customer Create(Customer t)
        {
            throw new NotImplementedException();
        }

        public List<Customer> GetAll()
        {
            throw new NotImplementedException();
        }

        public Customer Get(int id)
        {
            throw new NotImplementedException();
        }

        public Customer Update(Customer t)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Customer t)
        {
            throw new NotImplementedException();
        }
    }
}
