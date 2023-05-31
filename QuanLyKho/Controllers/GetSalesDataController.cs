using QuanLyKho.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyKho.Controllers
{
    public class GetSalesDataController : Controller
    {
        // GET: GetSalesData
        QLKhoDBContext data = new QLKhoDBContext();
        public JsonResult GetSalesData()
        {

            //        var salesData = data.Database.SqlQuery<SalesData>("GetSalesData").ToList();
            //        ViewBag.SalesData = salesData;
            //        return View();
            //    }
            //}
            //using (var context = new QLKhoDBContext())
            //{
            //    var salesData = context.SANPHAMs
            //        .Select(p => new SalesData
            //        {
            //            TenSP = p.TenSP,
            //            SoLuongXuat = (p.CTPHIEUXUATKHOes.Sum(od => od.SoLuongXuat))
            //        })
            //        .ToList();

            //    return Json(salesData, JsonRequestBehavior.AllowGet);
            //}

            using (var context = new QLKhoDBContext())
            {
                var salesData = context.Database.SqlQuery<SalesData>("GetSalesData").ToList();
                return Json(salesData, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
