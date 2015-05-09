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
        public Vector location { get; set; }
        public Image sprite { get; set; }
        public Size bounds { get; set; }
        public int health { get; set; }
        public int speed { get; set; }
        public Direction direction { get; set; }
        public Character(Vector location, Image sprite, Size bounds, int health,Direction direction)
        {
            this.location = location;
            this.sprite = sprite;
            this.bounds = bounds;
            this.health = health;
            this.speed = 200;
            this.direction = direction;
        }

        public abstract void Move();

        public abstract void Draw(Graphics g);
    }
}
