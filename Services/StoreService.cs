using ShopCreator.Core.Repositories;
using ShopCreator.Core.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ShopCreator.Core.Services;

public class StoreService
{
    private readonly StoreRepository _repository;

    public StoreService(StoreRepository repository)
    {
        _repository = repository;
    }

    public Task<Store> CreateStoreAsync(string name)
        => _repository.CreateAsync(name);

    public Task<List<Store>> GetStoresAsync()
        => _repository.GetAllAsync();
}