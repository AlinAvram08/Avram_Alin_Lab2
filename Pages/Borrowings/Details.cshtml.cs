using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Avram_Alin_Lab2.Data;
using Avram_Alin_Lab2.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Avram_Alin_Lab2.Pages.Borrowings
{
    public class DetailsModel : PageModel
    {
        private readonly Avram_Alin_Lab2.Data.Avram_Alin_Lab2Context _context;

        public DetailsModel(Avram_Alin_Lab2.Data.Avram_Alin_Lab2Context context)
        {
            _context = context;
        }

      public Borrowing Borrowing { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Borrowing == null)
            {
                return NotFound();
            }
            var borrowing = await _context.Borrowing
                .Include(i => i.Member)
                .Include(i => i.Book)
                .ThenInclude(j => j.Author)
                .FirstOrDefaultAsync(m => m.ID == id);

            if (borrowing == null)
            {
                return NotFound();
            }
            else 
            {
                Borrowing = borrowing;


            }
            return Page();
        }
    }
}
