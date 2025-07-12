using System;
using Confluent.Kafka;

class Program
{
    static void Main(string[] args)
    {
        var config = new ProducerConfig { BootstrapServers = "localhost:9092" };

        using (var producer = new ProducerBuilder<Null, string>(config).Build())
        {
            while (true)
            {
                Console.Write("Enter message (or 'exit' to quit): ");
                var value = Console.ReadLine();
                if (value == "exit") break;

                producer.Produce("test-topic", new Message<Null, string> { Value = value },
                    (deliveryReport) =>
                    {
                        if (deliveryReport.Error.IsError)
                            Console.WriteLine($"Delivery Error: {deliveryReport.Error.Reason}");
                        else
                            Console.WriteLine($"Delivered to: {deliveryReport.TopicPartitionOffset}");
                    });
            }
        }
    }
}
