using Lab_09.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab_09.Controllers
{
    public class SongController : Controller
    {
        // GET: Song
        public ActionResult Index()
        {
            if (Session["Songs"] == null)
            {
                List<Songs> songs = new List<Songs>();
                songs.Add(new Songs {ID = 100 , Title = "Si supieras" , Genre = "Indie", ReleaseDate = DateTime.Today, Price = 99});
                songs.Add(new Songs {ID = 200 , Title = "Baby Blue" , Genre = "Folk", ReleaseDate = DateTime.Today, Price = 88});
                songs.Add(new Songs {ID = 300 , Title = "mOBSCENE" , Genre = "Hard Rock", ReleaseDate = DateTime.Today, Price = 77});
                Session["Songs"] = songs;
            }

            return View(Session["Songs"]);
        }

        // GET: Song/Details/5
        public ActionResult Details(int id)
        {
            var model = ((List<Songs>)Session["Songs"]).Where(x => x.ID == id).FirstOrDefault();
            return View(model);
        }

        // GET: Song/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Song/Create
        [HttpPost]
        public ActionResult Create(Songs model)
        {
            try
            {
                //numero random
                Random rnd = new Random();
                int idrdn = rnd.Next(1, 999);

                if (Session["Songs"] == null)
                    Session["Songs"] = new List<Songs>();
                if (model.ID == 0)
                {
                    model.ID = idrdn;
                    ((List<Songs>)Session["Songs"]).Add(model);
                } else if (model.ID == idrdn)
                {
                    model.ID = idrdn+1;
                    ((List<Songs>)Session["Songs"]).Add(model);
                }
                else
                {
                    ((List<Songs>)Session["Songs"]).Add(model);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Song/Edit/5
        public ActionResult Edit(int id)
        {
            var model = ((List<Songs>)Session["Songs"]).Where(x => x.ID == id).FirstOrDefault();
            return View(model);
        }

        // POST: Song/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Song/Delete/5
        public ActionResult Delete(int id)
        {
            var model = ((List<Songs>)Session["Songs"]).Where(x => x.ID == id).FirstOrDefault();
            return View(model);
        }

        // POST: Song/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Songs model)
        {
            try
            {
                // TODO: Add delete logic here
                var lista = ((List<Songs>)Session["Songs"]).ToList();

                var item = ((List<Songs>)Session["Movies"]).Single(r=>r.ID == id);
                
                lista.Remove(item);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
