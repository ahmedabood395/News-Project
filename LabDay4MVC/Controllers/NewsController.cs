using LabDay4MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LabDay4MVC.Controllers
{
    public class NewsController : Controller
    {
        ITIContext db = new ITIContext();
        // GET: News
        public ActionResult Home()
        {
            List<TbNew> newList= db.TbNews.ToList();
           ViewBag.NewList= newList.Distinct().OrderBy(n => n.date);

            SelectList st = new SelectList(db.TbCatalogs.ToList(),"id","name");

            return View(st);
        }
       public ActionResult catalogNews(int id)
        {
            List<TbNew> nlist = db.TbNews.Where(n => n.Catalog_id == id).ToList();
            ViewBag.NewList = nlist;
            return PartialView();
        }
        public ActionResult create()
        {
            List<TbCatalog> cataloglist = db.TbCatalogs.ToList();
            SelectList st = new SelectList(cataloglist, "id", "name");
            ViewBag.catalog = st;

            return View();
        }
        [HttpPost]
        public ActionResult create(TbNew n, HttpPostedFileBase photo)
        {
            if (ModelState.IsValid)
            {
                photo.SaveAs(Server.MapPath($"~/images/{photo.FileName}"));
                n.photo = photo.FileName;
                db.TbNews.Add(n);
                db.SaveChanges();

                return View();
            }
            else {
                List<TbCatalog> cataloglist = db.TbCatalogs.ToList();
                SelectList st = new SelectList(cataloglist, "id", "name");
                ViewBag.catalog = st;
                return View(n);
            }
        }
        public ActionResult edit(int id)
        {
            TbNew nw= db.TbNews.Where(n => n.id == id).FirstOrDefault();
            List<TbCatalog> c = db.TbCatalogs.ToList();
            SelectList s = new SelectList(c, "id", "name");
            ViewBag.catalog = s;
            return View(nw);
        }
        [HttpPost]
        public ActionResult edit(TbNew n, HttpPostedFileBase img)
        {
            string idd = Session["id"].ToString();
            img.SaveAs(Server.MapPath($"~/images/{img.FileName}"));
            n.photo = img.FileName;
            TbNew nw  = db.TbNews.Where(t => t.id == n.id).FirstOrDefault();
            nw.title = n.title;
            nw.pref = n.pref;
            nw.date = n.date;
            nw.description = n.description;
            nw.photo = n.photo;
            nw.Catalog_id = n.Catalog_id;
            nw.User_id = int.Parse(idd);
            //nw.User_id = (int)Session["id"];

            //db.Entry(n).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("display", "User",new { id=nw.User_id});
        }
        public ActionResult delete(int id)
        {
           TbNew tn= db.TbNews.Where(n => n.id == id).FirstOrDefault();
            db.TbNews.Remove(tn);
            db.SaveChanges();
            return RedirectToAction("display", "User", new { id = Session["id"] });

        }
    }
}