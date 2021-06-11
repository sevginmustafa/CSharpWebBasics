using Andreys.Services.Products;
using Andreys.ViewModels.Product;
using SUS.HTTP;
using SUS.MvcFramework;
using System;
using static SUS.MvcFramework.BaseHttpAttribute;

namespace Andreys.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductsService productsService;

        public ProductsController(IProductsService productsService)
        {
            this.productsService = productsService;
        }

        public HttpResponse Add()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Add(AddProductViewModel model)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if (string.IsNullOrWhiteSpace(model.Name) || model.Name.Length < 4 || model.Name.Length > 20)
            {
                return this.Error("Name is requiered and should be between 4 and 20 characters!");
            }

            if (model.Description.Length > 10)
            {
                return this.Error("Description should be less than or equal 10 characters!");
            }

            if (!Uri.TryCreate(model.ImageUrl, UriKind.Absolute, out _))
            {
                return this.Error("Image URL is invalid!");
            }

            this.productsService.AddProduct(model);

            return this.Redirect("/");
        }

        public HttpResponse Details(int id)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var model = this.productsService.GetDetails(id);

            if (model == null)
            {
                return this.Redirect("/");
            }

            return this.View(model);
        }

        public HttpResponse Delete(int id)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            this.productsService.DeleteProduct(id);

            return this.Redirect("/");
        }
    }
}
