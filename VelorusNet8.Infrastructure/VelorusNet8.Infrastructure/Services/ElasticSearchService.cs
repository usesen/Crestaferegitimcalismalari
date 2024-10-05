
 
using Nest;
using VelorusNet8.Domain.Entities.Logs;

namespace VelorusNet8.Infrastructure.Services;

public class ElasticSearchService
{
    private readonly IElasticClient _elasticClient;

    public ElasticSearchService(string uri)
    {
        var settings = new ConnectionSettings(new Uri(uri))
            .DefaultIndex("logs"); // Varsayılan index adı
        _elasticClient = new ElasticClient(settings);
    }

    public async Task IndexLogAsync(LogEntry logEntry)
    {
        await _elasticClient.IndexDocumentAsync(logEntry);
    }
}
