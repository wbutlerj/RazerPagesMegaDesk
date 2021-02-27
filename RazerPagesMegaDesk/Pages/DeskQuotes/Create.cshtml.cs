using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazerPagesMegaDesk.Data;
using RazerPagesMegaDesk.Model;

namespace RazerPagesMegaDesk.Pages.DeskQuotes
{
    public class CreateModel : PageModel
    {
        private readonly RazerPagesMegaDeskContext _context;

        public CreateModel(RazerPagesMegaDeskContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["ShippingId"] = new SelectList(_context.Set<Shipping>(), "ShippingId", "ShippingName");
        ViewData["SurfaceMaterialId"] = new SelectList(_context.Set<SurfaceMaterial>(), "SurfaceMaterialId", "SurfaceMaterialName");
            return Page();
        }

        [BindProperty]
        public Desk Desk { get; set; }

        [BindProperty]
        public DeskQuote DeskQuote { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Desk.Add(Desk);
            await _context.SaveChangesAsync();

            //set desk id
            DeskQuote.DeskId = Desk.DeskId;

            //set desk 
            DeskQuote.Desk = Desk;

            //set quote date
            DeskQuote.QuoteDate = DateTime.Now;

            //set quote price
            DeskQuote.QuotePrice = DeskQuote.GetQuotePrice(_context);

            //add desk quote
            _context.DeskQuote.Add(DeskQuote);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
