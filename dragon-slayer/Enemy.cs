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
        public Enemy(Vector location, Image sprite, Size bounds, int health, Direction direction)
            : base(location, sprite, bounds, health, direction)
        {
            isAlive = true;
        }
        public override void Draw(Graphics g)
        {
            g.DrawImage(sprite, location.X, location.Y, 16 * GameManager.pixelScale, 16 * GameManager.pixelScale);
            g.DrawRectangle(new Pen(Color.Yellow), new Rectangle((int)location.X + 4 * GameManager.pixelScale, (int)location.Y, bounds.Width, bounds.Height));
        }
        public override void Move()
        {
        }
    }
}
