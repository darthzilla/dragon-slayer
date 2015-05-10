using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dragon_slayer.Properties;
using System.Drawing.Drawing2D;

namespace dragon_slayer
{
    public class Hero : Character
    {
        public Rectangle weapon { get; set; }
        public bool attackState { get; set; }
        public Vector gravity { get; set; }
        public Vector jump { get; set; }
        public bool isJumping { get; set; }
        public bool isMoving { get; set; }
        public bool isGrounded { get; set; }
        public bool isMovingLeft { get; set; }
        public bool isMovingRight { get; set; }
        public bool isPlatformed { get; set; }
        public string animState { get; set; }
        public int currentFrame { get; set; }
        public Hero(Vector location, Image sprite, Size bounds, int health,Direction direction) : base(location,sprite,bounds,health,direction) 
        {
            weapon = WeaponUpdate(direction);
            attackState = false;
            gravity = new Vector(0f, 9.81f);
            jump = new Vector(0f, 50f);
            isJumping = false;
            isMoving = false;
            isGrounded = false;
            isPlatformed = false;
            animState = "idle";
            currentFrame = 0;
        }
        //-------------------------------
        //| DRAW METHOD
        //-------------------------------
        public override void Draw(Graphics g)
        {
            g.InterpolationMode = InterpolationMode.NearestNeighbor;
            g.DrawImage(sprite,location.X,location.Y,16*GameManager.pixelScale,16*GameManager.pixelScale);
            //g.DrawRectangle(new Pen(Color.Yellow), new Rectangle((int)location.X + 4*GameManager.pixelScale,(int)location.Y, bounds.Width,bounds.Height));
            //if(attackState)
            //    g.DrawRectangle(new Pen(Color.Red), weapon);
            //else g.DrawRectangle(new Pen(Color.Blue), weapon);
        }
        //-------------------------------
        //| MOVE METHOD
        //-------------------------------
        public override void Move()
        {
            speed = 150;
            if (direction == Direction.RIGHT && isMoving)
            {
                float newLoc = location.X + speed * GameManager.pixelScale * 0.016f;
                location = new Vector(newLoc, location.Y);
                weapon = WeaponUpdate(direction);
            }
            else if (direction == Direction.LEFT && isMoving)
            {
                float newLoc = location.X - speed * GameManager.pixelScale * 0.016f;
                location = new Vector(newLoc, location.Y);
                weapon = WeaponUpdate(direction);
            }
        }
        //-------------------------------
        //| JUMP METHOD
        //-------------------------------
        public void Jump()
        {
            if (isJumping)
            {
                float newLoc = location.Y - jump.Y * 0.32f;
                location = new Vector(location.X, newLoc);
                jump = new Vector(jump.X, jump.Y - 0.32f * gravity.Y);
                isGrounded = false;
                isPlatformed = false;
                weapon = WeaponUpdate(direction);
            }

        }
        //-------------------------------
        //| GRAVITY METHOD
        //-------------------------------
        public void Gravity()
        {
            if (!isGrounded && !isJumping)
            {
                float newLoc = location.Y + 6 * gravity.Y * 0.32f;
                location = new Vector(location.X, newLoc);
                weapon = WeaponUpdate(direction);
            }
        }
        //-------------------------------
        //| WEAPON COLLIDER UPDATE METHOD
        //-------------------------------
        public Rectangle WeaponUpdate(Direction direction){
            if(direction == Direction.RIGHT)
                return new Rectangle((int)location.X + 11 * GameManager.pixelScale, (int)location.Y + 6 * GameManager.pixelScale, 7 * GameManager.pixelScale, 5 * GameManager.pixelScale);
            else return new Rectangle((int)location.X - 8 * GameManager.pixelScale, (int)location.Y + 6 * GameManager.pixelScale, 7 * GameManager.pixelScale, 5 * GameManager.pixelScale);
        }
        //-------------------------------
        //| SPRITE UPDATE METHOD
        //-------------------------------
        public Image SpriteUpdate(Direction direction)
        {
            if (direction == Direction.RIGHT)
            {
                return Resources.marko_r;
            }
            else return Resources.marko_l;
        }
        //-------------------------------
        //| ANIMATE METHOD
        //-------------------------------
        public void UpdateAnimState()
        {
            if (isMoving)
            {
                animState = "moving";
            }
            else animState = "idle";
            if (attackState)
            {
                animState = "attack";
            }
        }
        public void Animate()
        {
            if (animState.Equals("idle"))
            {
                currentFrame = 0;
                sprite = SpriteUpdate(direction);
            }
            else if (animState.Equals("moving"))
            {
                if (currentFrame > 3)
                    currentFrame = 0;
                else currentFrame++;
                if (direction == Direction.RIGHT)
                {
                    switch (currentFrame)
                    {
                        case 0:
                            sprite = Resources.marko_run_r0;
                            break;
                        case 1:
                            sprite = Resources.marko_run_r1;
                            break;
                        case 2:
                            sprite = Resources.marko_run_r2;
                            break;
                        case 3:
                            sprite = Resources.marko_run_r3;
                            break;
                        default:
                            sprite = Resources.marko_run_r0;
                            break;
                    }
                }
                else
                {
                    switch (currentFrame)
                    {
                        case 0:
                            sprite = Resources.marko_run_l0;
                            break;
                        case 1:
                            sprite = Resources.marko_run_l1;
                            break;
                        case 2:
                            sprite = Resources.marko_run_l2;
                            break;
                        case 3:
                            sprite = Resources.marko_run_l3;
                            break;
                        default:
                            sprite = Resources.marko_run_l0;
                            break;
                    }
                }
            }
            else if(animState.Equals("attack"))
            {
                if (currentFrame > 7)
                    currentFrame = 0;
                else currentFrame++;
                if(direction == Direction.RIGHT)
                    switch (currentFrame)
                    {
                        case 0:
                            sprite = Resources.marko_attack_r0;
                            break;
                        case 1:
                            sprite = Resources.marko_attack_r1;
                            break;
                        case 2:
                            sprite = Resources.marko_attack_r2;
                            break;
                        case 3:
                            sprite = Resources.marko_attack_r3;
                            break;
                        case 4:
                            sprite = Resources.marko_attack_r4;
                            break;
                        case 5:
                            sprite = Resources.marko_attack_r5;
                            break;
                        case 6:
                            sprite = Resources.marko_attack_r6;
                            break;
                        case 7:
                            sprite = Resources.marko_attack_r7;
                            break;
                        default:
                            sprite = Resources.marko_attack_r0;
                            break;
                    }
                else switch (currentFrame)
                    {
                        case 0:
                            sprite = Resources.marko_attack_l0;
                            break;
                        case 1:
                            sprite = Resources.marko_attack_l1;
                            break;
                        case 2:
                            sprite = Resources.marko_attack_l2;
                            break;
                        case 3:
                            sprite = Resources.marko_attack_l3;
                            break;
                        case 4:
                            sprite = Resources.marko_attack_l4;
                            break;
                        case 5:
                            sprite = Resources.marko_attack_l5;
                            break;
                        case 6:
                            sprite = Resources.marko_attack_l6;
                            break;
                        case 7:
                            sprite = Resources.marko_attack_l7;
                            break;
                        default:
                            sprite = Resources.marko_attack_l0;
                            break;
                    }
            }
        }
        //-------------------------------
        //| GROUND CHECK
        //-------------------------------
        public void GroundCheck()
        {
            if (!isGrounded && location.Y >= GameManager.groundPoint)
            {
                location.Y = GameManager.groundPoint;
                isJumping = false;
                isGrounded = true;
                jump = new Vector(0f, 50f);
            }
        }
        //-------------------------------
        //| MOVE UPDATE
        //-------------------------------
        public void ToMoveOrNotToMove()
        {
            if (!isMovingLeft && !isMovingRight)
            {
                isMoving = false;
            }
            else isMoving = true;
        }
        
        //-------------------------------
        //| PLATFORM COLLISION CHECK
        //-------------------------------
        public void PlatformCheck(List<Platform> colPlt)
        {
            if (colPlt.Count > 0)
            {
                foreach (Platform p in colPlt)
                {
                    if (location.X < p.location.X + p.bounds.Width &&
                           location.X + bounds.Width + 8 > p.location.X &&
                           location.Y + 47 < p.location.Y + 47 &&
                           bounds.Height + location.Y > p.location.Y)
                    {
                        isPlatformed = true;
                        p.isOnThis = true;
                        isGrounded = true;
                        isJumping = false;
                        jump = new Vector(0, 50f);
                        location.Y = p.location.Y - 47;
                        weapon = WeaponUpdate(direction);
                        
                    }
                    else if (isPlatformed && p.isOnThis)
                    {
                        isPlatformed = false;
                        isGrounded = false;
                        p.isOnThis = false;
                    }
                }
            }
        }
        //-------------------------------
        //| ENEMY COLLISION CHECK
        //-------------------------------
        public bool EnemyCheck(List<Enemy> colDec)
        {
            if(colDec.Count > 0)
                foreach(Enemy fiend in colDec){
                    if(attackState)
                        if (direction == Direction.RIGHT)
                        {
                            if (weapon.X < fiend.location.X + fiend.bounds.Width &&
                               weapon.X + weapon.Width > fiend.location.X &&
                               weapon.Y < fiend.location.Y + fiend.bounds.Height &&
                               weapon.Height + weapon.Y > fiend.location.Y)
                            {
                                //weapon collision
                                fiend.isAlive = false;
                            }
                        }
                        else if (direction == Direction.LEFT)
                        {
                            if (fiend.location.X < weapon.X + weapon.Width &&
                              fiend.location.X + fiend.bounds.Width > weapon.X &&
                               weapon.Y < fiend.location.Y + fiend.bounds.Height &&
                               weapon.Height + weapon.Y > fiend.location.Y)
                            {
                                //weapon collision
                                fiend.isAlive = false;
                            }
                        }
                    if (location.X < fiend.location.X + fiend.bounds.Width &&
                       location.X + bounds.Width > fiend.location.X &&
                       location.Y < fiend.location.Y + fiend.bounds.Height &&
                       bounds.Height + location.Y > fiend.location.Y)
                    {
                        //hero bounds collision
                        if(fiend.isAlive)
                            return true;
                    }
                }
            return false;
        }
        //-------------------------------
        //| WALL COLLISION CHECK
        //-------------------------------
        public void WallCheck(List<Wall> colWall){
            if (colWall.Count > 0)
            {
                foreach (Wall w in colWall)
                {
                    if (location.X + 46 >= w.location.X &&
                        location.X + 46 <= w.location.X + 16 &&
                        bounds.Height + location.Y > w.location.Y)
                    {
                        location.X = w.location.X - 46;
                        speed = 0;
                    }
                    else if (location.X >= w.location.X + w.bounds.Width - 8 &&
                             location.X <= w.location.X + w.bounds.Width &&
                             bounds.Height + location.Y > w.location.Y)
                    {
                        location.X = w.location.X + w.bounds.Width + 1;
                        speed = 0;
                    }
                }
            }
        }
        //-------------------------------
        //| KEEP IN BOUNDS
        //-------------------------------
        public void KeepInBounds()
        {
            if (location.X <= 0)
            {
                location.X = 1;
                speed = 0;
            }
            else if (location.X >= 1202)
            {
                location.X = 1200;
                speed = 0;
            }
        }
    }
}
