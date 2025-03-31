using ShopCreator.Core.interfaces;
using ShopCreator.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using AutoMapper;
using ShopCreator.Core.DTO;

namespace ShopCreator.Core.Services
{
    public class ShopService : IShopService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ShopService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ShopDto>> GetAllAsync()
        {
            var shops = await _unitOfWork.Shops.GetAllAsync();
            return _mapper.Map<IEnumerable<ShopDto>>(shops);
        }

        public async Task<Shop?> GetByIdAsync(Guid id)
        {
            return await _unitOfWork.Shops.GetByIdAsync(id);
        }

        public async Task CreateAsync(Shop shop)
        {
            await _unitOfWork.Shops.AddAsync(shop);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateAsync(Shop shop)
        {
            await _unitOfWork.Shops.UpdateAsync(shop);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            await _unitOfWork.Shops.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
        }
    }

}
