using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dragon_slayer
{
    public abstract class Character
    {
        public Point location { get; set; }
        public Image sprite { get; set; }
        public Size bounds { get; set; }
        public int health { get; set; }
        public int speed { get; set; }
        public Direction direction { get; set; }
        public Character(Point location, Image sprite, Size bounds, int health,int speed,Direction direction)
        {
            this.location = location;
            this.sprite = sprite;
            this.bounds = bounds;
            this.health = health;
            this.speed = speed;
            this.direction = direction;
        }

        public abstract void Move(Direction dir,double dT);

        public abstract void Draw(Graphics g);
    }
}
