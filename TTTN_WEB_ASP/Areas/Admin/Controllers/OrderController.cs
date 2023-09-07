using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using TTTN_WEB_ASP.Models;

namespace TTTN_WEB_ASP.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class OrderController :  Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index(int? page)
        {
            var items = db.Orders.OrderByDescending(x=>x.CreatedDate).ToList();
            if(page ==null)
            {
                page = 1;
            }
            var pageNumber = page ?? 1;
            var pageSize = 5;
            ViewBag.PageSize = pageSize;
            ViewBag.Page = page;
            return View(items.ToPagedList(pageNumber,pageSize));
        }
        public ActionResult View(int id)
        {
            var item = db.Orders.Find(id);
            return View(item);
        }
        [HttpPost]
        public ActionResult UpdateTT(int id,int trangthai)
        {
            var item = db.Orders.Find(id);
            if(item!=null)
            {
                db.Orders.Attach(item);
                item.TypePayment = trangthai;
                db.Entry(item).Property(x => x.TypePayment).IsModified = true;
                db.SaveChanges();
                return Json(new { message = "Success", Success = true });
            }
            return Json(new { message = "Unsuccess", Success = false });
        }
    }
}
