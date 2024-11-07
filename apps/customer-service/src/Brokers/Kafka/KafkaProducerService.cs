using CustomerService.Brokers.Infrastructure;

namespace CustomerService.Brokers.Kafka;

public class KafkaProducerService : InternalProducer
{
    public KafkaProducerService(string bootstrapServers)
        : base(bootstrapServers) { }
}
