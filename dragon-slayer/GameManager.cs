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
        
        public GameManager()
        {
            gameOver = false;
            levels = new List<Level>();
            level1 = new Level(Resources.level1bg);
            marko = new Hero(new Vector(48f, groundPoint), Resources.marko, new Size(8 * pixelScale, 16 * pixelScale), 10, Direction.RIGHT);
            
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
        }
        public void Draw(Graphics g)
        {
            level1.Draw(g);
            marko.Draw(g);
            
        }
    }
}
