using Git.Services.Repositories;
using SUS.HTTP;
using SUS.MvcFramework;
using static SUS.MvcFramework.BaseHttpAttribute;

namespace Git.Controllers
{
    public class RepositoriesController : Controller
    {
        private readonly IRepositoriesService repositoriesService;

        public RepositoriesController(IRepositoriesService repositoriesService)
        {
            this.repositoriesService = repositoriesService;
        }

        public HttpResponse All()
        {
            var repositories = this.repositoriesService.GetAllPublic();

            return this.View(repositories);
        }

        public HttpResponse Create()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Create(string name, string repositoryType)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if (string.IsNullOrEmpty(name) || name.Length < 3 || name.Length > 10)
            {
                return this.Error("Name is required and should be between 3 and 10 characters!");
            }

            if (string.IsNullOrWhiteSpace(repositoryType))
            {
                return this.Error("Type is required!");
            }

            this.repositoriesService.CreateRepository(name, repositoryType, this.GetUserId());

            return this.Redirect("/Repositories/All");
        }
    }
}
