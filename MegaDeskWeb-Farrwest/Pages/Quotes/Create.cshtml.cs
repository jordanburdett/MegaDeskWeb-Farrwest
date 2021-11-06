using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MegaDeskWeb_Farrwest.Data;
using MegaDeskWeb_Farrwest.Model;

namespace MegaDeskWeb_Farrwest.Pages.Quotes
{
    public class CreateModel : PageModel
    {
        private readonly MegaDeskWeb_Farrwest.Data.MegaDeskWeb_FarrwestContext _context;

        public CreateModel(MegaDeskWeb_Farrwest.Data.MegaDeskWeb_FarrwestContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Quote Quote { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Quote.Add(Quote);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
