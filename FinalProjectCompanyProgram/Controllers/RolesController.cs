using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalProjectCompanyProgram.Models.DbContexts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinalProjectCompanyProgram.Controllers
{
    public class RolesController : Controller
    {
        //private readonly UserRolesDbContext _context;

        //public RolesController(UserRolesDbContext context)
        //{
        //    _context = context;
        //}

        [Authorize(Roles = "Owner")]
        public IActionResult Index()
        {
            return View();
        }

        //[Authorize]
        //public async Task<IActionResult> Index()
        //{
        //    //return View(await _context.UserRoles.ToListAsync());
        //    return View();
        //}
    }
}