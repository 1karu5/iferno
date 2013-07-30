using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace iferno
{
    public class Player : Entity
    {
        public Map map;
        const int frames = 2;
        const float delay = 0.7f;
        int health = 100;

        int width;
        int frameCounter = 0;
        float time = 0;

        public float DirectionX { get; set; }
        public float DirectionY { get; set; }

        public Player(float x, float y, Color color,Map map)
            : base(x, y, color, Settings.Textures["iferno"])
        {
            this.DirectionY = 1;
            this.DirectionX = 0;
            this.map = map;
            this.width = this.texture.Width / frames;
        }

        public override void collisionWithPlayer(Player p)
        {
           
        }

        public void changeHP(int hp)
        {
            health += hp;
        }

        public void nextLevel()
        {
            Settings.game.switchScreen("karte");
            map.nextMap();
        }

        public override float Width()
        {
            return 128;
        }

        public bool onGround()
        {
            Rectangle me = this.Collision();
            me.Y = me.Y + 1;    //eins runter, falls kollision sind wir auf dem boden
            foreach (Block e in map.getVisibleBlocks())
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

            foreach (Block e in map.getVisibleBlocks())
            {
                Rectangle r = Rectangle.Intersect(e.Collision(), me);
                if (!r.IsEmpty) //neue koordinate ist nicht richtig, kollision mit e!
                {
                    e.collisionWithPlayer(this);
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

            foreach (Block e in map.getVisibleBlocks())
            {
                Rectangle r = Rectangle.Intersect(e.Collision(), me);
                if (!r.IsEmpty)  //neue koordinate ist nicht richtig, kollision mit e!
                {
                    e.collisionWithPlayer(this);
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

       
        public override void Update(float dt)
        {
            base.Update(dt);

            //Einzelne Frames abarbeiten
            time += dt;
            if (time > delay)
            {
                time -= delay;
                if (frameCounter < frames - 1)
                    frameCounter++;
                else
                    frameCounter = 0;
            }


            if (this.DirectionY < Settings.PlayerMaxYDirection) //fall/sprung geschwindigkeit immer erhören/verringen
            {   //todo, auf 1 rücksetzen falls man auf dem boden steht
                this.DirectionY += Settings.PlayerFallSpeedAddition;
            }

            this.position.Y = this.moveY(dt);
            float newX = this.moveX(dt);
            this.map.move(this.X() - newX);
            //this.position.X = newX;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.texture, position,
                    new Rectangle((int)(frameCounter * Width()), 0, (int)Width(), (int)Height()),
                    Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0.0f); //null->>>rotation,scale
        }
    }
}
