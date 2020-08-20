using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CRUDExample.Data;
using CRUDExample.Models;

namespace CRUDExample
{
    public class IndexModel : PageModel
    {
        private readonly IRepository _context;

        public IndexModel(IRepository context)
        {
            _context = context;
        }

        public IList<Person> Person { get;set; }

        public void OnGet()
        {
            Person = _context.GetAll();
        }
    }
}
