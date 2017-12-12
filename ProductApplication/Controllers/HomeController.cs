using System.Linq;
using System.Web.Mvc;
using ProductApplication.Models;
namespace ProductApplication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetProducts()
        {
            using (Database1Entities db =new Database1Entities())
            {
                var products = db.Products.OrderBy(a => a.Id).ToList();
                return Json(new { data = products }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult Save(int id)
        {
            using (Database1Entities db=new Database1Entities())
            {
                var p = db.Products.Where(a => a.Id == id).FirstOrDefault();
                return View(p); 
            }
        }
        [HttpPost]
        public ActionResult Save(Product p)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                using (Database1Entities db = new Database1Entities())
                {
                    if (p.Id > 0)
                    {
                         var products = db.Products.Where(a => a.Id == p.Id).FirstOrDefault();
                        if (products != null)
                        {
                            products.ProductName = p.ProductName;
                            products.Price = p.Price;
                        }
                    }
                    else
                    {

                        db.Products.Add(p);
                  
                    }
                    db.SaveChanges();
                    status = true;
                }

            }
            return new JsonResult { Data = new { status=status} };
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            using (Database1Entities db=new Database1Entities())
            {
                var p = db.Products.Where(a => a.Id ==id).FirstOrDefault();
                if (p != null)
                {
                    return View(p);
                }
                else
                {
                    return HttpNotFound();
                }
            }
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteProduct( int id)
        {
            bool status = false;
            using (Database1Entities db=new Database1Entities())
            {   
                var p = db.Products.Where(a => a.Id == id).FirstOrDefault();
                if (p != null)
                {
                    db.Products.Remove(p);
                    db.SaveChanges();
                    status = true;
                }
            }
                return new JsonResult { Data = new { status = status } };
        }
    }

}