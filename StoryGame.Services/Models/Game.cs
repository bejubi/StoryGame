using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace StoryGame.Services.Models
{
    public class Game
    {
        public Guid Id { get; set; }

        public DateTime CreateDate { get; set; }
    }

    public class GameDbContext : DbContext
    {
        public GameDbContext() : base("DefaultConnection") { }

        public DbSet<Game> Games { get; set; }
    }
}