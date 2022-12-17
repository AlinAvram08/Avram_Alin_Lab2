using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Avram_Alin_Lab2.Data;
using Avram_Alin_Lab2.Models;
using Avram_Alin_Lab2.Models.ViewModels;

namespace Avram_Alin_Lab2.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly Avram_Alin_Lab2.Data.Avram_Alin_Lab2Context _context;

        public IndexModel(Avram_Alin_Lab2.Data.Avram_Alin_Lab2Context context)
        {
            _context = context;
        }

        public IList<Category> Category { get;set; } = default!;

        public CategoryIndexData CategoryData { get; set; }
        public int CategoryID { get; set; }
        public int BookID { get; set; }

        public async Task OnGetAsync(int? id, int? bookID)
        {
            CategoryData = new CategoryIndexData();
            CategoryData.Categories = await _context.Category
            .Include(i => i.BookCategories)
            .ThenInclude(i => i.Book)
            .ThenInclude(c => c.Author)
            .ToListAsync();

            if (id != null)
            {
                CategoryID = id.Value;
                Category category = CategoryData.Categories
                .Where(i => i.ID == id.Value).Single();
                CategoryData.BookCategories = category.BookCategories;
            }
        }
    }
}
