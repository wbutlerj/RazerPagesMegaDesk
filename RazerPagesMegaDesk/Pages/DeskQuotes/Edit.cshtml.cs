﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazerPagesMegaDesk.Data;
using RazerPagesMegaDesk.Model;

namespace RazerPagesMegaDesk.Pages.DeskQuotes
{
    public class EditModel : PageModel
    {
        private readonly RazerPagesMegaDesk.Data.RazerPagesMegaDeskContext _context;

        public EditModel(RazerPagesMegaDesk.Data.RazerPagesMegaDeskContext context)
        {
            _context = context;
        }


        [BindProperty]
        public Desk Desk { get; set; }

        [BindProperty]
        public DeskQuote DeskQuote { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            DeskQuote = await _context.DeskQuote
                .Include(d => d.Desk).FirstOrDefaultAsync(m => m.DeskQuoteId == id);

            if (DeskQuote == null)
            {
                return NotFound();
            }
            ViewData["DeskId"] = new SelectList(_context.Set<Desk>(), "DeskId", "DeskId");
            ViewData["ShippingId"] = new SelectList(_context.Set<Shipping>(), "ShippingId", "ShippingName");
            ViewData["SurfaceMaterialId"] = new SelectList(_context.Set<SurfaceMaterial>(), "SurfaceMaterialId", "SurfaceMaterialName");
            return Page();

        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(DeskQuote).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeskQuoteExists(DeskQuote.DeskQuoteId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool DeskQuoteExists(int id)
        {
            return _context.DeskQuote.Any(e => e.DeskQuoteId == id);
        }
    }
}
