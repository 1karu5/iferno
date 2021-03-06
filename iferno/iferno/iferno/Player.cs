﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

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

        UI ui;
        List<string> helpOnce = new List<string>();

        float oldDirection=0;

        public int textureWidth = 166;

        //cheat mode :D
        public bool immortal = false;


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
            this.ui = new UI();
            this.background = background;
        }

        public void reset()
        {
            position = new Vector2(Settings.playerStartX, Settings.playerStartY);
            
            changeHP(101);
        }

        //lebensanzeige berchnen
        public void changeHP(int hp)
        {
            if (!immortal)
            {
                if (hp < 0)
                {
                    dmg = true;
                    frameCounter = 0;
                    delay = 0.5f;
                    Settings.SoundEffects["dmg"].Play();
                }
                if (hp > 100)
                {
                    health = 100;
                }
                else
                {
                    if (health <= 100)
                        health += hp;
                    if (health > 100)
                    {
                        ui.changePointsTo(health - 100);
                        health = 100;
                    }
                    if (health <= 0)
                        Settings.game.switchScreen("gameover");
                }
                ui.changeHPTo(health);
            }
        }

        public void nextLevel()
        {
            if (Settings.mapNumber == 4)
            {
                Settings.game.switchScreen("ende");
            }
            else
            {
                Settings.game.switchScreen("karte");
                map.loadMap(Settings.mapNumber + 1);
            }
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
                if (e.CheckCollisionWith(me) && e.collideWithPlayer)
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
                //Settings.SoundEffects["jump"].Play();
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
                    e.OnCollisionWithPlayer(this);
                    if (e.collideWithPlayer)
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
            if (newY > 1000)
            {
                Settings.game.switchScreen("gameover");
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
                    e.OnCollisionWithPlayer(this);
                    if (e.collideWithPlayer)
                    {
                        newX = X();   
                    }
                }
            }
            return newX;
        }

        //instruktion texte werden angezeigt
        public void updateHelpText()
        {
            float mapPosition = map.getMapPosition();

            if (!helpOnce.Contains("jumpLaufen") && mapPosition < 1 && Settings.mapNumber == 0)
            {
                helpOnce.Add("jumpLaufen");
                ui.addHelpText(-50, 0, Settings.Textures["jumpLaufen"], 3.0f);
            }
            if (!helpOnce.Contains("VorsichtWasser") && mapPosition < -2200 && Settings.mapNumber == 0)
            {
                helpOnce.Add("VorsichtWasser");
                ui.addHelpText(-50, 0, Settings.Textures["VorsichtWasser"], 3.0f);
            }
            if (!helpOnce.Contains("HolzIstBrennbar") && mapPosition < -4800 && Settings.mapNumber == 0)
            {
                helpOnce.Add("HolzIstBrennbar");
                ui.addHelpText(-50, 0, Settings.Textures["HolzIstBrennbar"], 3.0f);
            }
            if (!helpOnce.Contains("FeuerIstLeben") && mapPosition < -5500 && Settings.mapNumber == 0)
            {
                helpOnce.Add("FeuerIstLeben");
                ui.addHelpText(-50, 0, Settings.Textures["FeuerIstLeben"], 3.0f);
            }
            if (!helpOnce.Contains("VorsichtWind") && mapPosition < 0 && Settings.mapNumber == 2)
            {
                helpOnce.Add("VorsichtWind");
                ui.addHelpText(-50, 0, Settings.Textures["VorsichtWind"], 3.0f);
            }
            if (!helpOnce.Contains("VorsichtKabbe") && mapPosition < 0 && Settings.mapNumber == 3)
            {
                helpOnce.Add("VorsichtKabbe");
                ui.addHelpText(-50, 0, Settings.Textures["VorsichtKabbe"], 3.0f);
            }

            //easteregg
            if (!helpOnce.Contains("easteregg") && mapPosition > -5130 && mapPosition < -5000 && Y() ==-128 &&Settings.mapNumber == 4)
            {
                helpOnce.Add("easteregg");
                ui.addHelpText(0, 0, Settings.Textures["easteregg"], 5.0f);
            }
        }
       
        public override void Update(float dt)
        {
            base.Update(dt);

            if (Settings.debug)
            {
                ui.debug("fps: " + (1 / dt));
                ui.debug("map: " + Settings.mapNumber);
                ui.debug("mapXpos: " + map.getMapPosition());
                ui.debug("mapYpos: " + this.Y());
            }
            

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
                if (DirectionX >= 0)
                {
                    this.texture = Settings.Textures["ifernodmg"];
                }
                else
                {
                    this.texture = Settings.Textures["ifernodmgback"];
                }
                
                frames = 6;
                if (frameCounter == 5)
                {
                    dmg = false;
                    oldDirection = 5;
                    delay = 0.3f;
                }
            }

            updateHelpText();
            ui.Update(dt);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            ui.Draw(spriteBatch);
            spriteBatch.Draw(this.texture, position,
                    new Rectangle((int)(frameCounter * textureWidth), 0, (int)textureWidth, (int)Height()),
                    Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0.0f); //null->>>rotation,scale
        }
    }
}
