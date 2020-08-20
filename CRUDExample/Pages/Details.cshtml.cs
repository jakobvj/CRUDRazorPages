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
    public class DetailsModel : PageModel
    {
        private readonly IRepository _context;

        public DetailsModel(IRepository context)
        {
            _context = context;
        }

        public Person Person { get; set; }

        public IActionResult OnGet(int? id)
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
    }
}
