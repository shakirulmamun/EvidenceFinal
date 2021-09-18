using EvidenceFinal.Models;
using EvidenceFinal.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace EvidenceFinal.Controllers
{
    public class ItemsVMsController : Controller
    {
        private EcommerceDBEntities db = new EcommerceDBEntities();
        // GET: ItemsVMs
        public ActionResult Index()
        {
            return View(db.ItemsVMs.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemsVM itemsVM = db.ItemsVMs.Find(id);
            if (itemsVM == null)
            {
                return HttpNotFound();
            }
            return View(itemsVM);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Price")] ItemsVM itemsVM)
        {
            if (ModelState.IsValid)
            {
                db.ItemsVMs.Add(itemsVM);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(itemsVM);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemsVM itemsVM = db.ItemsVMs.Find(id);
            if (itemsVM == null)
            {
                return HttpNotFound();
            }
            return View(itemsVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Price")] ItemsVM itemsVM)
        {
            if (ModelState.IsValid)
            {
                db.Entry(itemsVM).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(itemsVM);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemsVM itemsVM = db.ItemsVMs.Find(id);
            if (itemsVM == null)
            {
                return HttpNotFound();
            }
            return View(itemsVM);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ItemsVM itemsVM = db.ItemsVMs.Find(id);
            db.ItemsVMs.Remove(itemsVM);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}