using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndrewCasey_S00200841
{
    class Game
    {
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

        public override string ToString()
        {
            return Name;
        }

        // Decrease price is just set up quick till i need to test i will work out then
        public void DecreasePrice(double decrease)
        {
            Price /= (decimal)(decrease + 1);
        }
    }
}
