using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndrewCasey_S00200841
{
    public class Game
    {
        // Properties
        public int ID { get; set; } // PK
        public string Name { get; set; }
        public int MetacriticScore { get; set; }
        public string Description { get; set; }
        public string Platform { get; set; }
        public decimal Price { get; set; }
        public string Game_Image { get; set; }

        public Game() { } // Empty Constructor

        // Constructor
        public Game(string name, int MetaScore, string description, string platform, decimal price, string game_Image = "")
        {
            Name = name;
            MetacriticScore = MetaScore;
            Description = description;
            Platform = platform;
            Price = price;
        }
        // Standard ToString will just return Name
        public override string ToString()
        {
            return Name;
        }

        // Decrease price could most likely be done another way
        public void DecreasePrice(double decrease)
        {
            // holding Price
            decimal holder = Price;
            // Find Percentage amount taken from Price
            holder *= (decimal)(decrease);
            // Decrease it from Price
            Price -= (holder);
            // Round Price by 2 decimal place to ensure we get a price rather than ex(45.9435... etc)
            Price = Decimal.Round(Price, 2, MidpointRounding.AwayFromZero);
        }
    }

    public class GameData : DbContext
    {
        public GameData() : base("GameDataInformation") { } // Database Name
        public DbSet<Game> Games { get; set; } // Table Creation for Games
    }
}
