//using Google;
//using QuanLyKho.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;

//namespace QuanLyKho.Controllers
//{
//    public class CanlendarController : Controller
//    {
//        // GET: Canlendar
//        private readonly QLKhoDBContext _context;
//        public CanlendarController(QLKhoDBContext context)
//        {
//            _context = context;
//        }

//        public ActionResult Index()
//        {
//            var events = _context.Events.ToList();
//            return View(events);
//        }

//        public ActionResult Create()
//        {
//            return View();
//        }

//        [HttpPost]
//        public ActionResult Create(Event @event)
//        {
//            if (ModelState.IsValid)
//            {
//                _context.Events.Add(@event);
//                _context.SaveChanges();
//                return RedirectToAction(nameof(Index));
//            }
//            return View(@event);
//        }
//    }
//}