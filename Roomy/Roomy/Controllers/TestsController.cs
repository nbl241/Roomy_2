using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Roomy.Controllers
{
    public class TestsController : BaseController
    {
        // GET: Test
        public ActionResult Index()
        {
            List<string> prenom = new List<string>
            {
                "gary", "antoine", "thomas"
            };
            return View(prenom);
        }
    }
}