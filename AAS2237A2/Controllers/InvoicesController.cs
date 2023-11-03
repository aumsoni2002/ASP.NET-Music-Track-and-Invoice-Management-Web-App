using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AAS2237A2.Controllers
{
    public class InvoicesController : Controller
    {
        private Manager m = new Manager();

        // GET: Invoices
        public ActionResult Index()
        {
            return View(m.InvoiceGetAll());
        }

        // GET: Invoices/Details/5
        public ActionResult Details(int? id)
        {
            // Attempt to get the matching object
            var o = m.InvoiceGetByIdWithDetail(id.GetValueOrDefault());

            if (o == null)
            {
                return HttpNotFound();
            }
            else
            {
                // Pass the object to the view
                return View(o);
            }
        }
    }
}
