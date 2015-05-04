﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dragon_slayer.Properties;

namespace dragon_slayer
{
    public class GameManager
    {
        public static int pixelScale = 3;

        Level level1;

        Brush brush;
        public GameManager()
        {
            level1 = new Level(Resources.level1bg);
            brush = new SolidBrush(Color.Red);
        }
        public void Update()
        {
            
        }
        public void Draw(Graphics g)
        {
            level1.Draw(g);
        }
    }
}