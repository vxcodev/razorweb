using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using CS13v01RazorEntity.Models;

namespace CS13v01RazorEntity.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly MyBlogContext _blogContext;

        public IndexModel(ILogger<IndexModel> logger, MyBlogContext blogContext)
        {
            _logger = logger;
            _blogContext = blogContext;
        }

        public void OnGet()
        {
            List<Article> posts = (from p in _blogContext.articles orderby p.Created descending select p).ToList();
            ViewData["posts"] = posts;
        }
    }
}
