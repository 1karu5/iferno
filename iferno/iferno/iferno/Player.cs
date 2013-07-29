using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace iferno
{
    public class Player : Entity
    {
        public List<Entity> map;
        public int jumptimer;
        public Boolean falling;

        public float DirectionX { get; set; }
        public float DirectionY { get; set; }

        public Player(float x, float y, Color color,List<Entity> map)
            : base(x, y, color, Settings.Textures["blockrot"])
        {
            this.DirectionY = 1;
            this.DirectionX = 0;
            this.map = map;
            this.jumptimer = 0;
            this.falling = false;
        }

        public bool onGround()
        {
            Rectangle me = this.Collision();
            me.Y = me.Y + 1;    //eins runter, falls kollision sind wir auf dem boden
            foreach (Entity e in map)
            {
                Rectangle r = Rectangle.Intersect(e.Collision(), me);
                if (!r.IsEmpty)
                {
                    return true;
                }
            }
            this.falling = true;
            return false;
        }

        public void jump()
        {
            if (this.onGround())
            {
                jumptimer = Settings.PlayerJumpHeight;
                DirectionY = -2.0f;
            }
        }

        private float moveY(float dt)
        {
            float newY = this.position.Y + (this.DirectionY * Settings.PlayerFallSpeed * dt);
            Rectangle me = this.Collision();
            me.Y = (int)newY;
            this.falling = true;
            foreach (Entity e in map)
            {
                Rectangle r = Rectangle.Intersect(e.Collision(), me);
                if (!r.IsEmpty)
                {
                    if (this.DirectionY > 0)//runter fallen
                    {
                        newY = e.position.Y - this.texture.Height;
                        this.falling = false;
                    }
                    else//hoch springen
                    {
                        newY = e.position.Y + e.texture.Height;
                        this.falling = false;
                    }          
                }
            }
            return newY;
        }

        private float moveX(float dt)
        {
            float newX = this.position.X + (this.DirectionX * Settings.PlayerSpeed * dt);

            Rectangle me = this.Collision();
            me.X = (int)newX;

            foreach (Entity e in map)
            {
                Rectangle r = Rectangle.Intersect(e.Collision(), me);
                if (!r.IsEmpty)
                {
                    if (this.DirectionX > 0)//rechts angestoßen
                    {
                        newX = e.position.X - this.texture.Width;
                    }
                    else//links angestoßen
                    {
                        newX = e.position.X + e.texture.Width;
                    }
                }
            }
            return newX;
        }

        public void Update(float dt)
        {
            base.Update(dt);

            
            if (jumptimer == 0)
            {
                DirectionY = 1;
            }
            else
            {
                if (this.DirectionY < 0.0f)
                {
                    this.DirectionY +=2.0f / Settings.PlayerJumpHeight;
                }
                this.jumptimer--;
            }

            if (this.falling && this.DirectionY < 2.0f)
            {
                this.DirectionY += Settings.PlayerFallSpeedAddition;
            }

            this.position.Y = moveY(dt);
            this.position.X = moveX(dt);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}
