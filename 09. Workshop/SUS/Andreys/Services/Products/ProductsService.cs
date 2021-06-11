using Andreys.Data;
using Andreys.Data.Enums;
using Andreys.ViewModels.Product;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Andreys.Services.Products
{
    public class ProductsService : IProductsService
    {
        private readonly ApplicationDbContext db;

        public ProductsService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void AddProduct(AddProductViewModel model)
        {
            var product = new Product
            {
                Name = model.Name,
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                Category = (Category)Enum.Parse(typeof(Category), model.Category),
                Gender = (Gender)Enum.Parse(typeof(Gender), model.Gender),
                Price = model.Price
            };

            this.db.Products.Add(product);

            this.db.SaveChanges();
        }

        public void DeleteProduct(int id)
        {
            var product = this.db.Products.FirstOrDefault(x => x.Id == id);

            this.db.Products.Remove(product);

            this.db.SaveChanges();
        }

        public IEnumerable<GetAllProductsViewModel> GetAll() =>
            this.db.Products
            .Select(x => new GetAllProductsViewModel
            {
                Id = x.Id,
                ImageUrl = x.ImageUrl,
                Name = x.Name,
                Price = x.Price
            })
            .ToList();

        public GetProductDetailsViewModel GetDetails(int id) =>
        this.db.Products
            .Select(x => new GetProductDetailsViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                ImageUrl = x.ImageUrl,
                Category = x.Category.ToString(),
                Gender = x.Gender.ToString(),
                Price = x.Price
            })
            .FirstOrDefault(x => x.Id == id);
    }
}
