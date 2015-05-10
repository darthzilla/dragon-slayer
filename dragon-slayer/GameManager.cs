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

        public static int unit = 48;

        public static float groundPoint = 576f;

        List<Level> levels;

        public Hero marko;

        public bool gameOver { get; set; }
        public List<Platform> platforms {get; set;}
        public List<Wall> walls { get; set; }
        public List<Enemy> enemies { get; set; }
        public int currentLevel { get; set; }
        
        public GameManager()
        {
            gameOver = false;
            currentLevel = 0;
            levels = new List<Level>();

            platforms = new List<Platform>();
            
            walls = new List<Wall>();

            enemies = new List<Enemy>();
            

            levels.Add(GenerateLevel(0));
            levels.Add(GenerateLevel(1));
            
            marko = new Hero(new Vector(48f, groundPoint), Resources.marko_r, new Size(8 * pixelScale, 16 * pixelScale), 10, Direction.RIGHT);
            
        }
        public void Update()
        {
            gameOver = marko.EnemyCheck(levels.ElementAt(currentLevel).enemies);
            if (gameOver)
            {
                return;
            }
            marko.ToMoveOrNotToMove();
            marko.GroundCheck();
            marko.Move();
            marko.Jump();
            marko.WallCheck(levels.ElementAt(currentLevel).walls);
            marko.PlatformCheck(levels.ElementAt(currentLevel).platforms);
            marko.KeepInBounds();
            marko.Gravity();
            if (levels.ElementAt(currentLevel).enemies.Count > 0)
                foreach (Enemy fiend in levels.ElementAt(currentLevel).enemies)
                {
                    fiend.Move();
                }
            Exit();
            
        }
        public void Draw(Graphics g)
        {
            levels.ElementAt(currentLevel).Draw(g);
            marko.Draw(g);
            
        }
        public void Animate()
        {
            marko.Animate();
        }
        //-------------------------------
        //| CHECK IF ABLE TO PROGRESS
        //-------------------------------
        public void Exit()
        {
            if (marko.location.X >= 1200)
            {
                foreach (Enemy e in levels.ElementAt(currentLevel).enemies)
                {
                    if (e.isAlive)
                        return;
                }
                if(currentLevel < levels.Count - 1)
                    NextLevel();
            }
        }
        public void NextLevel()
        {
            currentLevel++;
            marko.location = new Vector(48f, groundPoint);
        }
        //--------------------------
        //|GENERATE THE LEVELS HERE
        //--------------------------
        public Level GenerateLevel(int lvl)
        {
            switch (lvl)
            {
                case 0:
                    Platform first = new Platform(new Vector(480, 502), new Size(48 * pixelScale, 8 * pixelScale));
                    Platform pFour = new Platform(new Vector(780, 502), new Size(48 * pixelScale, 8 * pixelScale));
                    Platform pSecond = new Platform(new Vector(700, 384), new Size(16 * pixelScale, 16 * pixelScale));
                    Platform pThird = new Platform(new Vector(300, 576), new Size(16 * pixelScale, 16 * pixelScale));
                    platforms = new List<Platform>();
                    platforms.Add(pSecond);
                    platforms.Add(first);
                    platforms.Add(pThird);
                    platforms.Add(pFour);
                    
                    Wall wFirst = new Wall(new Vector(700, 384 + unit), new Size(16 * pixelScale, 240 - unit));
                    walls = new List<Wall>();
                    walls.Add(wFirst);

                    Enemy one = new Enemy(new Vector(200, GameManager.groundPoint), Resources.cruela_l, new Size(8 * GameManager.pixelScale, 16 * GameManager.pixelScale), 10, Direction.RIGHT);
                    enemies = new List<Enemy>();
                    enemies.Add(one);
                    return new Level(Resources.level1bg,platforms,walls,enemies);
                case 1:
                    first = new Platform(new Vector(680, 502), new Size(48 * pixelScale, 8 * pixelScale));
                    pFour = new Platform(new Vector(780, 502), new Size(48 * pixelScale, 8 * pixelScale));
                    pSecond = new Platform(new Vector(500, 384), new Size(16 * pixelScale, 16 * pixelScale));
                    pThird = new Platform(new Vector(300, 576), new Size(16 * pixelScale, 16 * pixelScale));
                    platforms = new List<Platform>();
                    platforms.Add(pSecond);
                    platforms.Add(first);
                    platforms.Add(pThird);
                    platforms.Add(pFour);

                    //wFirst = new Wall(new Vector(500, 384 + unit), new Size(16 * pixelScale, 240 - unit));
                    walls = new List<Wall>();
                    //walls.Add(wFirst);
                    
                    Enemy two = new Enemy(new Vector(900, GameManager.groundPoint), Resources.cruela_l, new Size(8 * GameManager.pixelScale, 16 * GameManager.pixelScale), 10, Direction.LEFT);
                    one = new Enemy(new Vector(200, GameManager.groundPoint), Resources.cruela_l, new Size(8 * GameManager.pixelScale, 16 * GameManager.pixelScale), 10, Direction.LEFT);
                    enemies = new List<Enemy>();
                    enemies.Add(one);
                    enemies.Add(two);
                    return new Level(Resources.level1bg, platforms, walls, enemies);
                default:
                    return null;
            }
        }
    }
}
