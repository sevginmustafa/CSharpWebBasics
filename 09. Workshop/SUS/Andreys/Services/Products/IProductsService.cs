using Andreys.ViewModels.Product;
using System.Collections.Generic;

namespace Andreys.Services.Products
{
    public interface IProductsService
    {
        void AddProduct(AddProductViewModel model);

        IEnumerable<GetAllProductsViewModel> GetAll();

        GetProductDetailsViewModel GetDetails(int productId);

        void DeleteProduct(int id);
    }
}
