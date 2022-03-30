using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Course.Core.Utilities.Results;
using Services.Basket.Dtos;

namespace Services.Basket.Services
{
    public interface IBasketService
    {
        IDataResult<BasketDto> GetBasket(string userId);
        IResult SaveOrUpdate(BasketDto basketDto);
        IResult Delete(string userId);
    }
}
