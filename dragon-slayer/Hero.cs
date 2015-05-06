using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dragon_slayer.Properties;

namespace dragon_slayer
{
    class Hero : Character
    {
        public Rectangle weapon { get; set; }
        public bool attackState { get; set; }
        public Hero(Point location, Image sprite, Size bounds, int health,int speed,Direction direction) : base(location,sprite,bounds,health,speed,direction) 
        {
            weapon = WeaponUpdate(direction);
            attackState = false;
        }
        public override void Draw(Graphics g)
        {
            g.DrawImage(sprite,location.X,location.Y,16*GameManager.pixelScale,16*GameManager.pixelScale);
            g.DrawRectangle(new Pen(Color.Yellow), new Rectangle(location.X + 4*GameManager.pixelScale,location.Y, bounds.Width,bounds.Height));
            g.DrawRectangle(new Pen(Color.Blue), weapon);
        }
        public override void Move(Direction dir,double dT)
        {
            if (dir == Direction.RIGHT)
            {
                int newLoc = Convert.ToInt32(Math.Floor(location.X + 3 * speed * 0.016));
                location = new Point(newLoc, location.Y);
                weapon = WeaponUpdate(dir);
                sprite = SpriteUpdate(dir);
            }
            else if (dir == Direction.LEFT)
            {
                location = new Point(location.X - 3, location.Y);
                weapon = WeaponUpdate(dir);
                sprite = SpriteUpdate(dir);
            }
            
        }
        public Rectangle WeaponUpdate(Direction direction){
            if(direction == Direction.RIGHT)
                return new Rectangle(location.X + 11 * GameManager.pixelScale, location.Y + 6 * GameManager.pixelScale, 10 * GameManager.pixelScale, 5 * GameManager.pixelScale);
            else return new Rectangle(location.X - 5 * GameManager.pixelScale, location.Y + 6 * GameManager.pixelScale, 10 * GameManager.pixelScale, 5 * GameManager.pixelScale);
        }
        public Image SpriteUpdate(Direction direction)
        {
            if (direction == Direction.RIGHT)
            {
                return Resources.marko;
            }
            else return Resources.marko_left;
        }
    }
}
