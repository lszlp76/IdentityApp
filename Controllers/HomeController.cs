using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using IdentityApp.Models;

namespace IdentityApp.Controllers;

public class HomeController : Controller
{
    

    public IActionResult Index()
    {
        return View();
    }


}
