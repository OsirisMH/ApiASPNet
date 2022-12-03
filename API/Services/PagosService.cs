using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace API.Services;

public class PagosService
{
    private readonly IMongoCollection<Pagos> _pagosCollection;
    public PagosService(IOptions<SistemasDistribuidosDatabaseSettings> sistemasDistribuidosDatabaseSettings)
    {
        var mongoClient = new MongoClient(
        sistemasDistribuidosDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
        sistemasDistribuidosDatabaseSettings.Value.DatabaseName);

        _pagosCollection = mongoDatabase.GetCollection<Pagos>(
       sistemasDistribuidosDatabaseSettings.Value.PagosCollectionName);
    }
    public async Task<List<Pagos>> GetAsync() =>
           await _pagosCollection.Find(_ => true).ToListAsync();
    public async Task<List<Pagos>> GetAsync(string matricula) =>
            await _pagosCollection.Find( _ => _.NumeroMatricula == matricula).ToListAsync();
    public async Task CreateAsync(Pagos newPago) =>
        await _pagosCollection.InsertOneAsync(newPago);
    
}
