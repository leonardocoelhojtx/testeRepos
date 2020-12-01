using AutoMapper;
using Private.Domain.DTOs.Product;
using Private.Domain.Entities;
using Private.Domain.Interfaces.Repositories;
using Private.Domain.Interfaces.Services;
using Private.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace Private.Service.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepositoryReadOnly _productRepoReadOnly;
        private readonly IProductRepository _productRepo;
        private readonly IMapper _mapper;

        public ProductService(
            IProductRepositoryReadOnly productRepoReadOnly,
            IProductRepository productRepo,
            IMapper mapper
            )
        {
            _productRepoReadOnly = productRepoReadOnly;
            _productRepo = productRepo;
            _mapper = mapper;
        }

        public async Task<ProductDto> Get(Int64 id)
        {
            var productEntity = await _productRepoReadOnly.SelectAsync(id);
            return _mapper.Map<ProductDto>(productEntity);
        }

        public async Task<IEnumerable<ProductDto>> GetAll()
        {
            var listProductEntity = await _productRepoReadOnly.SelectAsync();
            return _mapper.Map<List<ProductDto>>(listProductEntity.OrderBy(x => x.ShortDescription));
        }

        public async Task<ProductDto> Post(ProductDtoInsert product, Int64 idUser)
        {
            var productModel = _mapper.Map<ProductModel>(product);
            productModel.InclusionIdUser = idUser;
            productModel.ChangeIdUser = idUser;

            var productEntity = _mapper.Map<ProductEntity>(productModel);
            var result = await _productRepo.InsertAsync(productEntity);

            return _mapper.Map<ProductDto>(result);
        }

        public async Task<ProductDto> Put(Int64 id, ProductDtoUpdate product, Int64 idUser)
        {
            var productEntity = await _productRepoReadOnly.SelectAsync(id);

            if (productEntity == null)
                return null;

            productEntity.Description = !String.IsNullOrEmpty(product.Description) ? product.Description : productEntity.Description;
            productEntity.ShortDescription = !String.IsNullOrEmpty(product.ShortDescription) ? product.ShortDescription : productEntity.ShortDescription;
            productEntity.Status = !String.IsNullOrEmpty(product.Status) ? product.Status : productEntity.Status;
            productEntity.NCM = product.NCM;
            productEntity.EAN = !String.IsNullOrEmpty(product.EAN) ? product.EAN : productEntity.EAN;
            productEntity.ChangeIdUser = idUser;
            productEntity.ChangeDateTime = DateTime.Now;

            var result = await _productRepo.UpdateAsync(productEntity);

            return _mapper.Map<ProductDto>(result);
        }
    }
}
