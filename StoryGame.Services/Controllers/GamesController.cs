using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using StoryGame.Services.Models;

namespace StoryGame.Services.Controllers
{
    public class GamesController : ApiController
    {
        private GameDbContext db = new GameDbContext();

        // GET: api/Games
        public IQueryable<Game> GetGames()
        {
            return db.Games;
        }

        // GET: api/Games/5
        [ResponseType(typeof(Game))]
        public IHttpActionResult GetGame(Guid id)
        {
            Game Game = db.Games.Find(id);
            if (Game == null)
            {
                return NotFound();
            }

            return Ok(Game);
        }

        // PUT: api/Games/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutGame(Guid id, Game Game)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != Game.Id)
            {
                return BadRequest();
            }

            db.Entry(Game).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GameExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Games
        [ResponseType(typeof(Game))]
        public IHttpActionResult PostGame(Game game)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Games.Add(game);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (GameExists(game.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = game.Id }, game);
        }

        // DELETE: api/Games/5
        [ResponseType(typeof(Game))]
        public IHttpActionResult DeleteGame(Guid id)
        {
            Game Game = db.Games.Find(id);
            if (Game == null)
            {
                return NotFound();
            }

            db.Games.Remove(Game);
            db.SaveChanges();

            return Ok(Game);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GameExists(Guid id)
        {
            return db.Games.Count(e => e.Id == id) > 0;
        }
    }
}