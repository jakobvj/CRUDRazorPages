using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CRUDExample.Data;
using CRUDExample.Models;

namespace CRUDExample
{
    public class DeleteModel : PageModel
    {
        private readonly IRepository _context;

        public DeleteModel(IRepository context)
        {
            _context = context;
        }

        [BindProperty]
        public Person Person { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Person = _context.GetItemById(id);

            if (Person == null)
            {
                return NotFound();
            }
            return Page();
        }

        public IActionResult OnPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Person = _context.GetItemById(id);

            if (Person != null)
            {
                _context.Remove(Person.Id);
            }

            return RedirectToPage("./Index");
        }
    }
}
