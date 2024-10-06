using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using VelorusNet8.Application.Interface;


namespace VelorusNet8.Infrastructure.Services;

public class RabbitMQService : IMessageBusService
{
    private readonly IConnection _connection;
    private readonly IModel _channel;

    public RabbitMQService(IConfiguration configuration)
    {
        var rabbitMQSettings = configuration.GetSection("RabbitMQ");
        var factory = new ConnectionFactory()
        {
            HostName = rabbitMQSettings["HostName"],
            Port = int.Parse(rabbitMQSettings["Port"]),
            UserName = rabbitMQSettings["UserName"],
            Password = rabbitMQSettings["Password"]
        };

        _connection = factory.CreateConnection();
        _channel = _connection.CreateModel();
    }

    // RabbitMQ işlemleri burada yapılacak...
    // PublishMessage içinde QueueDeclare ekleyelim
    public async Task<string> PublishMessageAsync(string message)
    {
        _channel.QueueDeclare(queue: "UserCreatedQueue",
                              durable: true,
                              exclusive: false,
                              autoDelete: false,
                              arguments: null);

        Console.WriteLine("Mesaj gönderiliyor: " + message);  // Mesaj gönderileceğini logla

        var body = System.Text.Encoding.UTF8.GetBytes(message);
        var properties = _channel.CreateBasicProperties();
        properties.Persistent = true; // Mesaj kalıcı olacak
      
        try
        {
            _channel.BasicPublish(
                exchange: "",
                routingKey: "UserCreatedQueue",
                basicProperties: properties,
                body: body);

            Console.WriteLine($" [x] Sent {message}");  // Başarıyla gönderildiğini logla
        }
        catch (Exception ex)
        {
            Console.WriteLine("Mesaj gönderirken hata: " + ex.Message);  // Hata logla
        }
        return "publish yapıldı başarılı";
    }


    public void StartConsuming()
    {
        _channel.QueueDeclare(queue: "UserCreatedQueue",
                              durable: true,
                              exclusive: false,
                              autoDelete: false,
                              arguments: null);

        var consumer = new EventingBasicConsumer(_channel);
        consumer.Received += (model, ea) =>
        {
            var body = ea.Body.ToArray();
            var message = System.Text.Encoding.UTF8.GetString(body);
            Console.WriteLine($" [x] Received {message}");

            // Mesaj başarılı bir şekilde işlendi
            Console.WriteLine("****** !!!!! Mesaj Başarıyla Eklendi !!!!! ****** ");
            _channel.BasicAck(ea.DeliveryTag, multiple: false);
        };

        _channel.BasicConsume(queue: "UserCreatedQueue", autoAck: false, consumer: consumer);
    }

    //public async Task<string> CallAndReceiveResponseAsync(string message)
    //{
    //    var replyQueue = _channel.QueueDeclare(queue: "", exclusive: true).QueueName;
    //    var correlationId = Guid.NewGuid().ToString();

    //    var properties = _channel.CreateBasicProperties();
    //    properties.ReplyTo = replyQueue;
    //    properties.CorrelationId = correlationId;

    //    var body = System.Text.Encoding.UTF8.GetBytes(message);
    //    var tcs = new TaskCompletionSource<string>();

    //    Console.WriteLine("Yanıt bekleniyor için mesaj gönderiliyor: " + message);

    //    var consumer = new EventingBasicConsumer(_channel);
    //    consumer.Received += (model, ea) =>
    //    {
    //        if (ea.BasicProperties.CorrelationId == correlationId)
    //        {
    //            var responseMessage = System.Text.Encoding.UTF8.GetString(ea.Body.ToArray());
    //            tcs.SetResult(responseMessage);
    //            Console.WriteLine($"Yanıt alındı: {responseMessage}");
    //        }
    //        else
    //        {
    //            Console.WriteLine($"Yanıtın CorrelationId'si eşleşmiyor: {ea.BasicProperties.CorrelationId}");
    //        }
    //    };

    //    _channel.BasicConsume(consumer: consumer, queue: replyQueue, autoAck: true);
    //    _channel.BasicPublish(exchange: "", routingKey: "UserCreatedQueue", basicProperties: properties, body: body);

    //    var timeout = Task.Delay(TimeSpan.FromSeconds(5));

    //    var response = await Task.WhenAny(tcs.Task, timeout);
    //    if (response == timeout)
    //    {
    //        Console.WriteLine("Cevap alınamadı, zaman aşımına uğradı."); // Log ekle
    //        throw new TimeoutException("Cevap alınamadı.");
    //    }

    //    return await tcs.Task;
    //}

}

