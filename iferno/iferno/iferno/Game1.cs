using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace iferno
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Screen aktuellerScreen;
        Screen start;
        Screen level;
        Screen menu;
        Screen gameover;
        Screen intro;
        Screen karte;
        Screen ende;


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
           
        }

        protected override void Initialize()
        {
            Settings.game = this;
            //Initialize game
            graphics.PreferredBackBufferWidth = Settings.Width;
            graphics.PreferredBackBufferHeight = Settings.Height;
            graphics.ApplyChanges();

            spriteBatch = new SpriteBatch(GraphicsDevice);

            this.start = new StartScreen(this, spriteBatch);
            this.level = new LevelScreen(this, spriteBatch);
            this.menu = new MenuScreen(this, spriteBatch);
            this.karte = new KarteScreen(this, spriteBatch);
            this.gameover= new GameoverScreen(this, spriteBatch);
            this.intro = new IntroScreen(this, spriteBatch);
            this.ende = new EndScreen(this, spriteBatch);

            this.switchScreen("start");

            base.Initialize();
        }

        //auswahl welches screen angezeigt wird.
        public void switchScreen(string screen)
        {
            switch (screen)
            {
                case "start":
                    aktuellerScreen = start;
                    break;
                case "level":
                    aktuellerScreen = level;
                    break;
                case "menu":
                    aktuellerScreen = menu;
                    break;
                case "gameover":
                    aktuellerScreen = gameover;
                    break;
                case "intro":
                    aktuellerScreen = intro;
                    break;
                 case "karte":
                    aktuellerScreen = karte;
                    break;
                 case "ende":
                    aktuellerScreen = ende;
                    break;
                default:
                    aktuellerScreen = start;
                    break;
            }
            aktuellerScreen.activate();
        }

        protected override void LoadContent()
        {
            start.LoadContent();
            level.LoadContent();
            menu.LoadContent();
            gameover.LoadContent();
            intro.LoadContent();
            karte.LoadContent();
            ende.LoadContent();
        }

        protected override void Update(GameTime gameTime)
        {
            aktuellerScreen.Update(gameTime);
            base.Update(gameTime);         
        }

        protected override void Draw(GameTime gameTime)
        {
            //Clear background
            GraphicsDevice.Clear(Color.White);

            //Draw world
            spriteBatch.Begin();

            aktuellerScreen.Draw(gameTime);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
