using Private.Domain.DTOs.Product;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Private.Domain.Interfaces.Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAll();
        Task<ProductDto> Get(Int64 id);
        Task<ProductDto> Post(ProductDtoInsert product, Int64 idUser);
        Task<ProductDto> Put(Int64 id, ProductDtoUpdate product, Int64 idUser);
    }
}
