using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Razorweb.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Razorweb.Binders;

namespace Razorweb.Pages_Blog
{
    public class IndexModel : PageModel
    {
        private readonly Razorweb.Models.MyBlogContext _context;
        [BindProperty(SupportsGet = true)]
        [StringLength(20,MinimumLength =2,ErrorMessage ="Từ khóa tìm kiếm phải nằm trong khoảng {2} đến {1} ký tự")]
        [Display(Name="Tìm kiếm",Prompt = "Nhập từ khóa ...")]
        [ModelBinder(BinderType = typeof(KeyWordBinding))]
        public string SearchString { get; set; } = "";
        //------------------------------- Paging ---------------------------------
        public const int ITEMS_PER_PAGE = 10;
        [BindProperty(SupportsGet =true,Name ="p")]
        public int currentPage { get; set; }
        public int countPages { get; set; }

        public IndexModel(Razorweb.Models.MyBlogContext context)
        {
            _context = context;
        }

        public IList<Article> Article { get;set; }

        public async Task OnGetAsync()
        {
            
            int totalArticle = await _context.articles.CountAsync(); //Console.WriteLine("Tong = "+totalArticle);
            countPages = (int)Math.Ceiling((double)totalArticle / ITEMS_PER_PAGE);
            if(currentPage<1) currentPage = 1;
            if(currentPage>countPages) currentPage = countPages; Console.WriteLine("Current Page = "+countPages);
            //Article = await _context.articles.ToListAsync();
            var query = (from a in _context.articles orderby a.Created descending select a)
                        .Skip((currentPage-1)*ITEMS_PER_PAGE)
                        .Take(ITEMS_PER_PAGE);
            //Article = await query.ToListAsync();
            if(ModelState.IsValid){
                Console.WriteLine("Key: "+SearchString);
                Article = await query.Where(a=>a.Title.Contains(SearchString)).ToListAsync();
            }else{
                Article = await query.ToListAsync();
            }
            
        }
    }
}
