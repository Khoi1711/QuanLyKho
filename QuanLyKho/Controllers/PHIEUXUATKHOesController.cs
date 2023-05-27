using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QuanLyKho.Models;

namespace QuanLyKho.Controllers
{
    public class PHIEUXUATKHOesController : Controller
    {
        private QLKhoDBContext db = new QLKhoDBContext();

        // GET: PHIEUXUATKHOes
        public ActionResult Index()
        {
            return View(db.PHIEUXUATKHOes.ToList());
        }

        // GET: PHIEUXUATKHOes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PHIEUXUATKHO pHIEUXUATKHO = db.PHIEUXUATKHOes.Find(id);
            if (pHIEUXUATKHO == null)
            {
                return HttpNotFound();
            }
            return View(pHIEUXUATKHO);
        }

        // GET: PHIEUXUATKHOes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PHIEUXUATKHOes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaPXK,NgayXuat,TongTien,TongSPXuatKho")] PHIEUXUATKHO pHIEUXUATKHO)
        {
            if (ModelState.IsValid)
            {
                db.PHIEUXUATKHOes.Add(pHIEUXUATKHO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pHIEUXUATKHO);
        }

        // GET: PHIEUXUATKHOes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PHIEUXUATKHO pHIEUXUATKHO = db.PHIEUXUATKHOes.Find(id);
            if (pHIEUXUATKHO == null)
            {
                return HttpNotFound();
            }
            return View(pHIEUXUATKHO);
        }

        // POST: PHIEUXUATKHOes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaPXK,NgayXuat,TongTien,TongSPXuatKho")] PHIEUXUATKHO pHIEUXUATKHO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pHIEUXUATKHO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pHIEUXUATKHO);
        }

        // GET: PHIEUXUATKHOes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PHIEUXUATKHO pHIEUXUATKHO = db.PHIEUXUATKHOes.Find(id);
            if (pHIEUXUATKHO == null)
            {
                return HttpNotFound();
            }
            return View(pHIEUXUATKHO);
        }

        // POST: PHIEUXUATKHOes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PHIEUXUATKHO pHIEUXUATKHO = db.PHIEUXUATKHOes.Find(id);
            db.PHIEUXUATKHOes.Remove(pHIEUXUATKHO);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
