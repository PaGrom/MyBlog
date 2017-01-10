using System.Web.Mvc;
using MyBlog.Core;
using MyBlog.Models;

namespace MyBlog.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogRepository _blogRepository;

        public BlogController(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public ViewResult Posts(int pageNumber = 1)
        {
            var viewModel = new ListViewModel(_blogRepository, pageNumber);

            ViewBag.Title = "Latest Posts";

            return View("List", viewModel);
        }
    }
}