using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.DTOs.Shop;
using BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Warehouse.Models;
using X.PagedList;

namespace Warehouse.Controllers
{
    [Authorize]
    public class ShopController : Controller
    {
        private readonly IShopOperations shopOperations;

        public ShopController(IShopOperations shopOperations)
        {
            this.shopOperations = shopOperations;
        }
        public IActionResult ShopList(int? page)
        {
            ShopListVM model = new ShopListVM();
            model.Shops = shopOperations.GetAllShops().ToPagedList(page ?? 1, 5);
            return View(model);
        }

        public IActionResult Search(string property, string value, int? page)
        {
            ShopListVM model = new ShopListVM();
            model.Shops = shopOperations.SearchShopBy(property, value).ToPagedList(page ?? 1, 5);
            return View("ShopList", model);
        }

        public IActionResult Add()
        {
            ShopFormVM model = new ShopFormVM();
            model.Components = shopOperations.GetComponents();
            return View(model);
        }

        [HttpPost]
        public IActionResult Add(ShopFormVM model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }
            shopOperations.Create(model.Shop);
            return RedirectToAction(nameof(ShopList));
        }

        public IActionResult Edit(int Id)
        {
            ShopFormVM model = new ShopFormVM();
            model.Shop = shopOperations.GetEditShopData(Id);
            model.Components = shopOperations.GetComponents();
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(ShopFormVM model)
        {
            model.Components = shopOperations.GetComponents();
            if(!ModelState.IsValid)
            {
                return View(model);
            }
            shopOperations.Edit(model.Shop);
            return View(model);
        }

        public IActionResult Delete(int Id)
        {
            shopOperations.Delete(Id);
            return RedirectToAction(nameof(ShopList));
        }

        public IActionResult Details(int Id)
        {
            ShopDetailsVM model = new ShopDetailsVM();
            model.Shop = shopOperations.GetShop(Id);
            model.Components = shopOperations.GetComponents();
            return View(model);
        }

        [HttpPost]
        public IActionResult AddProductShop(ShopDetailsVM model)
        {
            
            if (!ModelState.IsValid)
            {
                model.Shop = shopOperations.GetShop(model.ShopProduct.ShopId);
                model.Components = shopOperations.GetComponents();
                return View("Details", model);
            }
            shopOperations.AddShopProduct(model.ShopProduct);
            model.Shop = shopOperations.GetShop(model.ShopProduct.ShopId);
            model.Components = shopOperations.GetComponents();
            return View("Details", model);
        }

        public IActionResult DeleteProd(int Id,int shop)
        {
            shopOperations.DeleteProd(Id);
            ShopDetailsVM model = new ShopDetailsVM();
            model.Shop = shopOperations.GetShop(shop);
            model.Components = shopOperations.GetComponents();
            return View("Details", model);
        }
    }
}