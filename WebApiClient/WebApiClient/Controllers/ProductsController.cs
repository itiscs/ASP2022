using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiClient.Models;
using WebApiClient.Services;

namespace WebApiClient.Controllers
{
    public class ProductsController : Controller
    {

        ProductService serv = new ProductService();

        // GET: ProductsController
        public ActionResult Index()
        {
            return View(serv.GetProducts());
        }

        // GET: ProductsController/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
                return BadRequest();

            var prod = serv.GetProduct(id.Value);
            if (prod == null)
                return NotFound();

            return View(prod);
        }

        // GET: ProductsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind]Product prod)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    serv.AddProduct(prod);
                    return RedirectToAction(nameof(Index));
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductsController/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return BadRequest();

            var prod = serv.GetProduct(id.Value);
            if (prod == null)
                return NotFound();

            return View(prod);
        }

        // POST: ProductsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind]Product prod)
        {
            if (id != prod.ProductId)
                return BadRequest();
            
            if(ModelState.IsValid)
            {
                serv.EditProduct(id, prod);
                return RedirectToAction(nameof(Index));
            }

            return View();            
        }

        // GET: ProductsController/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return BadRequest();

            var prod = serv.GetProduct(id.Value);
            if (prod == null)
                return NotFound();

            return View(prod);

        }

        // POST: ProductsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                serv.DeleteProduct(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
