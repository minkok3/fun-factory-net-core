using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Extensions;

namespace WebApp.Controllers
{
    public class ProductsController:Controller
    {
        private readonly FunFactoryDbContext _dbContext;

        public ProductsController(FunFactoryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ActionResult Index()
        {
            ViewBag.Title = "Products";
            var products = _dbContext.Products.ToList();
            return View(products);
        }

        [HttpGet]
        public ActionResult Details(long id)
        {
            var products = _dbContext.Products.Include(prod => prod.KitComponents).ToList();
            var product = products.Single(x => x.Id == id);
            foreach(var prodComp in product.KitComponents)
            {
                var component = _dbContext.Products.FirstOrDefault(x => x.Id == prodComp.Id);
                prodComp.Name = component.Name;
            }
            //var components= _dbContext.Components.Contains(x=>x.Component)

            return View(product);
        }

        [HttpPost]
        public ActionResult Details(long id, int qty)
        {
            var products = _dbContext.Products.Include(prod => prod.KitComponents).ToList();
            var product = products.Single(x=>x.Id==id);
            
            product.AdjustStockQuantities(qty);
            if (product.KitComponents.Any())
            {
                foreach(var component in product.KitComponents)
                {
                    var prod = _dbContext.Products.FirstOrDefault(x => x.Id == component.Id);
                    prod.AdjustStockQuantities(qty);
                    component.Name = prod.Name;
                }
            }
            _dbContext.SaveChanges();

            ViewBag.Message = "Purchase successful";
            return View(product);
        }
    }
}
