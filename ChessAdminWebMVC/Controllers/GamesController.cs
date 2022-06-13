using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ChessAdminWebMVC;
using ChessAdminWebMVC.Models;
using ChessAdminWebMVC.Repositories;

namespace ChessAdminWebMVC.Controllers
{
    public class GamesController : Controller
    {
       // private ChessAdminDbEntities1 db = new ChessAdminDbEntities1();
        private IChessAdminWebMVCContext db = new ChessAdminDbEntities1();

        // add these constructors
        public GamesController() { }

        public GamesController(IChessAdminWebMVCContext context)
        {
            db = context;
        }
        // GET: Games
        public ActionResult Index()
        {
            var games = db.Games.Include(g => g.Member).Include(g => g.Member1).Include(g => g.Member2);
            return View(games.ToList());
        }

        // GET: Games/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game game = db.Games.Find(id);
            if (game == null)
            {
                return HttpNotFound();
            }
            return View(game);
        }

        // GET: Games/Create
        public ActionResult Create()
        {
            ViewBag.PlayerOneID = new SelectList(db.Members, "ID", "Name");
            ViewBag.PlayerTwoID = new SelectList(db.Members, "ID", "Name");
            ViewBag.WinnerID = new SelectList(db.Members, "ID", "Name");
            return View();
        }

        // POST: Games/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,PlayerOneID,PlayerTwoID,GameDate,WinnerID,IsDraw,PlayerOneCurrentRank,PlayerTwoCurrentRank,PlayerOneRankAfterGame,PlayerTwoRankAfterGame")] Game game)
        {
            if (ModelState.IsValid)
            {
                GameRepository.SaveGameBeforeMatch(game);
                return RedirectToAction("Index");
            }

            ViewBag.PlayerOneID = new SelectList(db.Members, "ID", "Name", game.PlayerOneID);
            ViewBag.PlayerTwoID = new SelectList(db.Members, "ID", "Name", game.PlayerTwoID);
            ViewBag.WinnerID = new SelectList(db.Members, "ID", "Name", game.WinnerID);
            return View(game);
        }

        // GET: Games/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game game = db.Games.Find(id);
            if (game == null)
            {
                return HttpNotFound();
            }
            //Limit Winner to the 2 players
            ViewBag.PlayerOneID = new SelectList(db.Members, "ID", "Name", game.PlayerOneID);
            ViewBag.PlayerTwoID = new SelectList(db.Members, "ID", "Name", game.PlayerTwoID);
            ViewBag.WinnerID = new SelectList(db.Members.Where(x => x.ID == game.PlayerOneID || x.ID == game.PlayerTwoID), "ID", "Name", game.WinnerID);
            return View(game);
        }

        // POST: Games/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,PlayerOneID,PlayerTwoID,GameDate,WinnerID,IsDraw,PlayerOneCurrentRank,PlayerTwoCurrentRank,PlayerOneRankAfterGame,PlayerTwoRankAfterGame")] Game game)
        {
            if (ModelState.IsValid)
            {
                GameRepository.SaveGameAfterMatch(game);
                return RedirectToAction("Index");
            }
            ViewBag.PlayerOneID = new SelectList(db.Members, "ID", "Name", game.PlayerOneID);
            ViewBag.PlayerTwoID = new SelectList(db.Members, "ID", "Name", game.PlayerTwoID);
            ViewBag.WinnerID = new SelectList(db.Members, "ID", "Name", game.WinnerID);
            return View(game);
        }

        // GET: Games/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game game = db.Games.Find(id);
            if (game == null)
            {
                return HttpNotFound();
            }
            return View(game);
        }

        // POST: Games/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Game game = db.Games.Find(id);
            db.Games.Remove(game);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
