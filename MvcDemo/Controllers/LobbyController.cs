using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

using MvcDemo.Models;

namespace MvcDemo.Controllers
{
    
    public class LobbyController : BaseController
    {
        private static List<LobbyistViewModels> _lobbyists = null;

        public LobbyController() {
            if (_lobbyists == null) { 
                _lobbyists = new List<LobbyistViewModels>() {
                    new LobbyistViewModels() { Id = 1, Name = "Sandra", Type = "Federal", IsRegistered=false },
                    new LobbyistViewModels() { Id = 2, Name = "Elantra", Type = "Municipal", IsRegistered=true },
                    new LobbyistViewModels() { Id = 3, Name = "Honda", Type = "Federal",IsRegistered=true },
                    new LobbyistViewModels() { Id = 7, Name = "Activa", Type = "Provincial", IsRegistered=true },
                };
            }
        }

        //
        // GET: /Lobby/
        [HttpGet]
        public ActionResult Index()
        {
            return View(_lobbyists);
        }

        //
        // GET: /Lobby/Details/5
        [HttpGet]
        public ActionResult Details(int id)
        {
            try {
                var lobbyist = GetLobbyistByID(id);
                if (lobbyist != null)
                    return View(lobbyist);
            }
            catch { }
            return RedirectToAction("Index"); 
        }

        //
        // GET: /Lobby/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Lobby/Create
        [HttpPost]
        public ActionResult Create(LobbyistViewModels lobbyist)
        {
            if (!ModelState.IsValid) { 
                return View(); 
            }

            try {
                InsertLobbyist(lobbyist);
                return RedirectToAction("Index");

            } catch {
                return View(); 
            }
        }

        //
        // GET: /Lobby/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            LobbyistViewModels lobbyist = GetLobbyistByID(id);
            if (lobbyist != null) {
                return View(lobbyist);
            }
            return RedirectToAction("Index");
        }

        //
        // POST: /Lobby/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, LobbyistViewModels lobbyist)
        {
            if (!ModelState.IsValid) {
                return View();
            }
            try {
                UpdateLobbyist(id, lobbyist);
                return RedirectToAction("Index");
            }
            catch {
                return View();
            }

        }

        //
        // GET: /Lobby/Delete/5
        public ActionResult Delete(int id)
        {
            LobbyistViewModels lobbyist = GetLobbyistByID(id);
            if (lobbyist != null) {
                return View(lobbyist);
            }
            return RedirectToAction("Index");
        }

        //
        // POST: /Lobby/Delete/5
        [HandleError(ExceptionType=typeof(NullReferenceException), View="CustomDeleteError")]
        [HttpPost]
        public ActionResult Delete(int id, LobbyistViewModels lobbyist)
        {
            DeleteLobbyist(null);
            DeleteLobbyist(lobbyist);
            return RedirectToAction("Index");
        }


        #region Private stuff

        private LobbyistViewModels GetLobbyistByID(int id) {
            return _lobbyists.Find(x => x.Id == (id));
        }

        private bool UpdateLobbyist(int id, LobbyistViewModels lobbyist) {
            if (lobbyist != null) {
                int ndx = _lobbyists.FindIndex(c => c.Id == id);
                if (ndx < 0) {
                    _lobbyists[ndx] = lobbyist;
                    return true;
                }
            }
            return false;
        }

        private void InsertLobbyist(LobbyistViewModels lobbyist) {
            if (lobbyist == null) { 
                return; 
            }
            Random rand = new Random();
            lobbyist.Id = rand.Next(999);
            //_lobbyists.Insert(_lobbyists.Count, lobbyist);
            _lobbyists.Add(lobbyist);
        }

        private int DeleteLobbyist( LobbyistViewModels lobbyist) {
            return _lobbyists.RemoveAll(x => x.Id == lobbyist.Id);
        }

        #endregion



    }

}


