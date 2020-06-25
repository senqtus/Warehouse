using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Warehouse.Models;
using X.PagedList;

namespace Warehouse.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        private readonly IProductOperations productOperations;
        private readonly IHostingEnvironment hostingEnvironment;
        public ProductController(IProductOperations productOperations, IHostingEnvironment hostingEnvironment)
        {
            this.productOperations = productOperations;
            this.hostingEnvironment = hostingEnvironment;
        }
        public IActionResult ProductList(int? page)
        {
            ProductListVM model = new ProductListVM();
            model.Products = productOperations.GetAllProducts().ToPagedList(page ??1,5);
            return View(model);
        }

        public IActionResult Add()
        {
            ProductFormVM model = new ProductFormVM();
            return View(model);
        }

        [HttpPost]
        public IActionResult Add(ProductFormVM model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }
            model.Product.Thumb = UploadFile(model.Product.file);
            productOperations.Create(model.Product);
            return RedirectToAction(nameof(ProductList));
        }

        public IActionResult Edit(int Id)
        {
            ProductFormVM model = new ProductFormVM();
            model.Product = productOperations.GetEditProductData(Id);
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(ProductFormVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            string thumb = UploadFile(model.Product.file);
            model.Product.Thumb = string.IsNullOrEmpty(thumb) ? model.Product.Thumb : thumb;
            productOperations.Edit(model.Product);
            return View(model);
        }

        public IActionResult Delete(int Id)
        {
            productOperations.Delete(Id);
            return RedirectToAction(nameof(ProductList));
        }

        public IActionResult Search(string property,string value,int? page)
        {
            ProductListVM model = new ProductListVM();
            model.Products = productOperations.SearchProductBy(property, value).ToPagedList(page ?? 1,5);
            return View("ProductList",model);
        }

        private string GenerateFileDirectoryName()
        {
            return $"{DateTime.Now.Year}/{DateTime.Now.Month}/";
        }

        private void checkAndCreateDirectory(string path)
        {
            bool exists = Directory.Exists(Path.Combine(hostingEnvironment.WebRootPath, path));
            if (!exists)
            {
                Directory.CreateDirectory(Path.Combine(hostingEnvironment.WebRootPath, path));
            }
        }

        private string FileVersionCheckAndUpdate(string filename, string path, string ext)
        {
            int count = 1;
            string newFilename = filename;
            string newPath = Path.Combine(path, filename + ext);
            while (System.IO.File.Exists(Path.Combine(hostingEnvironment.WebRootPath, newPath)))
            {
                newFilename = String.Format("{0}({1})", filename, count++);
                newPath = Path.Combine(path, newFilename + ext);
            }
            return newFilename;
        }

        private string UploadFile(IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                string name = Path.GetFileNameWithoutExtension(file.FileName);
                string ext = Path.GetExtension(file.FileName);
                string fileDirectoryName = GenerateFileDirectoryName();
                checkAndCreateDirectory($"Storage/{fileDirectoryName}");
                name = FileVersionCheckAndUpdate(name, $"Storage/{fileDirectoryName}", ext);
                var path = Path.Combine(hostingEnvironment.WebRootPath, "Storage", fileDirectoryName + name + ext);

                using (var stream = System.IO.File.Create(path))
                {
                    file.CopyTo(stream);
                }
                return Path.Combine("Storage", fileDirectoryName + name + ext);
            }
            return String.Empty;
        }
    }
}