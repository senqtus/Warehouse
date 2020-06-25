using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BLL.Interfaces;
using DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Warehouse.Models;

namespace Warehouse.Controllers
{

    public class HomeController : Controller
    {
        private readonly IShopOperations shopOperations;
        private readonly IHostingEnvironment hostingEnvironment;


        public HomeController(IShopOperations shopOperations, IHostingEnvironment hostingEnvironment)
        { 
            this.shopOperations = shopOperations;
            this.hostingEnvironment = hostingEnvironment;
        }


        public string Index()
        {
            var model = shopOperations.GetComponents();
            string data = JsonConvert.SerializeObject(model);
            return data;
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
