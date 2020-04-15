using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
//using FinalProjectCompanyProgram;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Diagnostics;

namespace LoginProject.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
    }
}