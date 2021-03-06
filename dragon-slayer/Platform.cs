﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dragon_slayer
{
    public class Platform
    {
        public Vector location { get; set; }
        public Size bounds { get; set; }
        public Rectangle box {get; set;}
        public bool isOnThis { get; set; }
        public Platform(Vector location, Size bounds)
        {
            this.location = location;
            this.bounds = bounds;
            box = new Rectangle((int)location.X, (int)location.Y, bounds.Width, bounds.Height);
            isOnThis = false;
        }
        public void Draw(Graphics g)
        {
            g.FillRectangle(new SolidBrush(Color.Green), box);
        }
    }
}
