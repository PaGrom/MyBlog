﻿using System;
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
            var viewModel = new ListViewModel(_blogRepository, category, "Category", p);

            if (viewModel.Category == null)
            {
                throw new HttpException(404, "Category not found");
            }

            ViewBag.Title = String.Format($"Latest posts on category \"{viewModel.Category.Name}\"");

            return View("List", viewModel);
        }

        public ViewResult Tag(string tag, int p = 1)
        {
            var viewModel = new ListViewModel(_blogRepository, tag, "Tag", p);

            if (viewModel.Tag == null)
            {
                throw new HttpException(404, "Tag not found");
            }

            ViewBag.Title = String.Format($"Latest posts tagged on \"{viewModel.Tag.Name}\"");

            return View("List", viewModel);
        }

        public ViewResult Search(string s, int p = 1)
        {
            ViewBag.Title = String.Format($"Lists of posts found for search text \"{s}\"");

            var viewModel = new ListViewModel(_blogRepository, s, "Search", p);

            return View("List", viewModel);
        }

        public ViewResult Post(int year, int month, string title)
        {
            var post = _blogRepository.Post(year, month, title);

            if (post == null)
                throw new HttpException(404, "Post not found");

            if (post.Published == false && User.Identity.IsAuthenticated == false)
                throw new HttpException(401, "The post is not published");

            return View(post);
        }

        [ChildActionOnly]
        public PartialViewResult Sidebars()
        {
            var widgetViewModel = new WidgetViewModel(_blogRepository);
            return PartialView("_Sidebars", widgetViewModel);
        }
    }
}