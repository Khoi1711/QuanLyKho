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
    public class CTPHIEUXUATKHOesController : Controller
    {
        private QLKhoDBContext db = new QLKhoDBContext();

        // GET: CTPHIEUXUATKHOes
        public ActionResult Index()
        {
            var cTPHIEUXUATKHOes = db.CTPHIEUXUATKHOes.Include(c => c.PHIEUXUATKHO).Include(c => c.SANPHAM);
            return View(cTPHIEUXUATKHOes.ToList());
        }

        // GET: CTPHIEUXUATKHOes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CTPHIEUXUATKHO cTPHIEUXUATKHO = db.CTPHIEUXUATKHOes.Find(id);
            if (cTPHIEUXUATKHO == null)
            {
                return HttpNotFound();
            }
            return View(cTPHIEUXUATKHO);
        }

        // GET: CTPHIEUXUATKHOes/Create
        public ActionResult Create()
        {
            ViewBag.MaPXK = new SelectList(db.PHIEUXUATKHOes, "MaPXK", "MaPXK");
            ViewBag.MaSP = new SelectList(db.SANPHAMs, "MaSP", "TenSP");
            return View();
        }

        // POST: CTPHIEUXUATKHOes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaCTPXK,MaSP,MaPXK,DonGia,SoLuongNhap")] CTPHIEUXUATKHO cTPHIEUXUATKHO)
        {
            if (ModelState.IsValid)
            {
                db.CTPHIEUXUATKHOes.Add(cTPHIEUXUATKHO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaPXK = new SelectList(db.PHIEUXUATKHOes, "MaPXK", "MaPXK", cTPHIEUXUATKHO.MaPXK);
            ViewBag.MaSP = new SelectList(db.SANPHAMs, "MaSP", "TenSP", cTPHIEUXUATKHO.MaSP);
            return View(cTPHIEUXUATKHO);
        }

        // GET: CTPHIEUXUATKHOes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CTPHIEUXUATKHO cTPHIEUXUATKHO = db.CTPHIEUXUATKHOes.Find(id);
            if (cTPHIEUXUATKHO == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaPXK = new SelectList(db.PHIEUXUATKHOes, "MaPXK", "MaPXK", cTPHIEUXUATKHO.MaPXK);
            ViewBag.MaSP = new SelectList(db.SANPHAMs, "MaSP", "TenSP", cTPHIEUXUATKHO.MaSP);
            return View(cTPHIEUXUATKHO);
        }

        // POST: CTPHIEUXUATKHOes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaCTPXK,MaSP,MaPXK,DonGia,SoLuongNhap")] CTPHIEUXUATKHO cTPHIEUXUATKHO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cTPHIEUXUATKHO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaPXK = new SelectList(db.PHIEUXUATKHOes, "MaPXK", "MaPXK", cTPHIEUXUATKHO.MaPXK);
            ViewBag.MaSP = new SelectList(db.SANPHAMs, "MaSP", "TenSP", cTPHIEUXUATKHO.MaSP);
            return View(cTPHIEUXUATKHO);
        }

        // GET: CTPHIEUXUATKHOes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CTPHIEUXUATKHO cTPHIEUXUATKHO = db.CTPHIEUXUATKHOes.Find(id);
            if (cTPHIEUXUATKHO == null)
            {
                return HttpNotFound();
            }
            return View(cTPHIEUXUATKHO);
        }

        // POST: CTPHIEUXUATKHOes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CTPHIEUXUATKHO cTPHIEUXUATKHO = db.CTPHIEUXUATKHOes.Find(id);
            db.CTPHIEUXUATKHOes.Remove(cTPHIEUXUATKHO);
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
