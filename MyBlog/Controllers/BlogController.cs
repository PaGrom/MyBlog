using System;
using System.Web;
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

        public ViewResult Category(string category, int p = 1)
        {
            var viewModel = new ListViewModel(_blogRepository, category, p);

            if (viewModel.Category == null)
            {
                throw new HttpException(404, "Category not found");
            }

            ViewBag.Title = String.Format($"Latest posts on category \"{viewModel.Category.Name}\"");

            return View("List", viewModel);
        }
    }
}