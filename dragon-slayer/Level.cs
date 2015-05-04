using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dragon_slayer
{
    public class Level
    {
        Rectangle floorBoundBox;
        public Image bg { get; set; }
        public Level(Image bg)
        {
            this.bg = bg;
            floorBoundBox = new Rectangle(0, 624, 1248, 16 * GameManager.pixelScale);
        }

        public void Draw(Graphics g)
        {
            g.DrawImageUnscaled(bg, 0, 0);
            g.FillRectangle(new SolidBrush(Color.Red), floorBoundBox);
        }
    }
}
