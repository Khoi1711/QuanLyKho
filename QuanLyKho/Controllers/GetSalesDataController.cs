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
        public JsonResult GetSalesData()
        {
            using (var context = new QLKhoDBContext())
            {
                var salesData = context.Database.SqlQuery<SalesData>("GetSalesData1").ToList();
                return Json(salesData, JsonRequestBehavior.AllowGet);
            }
        }
    }
}