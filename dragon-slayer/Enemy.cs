using dragon_slayer.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dragon_slayer
{
    public class Enemy : Character
    {
        public bool isAlive { get; set; }
        int startLoc { get; set; }
        public Enemy(Vector location, Image sprite, Size bounds, int health, Direction direction)
            : base(location, sprite, bounds, health, direction)
        {
            isAlive = true;
            startLoc = (int)location.X;
            this.speed = 50;
        }
        public override void Draw(Graphics g)
        {
            g.DrawImage(sprite, location.X, location.Y, 16 * GameManager.pixelScale, 16 * GameManager.pixelScale);
            //g.DrawRectangle(new Pen(Color.Yellow), new Rectangle((int)location.X + 4 * GameManager.pixelScale, (int)location.Y, bounds.Width, bounds.Height));
        }
        public override void Move()
        {
            if (direction == Direction.RIGHT)
            {
                if (location.X >= startLoc + 3 * GameManager.unit)
                    direction = Direction.LEFT;
                else 
                {
                    float newLoc = location.X + speed * GameManager.pixelScale * 0.016f;
                    location = new Vector(newLoc, location.Y);
                }
            }
            else if (direction == Direction.LEFT)
            {
                if (location.X <= startLoc)
                    direction = Direction.RIGHT;
                else
                {
                    float newLoc = location.X - speed * GameManager.pixelScale * 0.016f;
                    location = new Vector(newLoc, location.Y);
                }
            }
            sprite = SpriteUpdate(direction);
        }
        //-------------------------------
        //| SPRITE UPDATE METHOD
        //-------------------------------
        public Image SpriteUpdate(Direction direction)
        {
            if (direction == Direction.RIGHT)
            {
                return Resources.cruela_r;
            }
            else return Resources.cruela_l;
        }
    }
}
