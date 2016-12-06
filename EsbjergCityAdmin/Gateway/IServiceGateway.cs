using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gateway.Models;

namespace Gateway
{
    public interface IServiceGateway<T> where T : AbstractId
    {

        T Create(T t);

        List<T> GetAll();

        T Get(int id);

        T Update(T t);

        bool Delete(T t);
    }
}
