using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dragon_slayer
{
    public class Wall
    {
        public Vector location { get; set; }
        public Size bounds { get; set; }
        public Rectangle box {get; set;}
        public Wall(Vector location, Size bounds)
        {
            this.location = location;
            this.bounds = bounds;
            box = new Rectangle((int)location.X, (int)location.Y, bounds.Width, bounds.Height);
        }
        public void Draw(Graphics g)
        {
            g.FillRectangle(new SolidBrush(Color.Black), box);
        }
    }
}
