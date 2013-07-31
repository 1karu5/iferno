using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace iferno
{
    public class Player : Entity
    {
        public Map map;
        int frames = 8;
        float delay = 0.3f;
        int health = 100;
        bool dmg = false;

        int width;
        int frameCounter = 0;
        float time = 0;

        Background background;

        HealthBar healthbar;

        float oldDirection=0;

        public int textureWidth = 166;

        public float DirectionX { get; set; }
        public float DirectionY { get; set; }

        public Player(Color color,Map map, Background background)
            : base(Settings.playerStartX, Settings.playerStartY, color, Settings.Textures["ifernowait"])
        {
            Settings.player = this;
            this.DirectionY = 1;
            this.DirectionX = 0;
            this.map = map;
            this.width = this.texture.Width / frames;
            this.healthbar = new HealthBar(10,210);
            this.background = background;
        }

        public void reset()
        {
            position = new Vector2(Settings.playerStartX, Settings.playerStartY);
            changeHP(101);
        }

        public void changeHP(int hp)
        {
            if (hp < 0)
            {
                dmg = true;
                frameCounter = 0;
                delay = 0.5f;
            }
            if (health<=100)
                health += hp;
            if (health > 100)
                health = 100;
            healthbar.changeTo(health);
            //if (health <= 0)
                //Settings.game.switchScreen("gameover");
        }

        public void nextLevel()
        {
            Settings.game.switchScreen("karte");
            map.loadMap(Settings.mapNumber+1);
            background.loadMap();
        }

        public override float Width()
        {
            return 60;
        }

        public bool onGround()
        {
            Rectangle me = this.Collision();
            me.Y = me.Y + 1;    //eins runter, falls kollision sind wir auf dem boden
            foreach (Block e in map.getVisibleBlocks())
            {
                if (e.CheckCollisionWith(me))
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
                if (e.CheckCollisionWith(me)) //neue koordinate ist nicht richtig, kollision mit e!
                {
                    if (e.OnCollisionWithPlayer(this))
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
            }
            return newY;    //neue Y koordinate
        }

        public override float X()
        {
            return this.position.X + 53;
        }

        //Todo: beine
        public override Rectangle Collision()
        {
            return new Rectangle((int)(this.X()), (int)this.Y(), (int)(width-53-53/*-linkerBeinAnfang-Beinabstand*/), (int)this.Height());
        }

        private float moveX(float dt)
        {
            float newX = this.X() + (this.DirectionX * Settings.PlayerSpeed * dt);

            Rectangle me = this.Collision();
            me.X = (int)newX; //kollision mit neuer koordinate

            foreach (Block e in map.getVisibleBlocks())
            {
                if (e.CheckCollisionWith(me))  //neue koordinate ist nicht richtig, kollision mit e!
                {
                    if (e.OnCollisionWithPlayer(this))
                    {
                        newX = X();   
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
            //Nach Links oder Rechts
            //Je nach textur andere frames setzten
            if (!dmg && oldDirection != DirectionX && DirectionX < 0)
            {
                this.texture = Settings.Textures["ifernoback"];
                frames = 4;
                frameCounter = 0;
            }
            else if (!dmg && oldDirection != DirectionX && DirectionX > 0)
            {
                this.texture = Settings.Textures["iferno"];
                frames = 4;
                frameCounter = 0;
            }
            else if (!dmg && oldDirection != DirectionX && DirectionX == 0)
            {
                this.texture = Settings.Textures["ifernowait"];
                frames = 8;
                frameCounter = 0;
            }
            this.map.move(this.X() - newX);
            this.background.move(this.X() - newX);

            oldDirection=DirectionX;

            if (dmg)
            {
                if (DirectionX > 0)
                {
                    this.texture = Settings.Textures["ifernodmg"];
                }
                else
                {
                    this.texture = Settings.Textures["ifernodmgback"];
                }
                
                frames = 5;
                if (frameCounter == 4)
                {
                    dmg = false;
                    oldDirection = 5;
                    delay = 0.3f;
                }
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            healthbar.Draw(spriteBatch);
            spriteBatch.Draw(this.texture, position,
                    new Rectangle((int)(frameCounter * textureWidth), 0, (int)textureWidth, (int)Height()),
                    Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0.0f); //null->>>rotation,scale
        }
    }
}
