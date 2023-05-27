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
    public class PHIEUNHAPKHOesController : Controller
    {
        private QLKhoDBContext db = new QLKhoDBContext();

        // GET: PHIEUNHAPKHOes
        public ActionResult Index()
        {
            var pHIEUNHAPKHOes = db.PHIEUNHAPKHOes.Include(p => p.NHACUNGCAP);
            return View(pHIEUNHAPKHOes.ToList());
        }

        // GET: PHIEUNHAPKHOes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PHIEUNHAPKHO pHIEUNHAPKHO = db.PHIEUNHAPKHOes.Find(id);
            if (pHIEUNHAPKHO == null)
            {
                return HttpNotFound();
            }
            return View(pHIEUNHAPKHO);
        }

        // GET: PHIEUNHAPKHOes/Create
        public ActionResult Create()
        {
            ViewBag.MaNCC = new SelectList(db.NHACUNGCAPs, "MaNCC", "TenNCC");
            return View();
        }

        // POST: PHIEUNHAPKHOes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaPNK,NgayNhap,TongTien,TongSPNhapKho,MaNCC")] PHIEUNHAPKHO pHIEUNHAPKHO)
        {
            if (ModelState.IsValid)
            {
                db.PHIEUNHAPKHOes.Add(pHIEUNHAPKHO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaNCC = new SelectList(db.NHACUNGCAPs, "MaNCC", "TenNCC", pHIEUNHAPKHO.MaNCC);
            return View(pHIEUNHAPKHO);
        }

        // GET: PHIEUNHAPKHOes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PHIEUNHAPKHO pHIEUNHAPKHO = db.PHIEUNHAPKHOes.Find(id);
            if (pHIEUNHAPKHO == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaNCC = new SelectList(db.NHACUNGCAPs, "MaNCC", "TenNCC", pHIEUNHAPKHO.MaNCC);
            return View(pHIEUNHAPKHO);
        }

        // POST: PHIEUNHAPKHOes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaPNK,NgayNhap,TongTien,TongSPNhapKho,MaNCC")] PHIEUNHAPKHO pHIEUNHAPKHO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pHIEUNHAPKHO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaNCC = new SelectList(db.NHACUNGCAPs, "MaNCC", "TenNCC", pHIEUNHAPKHO.MaNCC);
            return View(pHIEUNHAPKHO);
        }

        // GET: PHIEUNHAPKHOes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PHIEUNHAPKHO pHIEUNHAPKHO = db.PHIEUNHAPKHOes.Find(id);
            if (pHIEUNHAPKHO == null)
            {
                return HttpNotFound();
            }
            return View(pHIEUNHAPKHO);
        }

        // POST: PHIEUNHAPKHOes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PHIEUNHAPKHO pHIEUNHAPKHO = db.PHIEUNHAPKHOes.Find(id);
            db.PHIEUNHAPKHOes.Remove(pHIEUNHAPKHO);
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
