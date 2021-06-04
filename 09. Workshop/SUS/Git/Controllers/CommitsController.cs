using Git.Services.Commits;
using Git.ViewModels;
using SUS.HTTP;
using SUS.MvcFramework;
using static SUS.MvcFramework.BaseHttpAttribute;

namespace Git.Controllers
{
    public class CommitsController : Controller
    {
        private readonly ICommitsService commitsService;

        public CommitsController(ICommitsService commitsService)
        {
            this.commitsService = commitsService;
        }

        public HttpResponse All()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var commits = this.commitsService.GetAll(this.GetUserId());

            return this.View(commits);
        }

        public HttpResponse Create(string id)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var model = new CommitForRepositoryOutputModel { Id = id, Name = this.commitsService.GetRepositoryName(id) };

            return this.View(model);
        }

        [HttpPost]
        public HttpResponse Create(string id, string description)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if (string.IsNullOrWhiteSpace(description) || description.Length < 5)
            {
                return this.Error("Description is required and should be more than 5 characters!");
            }

            this.commitsService.CreateCommit(id, description, this.GetUserId());

            return this.Redirect("/Repositories/All");
        }

        public HttpResponse Delete(string id)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            this.commitsService.DeleteCommit(id);

            return this.Redirect("/Commits/All");
        }
    }
}
