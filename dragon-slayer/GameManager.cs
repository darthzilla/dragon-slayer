using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dragon_slayer.Properties;
using System.Windows.Forms;

namespace dragon_slayer
{
    public class GameManager
    {
        public static int pixelScale = 3;

        public static float groundPoint = 576f;

        List<Level> levels;
        Level level1;

        public Hero marko;

        public bool gameOver { get; set; }
        public List<Platform> platforms {get; set;}
        
        public GameManager()
        {
            gameOver = false;
            levels = new List<Level>();
            platforms = new List<Platform>();
            Platform first = new Platform(new Vector(480, 502), new Size(48 * pixelScale, 8 * pixelScale));
            platforms.Add(first);
            level1 = new Level(Resources.level1bg,platforms);
            marko = new Hero(new Vector(48f, 50), Resources.marko_r, new Size(8 * pixelScale, 16 * pixelScale), 10, Direction.RIGHT);
            
        }
        public void Update()
        {
            gameOver = marko.EnemyCheck(level1.enemies);
            if (gameOver)
            {
                return;
            }

            marko.ToMoveOrNotToMove();
            marko.GroundCheck();
            marko.Move();
            marko.Jump();
            marko.PlatformCheck(level1.platforms);
            marko.Gravity();
        }
        public void Draw(Graphics g)
        {
            level1.Draw(g);
            marko.Draw(g);
            
        }
    }
}
