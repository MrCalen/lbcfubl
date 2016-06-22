﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LBCFUBL.Services;
using LBCFUBL.BusinessManagement;


namespace LBCFUBL.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            ViewUtils.FillViewBag(ViewBag, TempData, User.Identity.Name);
            return View();
        }

        [HttpGet]
        [CustomAuthorizeAttribute(Roles = "admin")]
        public ActionResult Report()
        {
            try
            {
                GlobalReport report = GlobalReport.CreateReport();
                return File(report.FilePath, report.MimeType, report.FileName);
            }
            catch (ArgumentException)
            {
                return HttpNotFound();
            }
        }
    }
}
