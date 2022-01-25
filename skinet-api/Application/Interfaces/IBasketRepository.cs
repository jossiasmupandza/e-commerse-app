﻿using System.Threading.Tasks;
using Domain;

namespace Application.Interfaces
{
    public interface IBasketRepository
    {
        Task<CustomerBasket> GetBasketAsync(string basketId);
        Task<CustomerBasket> UpdateBasketAsync(string basketId);
        Task<bool> DeleteBasketAsync(string basketId);
    }
}