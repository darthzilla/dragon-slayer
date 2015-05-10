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

        public List<Level> levels { get; set; }
        public Hero marko { get; set; }
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
                    Platform first = new Platform(new Vector(300, groundPoint + 24), new Size(288 * pixelScale, 8 * pixelScale));
                    Platform pSecond = new Platform(new Vector(300 + 48, groundPoint), new Size((288-16) * pixelScale, 8 * pixelScale));
                    Platform pThird = new Platform(new Vector(300 + 48*2, groundPoint - 24), new Size((288 - 16*2) * pixelScale, 8 * pixelScale));
                    Platform pFour = new Platform(new Vector(300 + 48 * 3, groundPoint - 24 * 2), new Size((288 - 16 * 3) * pixelScale, 8 * pixelScale));
                    Platform pFive = new Platform(new Vector(300 + 48 * 4, groundPoint - 24 * 3), new Size((288 - 16 * 4) * pixelScale, 8 * pixelScale));
                    Platform pSix = new Platform(new Vector(300 + 48 * 5, groundPoint - 24 * 4), new Size((288 - 16 * 5) * pixelScale, 8 * pixelScale));
                    Platform pSeven = new Platform(new Vector(300 + 48 * 6, groundPoint - 24 * 5), new Size((288 - 16 * 6) * pixelScale, 8 * pixelScale));
                    Platform pEight = new Platform(new Vector(300 + 48 * 7, groundPoint - 24 * 6), new Size((288 - 16 * 7) * pixelScale, 8 * pixelScale));
                    Platform pNine = new Platform(new Vector(300 + 48 * 8, groundPoint - 24 * 7), new Size((288 - 16 * 8) * pixelScale, 8 * pixelScale));
                    Platform pTen = new Platform(new Vector(300 + 48 * 9, groundPoint - 24 * 8), new Size((288 - 16 * 9) * pixelScale, 8 * pixelScale));
                    Platform pEleven = new Platform(new Vector(300 + 48 * 10, groundPoint - 24 * 9), new Size((288 - 16 * 10) * pixelScale, 8 * pixelScale));
                    Platform pTwelve = new Platform(new Vector(300 + 48 * 11, groundPoint - 24 * 10), new Size((288 - 16 * 11) * pixelScale, 8 * pixelScale));
                    Platform pThirteen = new Platform(new Vector(300 + 48 * 12, groundPoint - 24 * 11), new Size((288 - 16 * 12) * pixelScale, 8 * pixelScale));
                    Platform pFourteen = new Platform(new Vector(300 + 48 * 4, groundPoint - 24 * 17), new Size((288 - 16 * 12) * pixelScale, 8 * pixelScale));
                    Platform pFifteen = new Platform(new Vector(0, groundPoint - 24 * 14), new Size((288 - 16 * 12) * pixelScale, 8 * pixelScale));
                    platforms = new List<Platform>();
                    platforms.Add(first);
                    platforms.Add(pSecond);
                    platforms.Add(pThird);
                    platforms.Add(pFour);
                    platforms.Add(pFive);
                    platforms.Add(pSix);
                    platforms.Add(pSeven);
                    platforms.Add(pEight);
                    platforms.Add(pNine);
                    platforms.Add(pTen);
                    platforms.Add(pEleven);
                    platforms.Add(pTwelve);
                    platforms.Add(pThirteen);
                    platforms.Add(pFourteen);
                    platforms.Add(pFifteen);

                    //Wall wFirst = new Wall(new Vector(300 + 48 * 17, groundPoint - 24 * 10), new Size(16 * pixelScale, 288));
                    //walls = new List<Wall>();
                    //walls.Add(wFirst);

                    Enemy one = new Enemy(new Vector(300 + 48 * 13, groundPoint - 24 * 13), Resources.cruela_l, new Size(8 * GameManager.pixelScale, 16 * GameManager.pixelScale), 10, Direction.RIGHT);
                    Enemy two = new Enemy(new Vector(100, GameManager.groundPoint), Resources.cruela_l, new Size(8 * GameManager.pixelScale, 16 * GameManager.pixelScale), 10, Direction.RIGHT);
                    Enemy three = new Enemy(new Vector(300 + 48 * 6, groundPoint - 24 * 19), Resources.cruela_l, new Size(8 * GameManager.pixelScale, 16 * GameManager.pixelScale), 10, Direction.RIGHT);
                    Enemy four = new Enemy(new Vector(48, groundPoint - 24 * 16), Resources.cruela_l, new Size(8 * GameManager.pixelScale, 16 * GameManager.pixelScale), 10, Direction.RIGHT);
                    enemies = new List<Enemy>();
                    enemies.Add(one);
                    enemies.Add(two);
                    enemies.Add(three);
                    enemies.Add(four);
                    return new Level(Resources.level1bg,platforms,walls,enemies);
                case 1:
                    first = new Platform(new Vector(150, groundPoint - 48 * 3), new Size(16 * pixelScale, 16 * pixelScale));
                    pSecond = new Platform(new Vector(500, 192), new Size(16 * pixelScale, 16 * pixelScale));
                    pThird = new Platform(new Vector(300, groundPoint), new Size(16 * pixelScale, 16 * pixelScale));
                    pFour = new Platform(new Vector(0, groundPoint - 48 * 6), new Size(16 * pixelScale, 16 * pixelScale));
                    pFive = new Platform(new Vector(210, groundPoint - 48 * 8), new Size(16 * pixelScale, 16 * pixelScale));
                    pSix = new Platform(new Vector(500 + 48, 192), new Size(16 * 12 * pixelScale, 16 * pixelScale));
                    pSeven = new Platform(new Vector(500 + 2 * 48, 192 + 3 * 48), new Size(16 * 14 * pixelScale, 16 * pixelScale));
                    platforms = new List<Platform>();
                    platforms.Add(first);
                    platforms.Add(pSecond);
                    platforms.Add(pThird);
                    platforms.Add(pFour);
                    platforms.Add(pFive);
                    platforms.Add(pSix);
                    platforms.Add(pSeven);

                    Wall wFirst = new Wall(new Vector(500, 192 + unit), new Size(16 * pixelScale, 386));
                    //Wall wSecond = new Wall(new Vector(1200, 0), new Size(16 * pixelScale, 384));
                    walls = new List<Wall>();
                    walls.Add(wFirst);
                    //walls.Add(wSecond);

                    //one = new Enemy(new Vector(200, GameManager.groundPoint), Resources.cruela_l, new Size(8 * GameManager.pixelScale, 16 * GameManager.pixelScale), 10, Direction.LEFT);
                    two = new Enemy(new Vector(900, GameManager.groundPoint), Resources.cruela_l, new Size(8 * GameManager.pixelScale, 16 * GameManager.pixelScale), 10, Direction.LEFT);
                    
                    enemies = new List<Enemy>();
                    //enemies.Add(one);
                    enemies.Add(two);
                    return new Level(Resources.level1bg, platforms, walls, enemies);
                default:
                    return null;
            }
        }
    }
}
