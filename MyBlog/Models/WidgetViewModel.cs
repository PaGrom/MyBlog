using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyBlog.Core;
using MyBlog.Core.Objects;

namespace MyBlog.Models
{
    public class WidgetViewModel
    {
        public WidgetViewModel(IBlogRepository blogRepository)
        {
            Categories = blogRepository.Categories();
        }

        public IList<Category> Categories { get; private set; }
    }
}