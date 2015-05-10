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
        public List<Platform> platforms { get; set; }
        public List<Wall> walls { get; set; }

        public Rectangle exit { get; set; }

        public Level(Image bg,List<Platform> platforms, List<Wall> walls, List<Enemy> enemies)
        {
            this.bg = bg;
            floorBoundBox = new Rectangle(0, 624, 1248, 16 * GameManager.pixelScale);
            this.enemies = new List<Enemy>();
            this.platforms = new List<Platform>();
            this.platforms = platforms;
            this.walls = new List<Wall>();
            this.walls = walls;
            this.enemies = enemies;
            exit = new Rectangle(1200, (int)GameManager.groundPoint, GameManager.unit, GameManager.unit);
        }

        public void Draw(Graphics g)
        {
            g.DrawImageUnscaled(bg, 0, 0);
            //g.FillRectangle(new SolidBrush(Color.Red), floorBoundBox); floor bounding box
            if(enemies.Count > 0)
                foreach (Enemy fiend in enemies)
                {
                    if(fiend.isAlive)
                        fiend.Draw(g);
                }
            if (platforms.Count > 0)
            {
                foreach (Platform p in platforms)
                {
                    p.Draw(g);
                }
                foreach (Wall w in walls)
                {
                    w.Draw(g);
                }
            }
        }
    }
}
