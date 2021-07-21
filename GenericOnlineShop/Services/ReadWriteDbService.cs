using GenericOnlineShop.Db;
using GenericOnlineShop.Db.Models;
using GenericOnlineShop.Enums;
using GenericOnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenericOnlineShop.Services
{
    // Need to rebuild data access layer. 
    public class ReadWriteDbService : IReadWriteDbService
    {
        private readonly AppDbContext _dbContext;

        public ReadWriteDbService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<ProductType>> Read()
        {
            var data = _dbContext.ProductTypes.ToList();
            data.ForEach(p => Console.WriteLine(p));
            return data;
        }

        public async Task<IEnumerable<Product>> ReadProducts(string name)
        {
            Console.WriteLine(name);
            // Get ProductTypeId by its name.
            var typeId = _dbContext.ProductTypes
                .Where(p => p.Name == name)
                .Select(p => p.Id)
                .FirstOrDefault();

            Console.WriteLine($"This is typeId - {typeId} that was gotten by its name {name}");

            var data = _dbContext.Products
                .Where(p => p.TypeId == typeId);

            return data;
        }

        public async Task<IEnumerable<Product>> ReadProductsById(IEnumerable<uint> ids)
        {
            return _dbContext.Products.Where(p => ids.Contains(p.Id)).ToList();
        }

        public async Task<User> FindUser(SignInModel userModel)
        {
            return _dbContext.Users.Where(u => u.Email == userModel.Email).FirstOrDefault();
        }
    }
}
