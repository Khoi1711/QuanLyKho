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
    public class KHOHANGsController : Controller
    {
        private QLKhoDBContext db = new QLKhoDBContext();

        // GET: KHOHANGs
         public ActionResult Index(String thanhPho)
        {
            var khohang = db.KHOHANGs.AsQueryable();

            if (!string.IsNullOrEmpty(thanhPho))
            {
                var diaChiFilter = thanhPho.Trim().ToLower();
                var diaChiFilterEnd = diaChiFilter.Split(',').LastOrDefault()?.Trim();
                if (!string.IsNullOrEmpty(diaChiFilterEnd))
                {
                    khohang = khohang.Where(ncc => ncc.DiaChi.ToLower().EndsWith(diaChiFilterEnd));
                }
            }

            return View(khohang.ToList());
        }

        // GET: KHOHANGs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KHOHANG kHOHANG = db.KHOHANGs.Find(id);
            if (kHOHANG == null)
            {
                return HttpNotFound();
            }
            return View(kHOHANG);
        }

        // GET: KHOHANGs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: KHOHANGs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaKhoHang,TenKhohang,DiaChi,SDTKho")] KHOHANG kHOHANG)
        {
            if (ModelState.IsValid)
            {
                db.KHOHANGs.Add(kHOHANG);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kHOHANG);
        }

        // GET: KHOHANGs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KHOHANG kHOHANG = db.KHOHANGs.Find(id);
            if (kHOHANG == null)
            {
                return HttpNotFound();
            }
            return View(kHOHANG);
        }

        // POST: KHOHANGs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaKhoHang,TenKhohang,DiaChi,SDTKho")] KHOHANG kHOHANG)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kHOHANG).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kHOHANG);
        }

        // GET: KHOHANGs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KHOHANG kHOHANG = db.KHOHANGs.Find(id);
            if (kHOHANG == null)
            {
                return HttpNotFound();
            }
            return View(kHOHANG);
        }

        // POST: KHOHANGs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            KHOHANG kHOHANG = db.KHOHANGs.Find(id);
            db.KHOHANGs.Remove(kHOHANG);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult DeleteSelected(string[] selectedIds)
        {
            if (selectedIds != null && selectedIds.Length > 0)
            {
                foreach (var id in selectedIds)
                {
                    if (int.TryParse(id, out int Id))
                    {
                        var xoa = db.KHOHANGs.Find(Id);
                        if (xoa != null)
                        {
                            db.KHOHANGs.Remove(xoa);
                        }
                    }
                }
                db.SaveChanges();
            }

            return new EmptyResult();
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
