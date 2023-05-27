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
    public class VITRIKHOesController : Controller
    {
        private QLKhoDBContext db = new QLKhoDBContext();

        // GET: VITRIKHOes
        public ActionResult Index()
        {
            var vITRIKHOes = db.VITRIKHOes.Include(v => v.KHOHANG);
            return View(vITRIKHOes.ToList());
        }

        // GET: VITRIKHOes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VITRIKHO vITRIKHO = db.VITRIKHOes.Find(id);
            if (vITRIKHO == null)
            {
                return HttpNotFound();
            }
            return View(vITRIKHO);
        }

        // GET: VITRIKHOes/Create
        public ActionResult Create()
        {
            ViewBag.MaKhoHang = new SelectList(db.KHOHANGs, "MaKhoHang", "TenKhohang");
            return View();
        }

        // POST: VITRIKHOes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaVTK,TenVTK,MoTa,MaKhoHang")] VITRIKHO vITRIKHO)
        {
            if (ModelState.IsValid)
            {
                db.VITRIKHOes.Add(vITRIKHO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaKhoHang = new SelectList(db.KHOHANGs, "MaKhoHang", "TenKhohang", vITRIKHO.MaKhoHang);
            return View(vITRIKHO);
        }

        // GET: VITRIKHOes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VITRIKHO vITRIKHO = db.VITRIKHOes.Find(id);
            if (vITRIKHO == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaKhoHang = new SelectList(db.KHOHANGs, "MaKhoHang", "TenKhohang", vITRIKHO.MaKhoHang);
            return View(vITRIKHO);
        }

        // POST: VITRIKHOes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaVTK,TenVTK,MoTa,MaKhoHang")] VITRIKHO vITRIKHO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vITRIKHO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaKhoHang = new SelectList(db.KHOHANGs, "MaKhoHang", "TenKhohang", vITRIKHO.MaKhoHang);
            return View(vITRIKHO);
        }

        // GET: VITRIKHOes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VITRIKHO vITRIKHO = db.VITRIKHOes.Find(id);
            if (vITRIKHO == null)
            {
                return HttpNotFound();
            }
            return View(vITRIKHO);
        }

        // POST: VITRIKHOes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VITRIKHO vITRIKHO = db.VITRIKHOes.Find(id);
            db.VITRIKHOes.Remove(vITRIKHO);
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
                        var xoa = db.VITRIKHOes.Find(Id);
                        if (xoa != null)
                        {
                            db.VITRIKHOes.Remove(xoa);
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
