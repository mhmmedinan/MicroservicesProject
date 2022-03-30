using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Course.Core.Utilities.Results;
using Services.Basket.Dtos;

namespace Services.Basket.Services
{
    public class BasketService:IBasketService
    {
        private readonly RedisService _redisService;

        public BasketService(RedisService redisService)
        {
            _redisService = redisService;
        }

        public IDataResult<BasketDto> GetBasket(string userId)
        {
            var existsBasket = _redisService.GetDb().StringGet(userId);
            if (String.IsNullOrEmpty(existsBasket))
            {
                return new ErrorDataResult<BasketDto>("Basket Not Found");
            }

            return new SuccessDataResult<BasketDto>(JsonSerializer.Deserialize<BasketDto>(existsBasket));
        }

        public IResult SaveOrUpdate(BasketDto basketDto)
        {
            var status = _redisService.GetDb().StringSet(basketDto.UserId, JsonSerializer.Serialize(basketDto));

            return status ? new SuccessResult("Success") : new ErrorResult("Basket could not update or save");
        }

        public IResult Delete(string userId)
        {
            var status = _redisService.GetDb().KeyDelete(userId);
            return status ? new SuccessResult("Success") : new ErrorResult("Basket not found");
        }
    }
}
