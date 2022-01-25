using System.Threading.Tasks;
using Application.Interfaces;
using Domain;

namespace Infrastracture.Data
{
    public class BasketRepository : IBasketRepository
    {
        public Task<CustomerBasket> GetBasketAsync(string basketId)
        {
            throw new System.NotImplementedException();
        }

        public Task<CustomerBasket> UpdateBasketAsync(string basketId)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> DeleteBasketAsync(string basketId)
        {
            throw new System.NotImplementedException();
        }
    }
}