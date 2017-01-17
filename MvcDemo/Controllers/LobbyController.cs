using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using MvcDemo.Models;

namespace MvcDemo.Controllers
{
    
    public class LobbyController : Controller
    {
        private List<LobbyistViewModels> _lobbyists = new List<LobbyistViewModels>() {
        new LobbyistViewModels() { Id = 1, Name = "Sandra", Type = "Federal", IsRegistered=false },
        new LobbyistViewModels() { Id = 2, Name = "Elantra", Type = "Municipal", IsRegistered=true },
        new LobbyistViewModels() { Id = 3, Name = "Honda", Type = "Federal",IsRegistered=true }
    };


        //
        // GET: /Lobby/
        public ActionResult Index()
        {
            return View(_lobbyists);
        }

        //
        // GET: /Lobby/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Lobby/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Lobby/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Lobby/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Lobby/Edit/5
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

        //
        // GET: /Lobby/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Lobby/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
