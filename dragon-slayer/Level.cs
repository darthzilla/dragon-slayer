using dragon_slayer.Properties;
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

        public List<Enemy> enemies { get; set; }
        Random rng;
        public Level(Image bg)
        {
            rng = new Random();
            rng.Next();
            this.bg = bg;
            floorBoundBox = new Rectangle(0, 624, 1248, 16 * GameManager.pixelScale);
            enemies = new List<Enemy>();
            Enemy one = new Enemy(new Vector(rng.Next(300,1200), GameManager.groundPoint), Resources.cruela_l, new Size(8 * GameManager.pixelScale, 16 * GameManager.pixelScale), 10, Direction.LEFT);
            enemies.Add(one);
        }

        public void Draw(Graphics g)
        {
            g.DrawImageUnscaled(bg, 0, 0);
            g.FillRectangle(new SolidBrush(Color.Red), floorBoundBox);
            if(enemies.Count > 0)
                foreach (Enemy fiend in enemies)
                {
                    if(fiend.isAlive)
                        fiend.Draw(g);
                }
        }
    }
}
