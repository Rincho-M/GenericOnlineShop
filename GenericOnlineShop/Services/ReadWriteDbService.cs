using GenericOnlineShop.Db;
using GenericOnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenericOnlineShop.Services
{
    public class ReadWriteDbService : IReadWriteDbService
    {
        private readonly AppDbContext _dbContext;

        public ReadWriteDbService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Create()
        {

        }

        public async Task<IEnumerable<ProductType>> Read()
        {
            var data = _dbContext.ProductTypes.ToList();
            return data;
        }

        public async Task<IEnumerable<Product>> ReadProducts(string name)
        {
            // Get ProductTypeId by its name.
            var typeId = _dbContext.ProductTypes
                .Where(p => p.Name == name)
                .Select(p => p.Id)
                .FirstOrDefault();

            var data = _dbContext.Products
                .Where(p => p.TypeId == typeId);

            return data;
        }

        public async Task<IEnumerable<Product>> ReadProductsById(IEnumerable<uint> ids)
        {
            return _dbContext.Products.Where(p => ids.Contains(p.Id)).ToList();
        }

        public async Task Update()
        {

        }

        public async Task Delete()
        {

        }
    }
}
