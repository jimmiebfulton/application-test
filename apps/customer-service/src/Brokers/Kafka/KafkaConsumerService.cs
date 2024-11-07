using CustomerService.Brokers.Infrastructure;
using CustomerService.Brokers.Kafka;
using Microsoft.Extensions.DependencyInjection;

namespace CustomerService.Brokers.Kafka;

public class KafkaConsumerService : KafkaConsumerService<KafkaMessageHandlersController>
{
    public KafkaConsumerService(IServiceScopeFactory serviceScopeFactory, KafkaOptions kafkaOptions)
        : base(serviceScopeFactory, kafkaOptions) { }
}
