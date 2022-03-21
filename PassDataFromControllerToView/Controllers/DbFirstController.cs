using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace PassDataFromControllerToView.Controllers
{
    public class DbFirstController : Controller
    {
        DbFirstEntities _context;
        private Product _product;

        public DbFirstController()
        {
            _context = new DbFirstEntities();
        }
        public ActionResult Create()
        {
            return View(new Product { Id=0});  
        }

        public ActionResult Search(string search)
        {
           // var product=from p in _context.Products 
                       // where p.Name.Contains(search)  
                       // select p;

            var matchingProducts = _context.Products.Where(p => p.Name.Contains(search));

            return View("Index",matchingProducts);
           // var products = _context.Products.Where(p =>p.Name == search).ToList();
           // return View("Index",products);
        }




        [HttpPost]
        public ActionResult Create(Product _product)
        {
            if(ModelState.IsValid)
            {
                if (_product.Id > 0)
                    _context.Entry(_product).State = System.Data.Entity.EntityState.Modified;
                else
                    _context.Products.Add(_product);

                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            return View("Create", _product);
        }

        //edit
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var product = _context.Products.Find(id);
            if(product == null) 
                return HttpNotFound();
            return View("Create",product);
        }




        //remove memory
        protected override void Dispose(bool disposing)
        {
            if (disposing)
                _context.Dispose();
            base.Dispose(disposing);
        }
        // GET: DbFirst
        public ActionResult Index()
        {
            var products = _context.Products.ToList();
            return View(products);
        }
        //delete 
        public ActionResult Delete(int? id)
        {
            if(id==null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            Product product = _context.Products.Find(id);
            if (product == null)
                return HttpNotFound();
            _context.Products.Remove(product);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}