using EvidenceFinal.Models;
using EvidenceFinal.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EvidenceFinal.Controllers
{
    public class ItemController : Controller
    {
        EcommerceDBEntities db = new EcommerceDBEntities();
        // GET: Item
        public ActionResult Index()
        {
            var data = db.Items.Select(x => new ItemsVM { Id = x.Id, Name = x.Name, Price = x.Price });
            return View(data);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Item p)
        {
            if (ModelState.IsValid)
            {
                db.Items.Add(p);
                db.SaveChanges();
                return PartialView("_success");
            }
            return PartialView("_error");
        }
        public ActionResult Edit(int id)
        {
            return View(db.Items.First(x => x.Id == id));
        }
        [HttpPost]
        public ActionResult Edit(Item p)
        {
            if (ModelState.IsValid)
            {
                db.Entry(p).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(p);

        }
        public ActionResult Delete(int id)
        {
            return View(db.Items.First(x => x.Id == id));
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DoDelete(int id)
        {
            var p = new Item { Id = id };
            db.Entry(p).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}