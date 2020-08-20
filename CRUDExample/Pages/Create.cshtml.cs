using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CRUDExample.Data;
using CRUDExample.Models;

namespace CRUDExample
{
    public class CreateModel : PageModel
    {
        private readonly IRepository _context;

        public CreateModel(IRepository context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Person Person { get; set; }


        public IActionResult OnPost()
        {
            _context.Insert(Person);

            return RedirectToPage("./Index");
        }
    }
}
