using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LabDay4MVC.Models;

namespace LabDay4MVC.Controllers
{
    public class CatalogController : Controller
    {
        ITIContext db = new ITIContext();
        // GET: Catalog
        public ActionResult Index()
        {
            SelectList st = new SelectList(db.TbCatalogs.ToList(), "id", "name");
            return View(st);
        }
    }
}