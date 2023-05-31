using QuanLyKho.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace QuanLyKho.Controllers
{
    public class CreateTaskControllerController : Controller
    {
        // GET: CreateTaskController
        QLKhoDBContext db = new QLKhoDBContext();
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        //public ActionResult Index(Task entity)
        //{
        //    bool result = db.CreateTask(entity);

        //    if (result)
        //    {
        //        return Redirect("/Home");
        //    }

        //    return new HttpStatusCodeResult(400);
        //}

    }
}