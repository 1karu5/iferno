using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace iferno
{
    public class Player : Entity
    {
        public List<Entity> map;

        public float DirectionX { get; set; }
        public float DirectionY { get; set; }

        public Player(float x, float y, Color color,List<Entity> map)
            : base(x, y, color, Settings.Textures["blockrot"])
        {
            this.DirectionY = 1;
            this.DirectionX = 0;
            this.map = map;
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
            return false;
        }

        public void jump()
        {
            if (this.onGround())
            {
                DirectionY = -Settings.PlayerMaxYDirection;
            }
        }

        private float moveY(float dt)
        {
            float newY = this.Y() + (this.DirectionY * Settings.PlayerFallSpeed * dt);
            Rectangle me = this.Collision();
            me.Y = (int)newY;   //kollision mit neuer koordinate

            foreach (Entity e in map)
            {
                Rectangle r = Rectangle.Intersect(e.Collision(), me);
                if (!r.IsEmpty) //neue koordinate ist nicht richtig, kollision mit e!
                {
                    if (this.DirectionY > 0)//runter fallen
                    {   //genau auf den block stellen
                        newY = e.Y() - this.Height();
                    }
                    else//hoch springen
                    {   //genau unten an den block stoßen
                        newY = e.Y() + e.Height();
                    }          
                }
            }
            return newY;    //neue Y koordinate
        }

        private float moveX(float dt)
        {
            float newX = this.X() + (this.DirectionX * Settings.PlayerSpeed * dt);

            Rectangle me = this.Collision();
            me.X = (int)newX; //kollision mit neuer koordinate

            foreach (Entity e in map)
            {
                Rectangle r = Rectangle.Intersect(e.Collision(), me);
                if (!r.IsEmpty)  //neue koordinate ist nicht richtig, kollision mit e!
                {
                    if (this.DirectionX > 0)//rechts angestoßen
                    {
                        newX = e.X() - this.Width();
                    }
                    else//links angestoßen
                    {
                        newX = e.X() + e.Width();
                    }
                }
            }
            return newX;
        }

        public void Update(float dt)
        {
            base.Update(dt);

            if (this.DirectionY < Settings.PlayerMaxYDirection) //fall/sprung geschwindigkeit immer erhören/verringen
            {   //todo, auf 1 rücksetzen falls man auf dem boden steht
                this.DirectionY += Settings.PlayerFallSpeedAddition;
            }

            this.position.Y = this.moveY(dt);
            this.position.X = this.moveX(dt);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}
