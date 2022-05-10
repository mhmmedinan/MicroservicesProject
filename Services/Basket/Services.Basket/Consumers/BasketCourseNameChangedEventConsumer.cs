using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Course.Shared.Utilities.Messages;
using MassTransit;
using Services.Basket.Dtos;
using Services.Basket.Services;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Services.Basket.Consumers
{
    public class BasketCourseNameChangedEventConsumer : IConsumer<CourseNameChangeEvent>
    {
        private readonly RedisService _redisService;

        public BasketCourseNameChangedEventConsumer(RedisService redisService)
        {
            _redisService = redisService;
        }

        public async Task Consume(ConsumeContext<CourseNameChangeEvent> context)
        {
            var keys = _redisService.GetKeys();
            if (keys != null)
            {
                foreach (var key in keys)
                {
                    var basket = await _redisService.GetDb().StringGetAsync(key);
                    var basketDto = JsonSerializer.Deserialize<BasketDto>(basket);
                    basketDto.BasketItems.ForEach(x =>
                    {
                        x.CourseName = x.CourseId == context.Message.CourseId
                            ? context.Message.UpdatedName
                            : x.CourseName;
                    });
                    await _redisService.GetDb().StringSetAsync(key, JsonSerializer.Serialize(basketDto));
                }
            }
        }
    }
}
