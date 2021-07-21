using GenericOnlineShop.Db.Models;
using GenericOnlineShop.Enums;
using GenericOnlineShop.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenericOnlineShop.Services
{
    public interface IReadWriteDbService
    {
        public Task<IEnumerable<ProductType>> Read();

        public Task<IEnumerable<Product>> ReadProducts(string name);

        public Task<IEnumerable<Product>> ReadProductsById(IEnumerable<uint> ids);

        public Task<User> FindUser(SignInModel userModel);
    }
}