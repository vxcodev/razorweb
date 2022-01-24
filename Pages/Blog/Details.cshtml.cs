using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Razorweb.Models;

namespace Razorweb.Pages_Blog
{
    public class DetailsModel : PageModel
    {
        private readonly Razorweb.Models.MyBlogContext _context;

        public DetailsModel(Razorweb.Models.MyBlogContext context)
        {
            _context = context;
        }

        public Article Article { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return Content("Bài viết không tồn tại");
            }

            Article = await _context.articles.FirstOrDefaultAsync(m => m.Id == id);

            if (Article == null)
            {
                return Content("Bài viết không tồn tại");
            }
            return Page();
        }
    }
}
