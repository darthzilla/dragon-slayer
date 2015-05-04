using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dragon_slayer
{
    public class Character
    {
        public Point location { get; set; }
        Image sprite { get; set; }
        public Size bounds { get; set; }
        public int health { get; set; }
        public Character(Point location, Image sprite, Size bounds, int health)
        {
            this.location = location;
            this.sprite = sprite;
            this.bounds = bounds;
            this.health = health;
        }

        public void Move()
        {

        }
    }
}
