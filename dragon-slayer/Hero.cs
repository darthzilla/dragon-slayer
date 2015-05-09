using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dragon_slayer.Properties;

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
        public bool isFalling { get; set; }
        public int plColNum { get; set; }
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
            plColNum = 0;
        }
        //-------------------------------
        //| DRAW METHOD
        //-------------------------------
        public override void Draw(Graphics g)
        {
            g.DrawImage(sprite,location.X,location.Y,16*GameManager.pixelScale,16*GameManager.pixelScale);
            g.DrawRectangle(new Pen(Color.Yellow), new Rectangle((int)location.X + 4*GameManager.pixelScale,(int)location.Y, bounds.Width,bounds.Height));
            if(attackState)
                g.DrawRectangle(new Pen(Color.Red), weapon);
            else g.DrawRectangle(new Pen(Color.Blue), weapon);
        }
        //-------------------------------
        //| MOVE METHOD
        //-------------------------------
        public override void Move()
        {
            if (direction == Direction.RIGHT && isMoving)
            {
                float newLoc = location.X + speed * GameManager.pixelScale * 0.016f;
                location = new Vector(newLoc, location.Y);
                weapon = WeaponUpdate(direction);
                sprite = SpriteUpdate(direction);
            }
            else if (direction == Direction.LEFT && isMoving)
            {
                float newLoc = location.X - speed * GameManager.pixelScale * 0.016f;
                location = new Vector(newLoc, location.Y);
                weapon = WeaponUpdate(direction);
                sprite = SpriteUpdate(direction);
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
                float newLoc = location.Y + 15 * 0.32f;
                location = new Vector(location.X, newLoc);
                weapon = WeaponUpdate(direction);
            }
        }
        //-------------------------------
        //| WEAPON COLLIDER UPDATE METHOD
        //-------------------------------
        public Rectangle WeaponUpdate(Direction direction){
            if(direction == Direction.RIGHT)
                return new Rectangle((int)location.X + 11 * GameManager.pixelScale, (int)location.Y + 6 * GameManager.pixelScale, 10 * GameManager.pixelScale, 5 * GameManager.pixelScale);
            else return new Rectangle((int)location.X - 5 * GameManager.pixelScale, (int)location.Y + 6 * GameManager.pixelScale, 10 * GameManager.pixelScale, 5 * GameManager.pixelScale);
        }
        //-------------------------------
        //| SPRITE UPDATE METHOD
        //-------------------------------
        public Image SpriteUpdate(Direction direction)
        {
            if (direction == Direction.RIGHT)
            {
                return Resources.marko;
            }
            else return Resources.marko_left;
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
                           location.X + bounds.Width > p.location.X &&
                           location.Y + 47 < p.location.Y + 47 &&
                           bounds.Height + location.Y > p.location.Y)
                    {
                        plColNum++;
                        isPlatformed = true;
                        isGrounded = true;
                        isJumping = false;
                        jump = new Vector(0, 50f);
                        location.Y = p.location.Y - 47;
                        weapon = WeaponUpdate(direction);
                        
                    }
                    else if (isPlatformed)
                    {
                        isPlatformed = false;
                        isGrounded = false;
                        plColNum = 0;
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
                        if (weapon.X < fiend.location.X + fiend.bounds.Width &&
                           weapon.X + weapon.Width > fiend.location.X &&
                           weapon.Y < fiend.location.Y + fiend.bounds.Height &&
                           weapon.Height + weapon.Y > fiend.location.Y)
                        {
                            //weapon collision
                            fiend.isAlive = false;
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
    }
}
