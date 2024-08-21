using ECommerce.Business.Abstract;
using ECommerce.WebUI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: ProductController
        public async Task<ActionResult> Index(int page = 1, int category = 0)
        {
            int pageSize = 10;
            var items = await _productService.GetAllByCategoryAsync(category);

            var model = new ProductListViewModel
            {
                Products = items.Skip((page - 1) * pageSize).Take(pageSize).ToList(),
                CurrentCategory = category,
                PageCount = (int)Math.Ceiling(items.Count / (double)pageSize),
                PageSize = pageSize,
                CurrentPage = page
            };
            return View(model);
        }

        // GET: ProductController/SortByName
        public async Task<ActionResult> SortByName(int page = 1, int category = 0)
        {
            int pageSize = 10;
            var items = await _productService.GetAllByCategoryAsync(category);
            var sortedItems = items.OrderBy(p => p.ProductName).ToList();

            var model = new ProductListViewModel
            {
                Products = sortedItems.Skip((page - 1) * pageSize).Take(pageSize).ToList(),
                CurrentCategory = category,
                PageCount = (int)Math.Ceiling(sortedItems.Count / (double)pageSize),
                PageSize = pageSize,
                CurrentPage = page
            };
            return View("Index", model);
        }

        // GET: ProductController/SortByPrice
        public async Task<ActionResult> SortByPrice(int page = 1, int category = 0)
        {
            int pageSize = 10;
            var items = await _productService.GetAllByCategoryAsync(category);
            var sortedItems = items.OrderByDescending(p => p.UnitPrice).ToList();

            var model = new ProductListViewModel
            {
                Products = sortedItems.Skip((page - 1) * pageSize).Take(pageSize).ToList(),
                CurrentCategory = category,
                PageCount = (int)Math.Ceiling(sortedItems.Count / (double)pageSize),
                PageSize = pageSize,
                CurrentPage = page
            };
            return View("Index", model);
        }


        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
