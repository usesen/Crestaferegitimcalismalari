using Nest;
using VelorusNet8.Domain.Entities.Logs;

namespace VelorusNet8.Infrastructure.Services;

public class ElasticSearchService
{
    private readonly IElasticClient _elasticClient;

    public ElasticSearchService(string uri)
    {
        var settings = new ConnectionSettings(new Uri(uri))
            .DefaultIndex("logs_v2_v2"); // Varsayılan index adı
        _elasticClient = new ElasticClient(settings);
    }

    public async Task IndexLogAsync(LogEntry logEntry)
    {
        var response = await _elasticClient.IndexDocumentAsync(logEntry);

        if (!response.IsValid)
        {
            // Eğer log gönderimi başarısızsa hata detaylarını alalım
            throw new Exception($"Elasticsearch'e log gönderimi başarısız oldu: {response.OriginalException?.Message ?? "Bilinmeyen hata"}");
        }
        else
        {
            // Başarılı log gönderimi için geri bildirim alalım
            Console.WriteLine("Log başarıyla Elasticsearch'e gönderildi.");
        }
    }
}
