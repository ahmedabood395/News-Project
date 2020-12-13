using LabDay4MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LabDay4MVC.Controllers
{
    public class UserController : Controller
    {
        ITIContext db = new ITIContext();
        // GET: User
        public ActionResult display(int id)
        {
            List<TbNew> n = db.TbNews.Where(t => t.User_id == id).ToList();
            return View(n);
        }
        public ActionResult register()
        {

            return View();
        }
        [HttpPost]
        public ActionResult register(TbUser u)
        {
            if (ModelState.IsValid)
            {
                db.TbUsers.Add(u);
                db.SaveChanges();

                return RedirectToAction("create", "News", new { User_id = u.id });
            }
            else
            {
                return View(u);
            }
        }
        public ActionResult login()
        {
            if (Request.Cookies["FullNews"] != null)
            {
                Session["id"] = Request.Cookies["FullNews"].Values["id"];
                return RedirectToAction("display", "User", new { id = Session["id"] });
            }
            else
                return View();
        }
        [HttpPost]
        public ActionResult login(LogIn ln, bool remeber)
        {
            TbUser u = db.TbUsers.Where(n => n.email == ln.Email && n.password == ln.Password).FirstOrDefault();
            if (u != null)
            {
                if (remeber)
                {
                    HttpCookie co = new HttpCookie("FullNews");
                    co.Values.Add("id", u.id.ToString());
                    co.Values.Add("name", u.name);
                    co.Expires = DateTime.Now.AddDays(15);
                    Response.Cookies.Add(co);
                }
                Session.Add("id", u.id);
                return RedirectToAction("display", "User", new { id = Session["id"] });
            }
            else
            {
                ViewBag.mess = "incorrect username or password";
                return View();
            }

        }
        public ActionResult logout()
        {
            Session["id"] = null;
            HttpCookie co = new HttpCookie("FullNews");
            co.Expires = DateTime.Now.AddDays(-30);
            Response.Cookies.Add(co);

            return RedirectToAction("login", "user");
        }

        public ActionResult changepass()
        {
           
            return View();
        }
        [HttpPost]
        public ActionResult changepass(ChangePassword c)
        {
            if (ModelState.IsValid)
            {
                string id = Session["id"].ToString();
                int idd = int.Parse(id);
                TbUser u = db.TbUsers.Where(n => n.id == idd).FirstOrDefault();
                if (c.password == u.password)
                {
                    u.password = c.new_password;
                    u.confirm_password = c.new_password;
                    //db.Entry(u).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("display", "User", new { id = Session["id"] });
                }
                else
                {
                    ViewBag.mess = "Old Password Not Matched";
                    return View();
                }
            }
            else {
                return View();
            }


            
        }
        public ActionResult check(string name)
        {
            TbUser u = db.TbUsers.Where(n => n.name == name).FirstOrDefault();
            if (u == null)
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            else 
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
           
        }

    }
}