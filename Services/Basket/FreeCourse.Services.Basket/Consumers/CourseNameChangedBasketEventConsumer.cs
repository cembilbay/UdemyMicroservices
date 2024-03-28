using FreeCourse.Services.Basket.Dtos;
using FreeCourse.Services.Basket.Services;
using FreeCourse.Shared.Messages;
using MassTransit;
using Newtonsoft.Json;
using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using StackExchange.Redis;
using System.Text;

namespace FreeCourse.Services.Basket.Consumers
{
    public class CourseNameChangedBasketEventConsumer : IConsumer<CourseNameChangedEvent>
    {
        private readonly RedisService _redisService;

        public CourseNameChangedBasketEventConsumer(RedisService redisService)
        {
            _redisService = redisService;
        }

        public async Task Consume(ConsumeContext<CourseNameChangedEvent> context)
        {
            var courseNameChangedEvent = context.Message;

            // Redis üzerinden ilgili sepet öğesini güncelle
            var basketDtoString = await _redisService.GetDb().StringGetAsync(courseNameChangedEvent.CourseId);
            if (!string.IsNullOrEmpty(basketDtoString))
            {
                var basketDto = JsonConvert.DeserializeObject<BasketDto>(basketDtoString);
                var basketItemToUpdate = basketDto.basketItems.FirstOrDefault(x => x.CourseId == courseNameChangedEvent.CourseId);
                if (basketItemToUpdate != null)
                {
                    basketItemToUpdate.CourseName = courseNameChangedEvent.UpdatedName;
                    await _redisService.GetDb().StringSetAsync(courseNameChangedEvent.CourseId, JsonConvert.SerializeObject(basketDto));
                }
            }
        }
    }
}
