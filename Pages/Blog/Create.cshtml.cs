using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Razorweb.Models;

namespace Razorweb.Pages_Blog
{
    public class CreateModel : PageModel
    {
        private readonly Razorweb.Models.MyBlogContext _context;

        public CreateModel(Razorweb.Models.MyBlogContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Article Article { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            //_context.articles.Add(Article);
            _context.Add(Article); // Có thể ko cần truy cập đến thuộc tính Article
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
