using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyBlog.Core.Objects;
using MyBlog.Core;

namespace MyBlog.Models
{
    public class ListViewModel
    {
        public ListViewModel(IBlogRepository _blogRepository, int pageNumber)
        {
            Posts = _blogRepository.Posts(pageNumber - 1, 10);
            TotalPosts = _blogRepository.TotalPosts();
        }

        public ListViewModel(IBlogRepository blogRepository, string categorySlug, int pageNumber)
        {
            Posts = blogRepository.PostsForCategory(categorySlug, pageNumber - 1, 10);
            TotalPosts = blogRepository.TotalPostsForCategory(categorySlug);
            Category = blogRepository.Category(categorySlug);
        }

        public IList<Post> Posts { get; private set; }
        public int TotalPosts { get; private set; }
        public Category Category { get; private set; }
    }
}