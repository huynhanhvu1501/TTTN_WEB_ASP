using Dapper;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TTTN_WEB_ASP.Models;
using TTTN_WEB_ASP.Models.EF;

namespace TTTN_WEB_ASP.Controllers
{
    public class ProductsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Products
      
        public ActionResult Index(string Searchtext, int? page)
        {
            var pageSize = 20;
            if (page == null)
            {
                page = 1;
            }
            IEnumerable<Product> items = db.Products.ToList();
            if (!string.IsNullOrEmpty(Searchtext))
            {
                items = items.Where(x => x.Alias.Contains(Searchtext) || x.Title.Contains(Searchtext));
            }
            var pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            items = items.ToPagedList(pageIndex, pageSize);
            ViewBag.PageSize = pageSize;
            ViewBag.Page = page;
            return View(items);
        }
        public ActionResult Detail(string alias, int id)
        {
            var item = db.Products.Find(id);
            if(item !=null)
            {
                db.Products.Attach(item);
                item.ViewCount = item.ViewCount + 1;
                db.Entry(item).Property(x => x.ViewCount).IsModified = true;
                db.SaveChanges();
            }
            return View(item);
        }
        public ActionResult ProductCategory( string alias, int? id)
        {

            var items = db.Products.ToList();
            if (id >0)
            {
                items = items.Where(x => x.ProductCategoryId == id).ToList();
            }
            var cate = db.ProductCategories.Find(id);
            if(cate!=null)
            {
                ViewBag.CateName = cate.Title;
            }    
            ViewBag.CateId = id;
            return View(items);
        }
        public ActionResult Partival_ItemByCateId()
        {
            var items = db.Products.Where(x => x.IsHome && x.IsActive).Take(20).ToList();
            return PartialView(items);
        }
        public ActionResult Partival_ProductSales()
        {
            var items = db.Products.Where(x => x.IsSale && x.IsActive).Take(12).ToList();
            return PartialView(items);
        }
    }
}