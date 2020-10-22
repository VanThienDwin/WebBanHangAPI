using Microsoft.AspNetCore.Http;
using SaleWebsiteAPI.Helper.Product;
using SaleWebsiteAPI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaleWebsiteAPI.Interfaces
{
    public interface IManageProductService
    {
        Task<int> Create(ProductCreateRequest request);
        Task<int> Update(ProductUpdateRequest request);
        Task<int> Delete(int productId);
        Task<ProductViewModel> getProductById(int productId);
        Task<List<ProductViewModel>> GetAll();
        //page view model (list , total record)
        Task<PagedResult<ProductViewModel>> GetAllPaging(GetProductPagingRequest request);
        Task<List<ProductViewModel>> searchProduct(ProductSearchRequest request);
        Task<string> SaveFile(IFormFile file);
    }
}
