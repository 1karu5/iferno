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
        StartScreen screenStart;

        Screen aktuellerScreen;
        Screen start;
        Screen level;
        //Screen menu;
        //Screen gameover
        //Screen intro


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            //Initialize game
            graphics.PreferredBackBufferWidth = Settings.Width;
            graphics.PreferredBackBufferHeight = Settings.Height;
            graphics.ApplyChanges();

            spriteBatch = new SpriteBatch(GraphicsDevice);

            this.start = new StartScreen(this, spriteBatch);
            this.level = new LevelScreen(this, spriteBatch);
            //this.gameover= new GameoverScreen(this, spriteBatch);
            //this.menu = new MenuScreen(this, spriteBatch);
            //this.intro = new IntroScreen(this, spriteBatch);

            this.switchScreen("level");

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
                /*
                case "menu":
                    aktuellerScreen = menu;
                    break;
                case "gameover":
                    aktuellerScreen = gameover;
                    break;
                case "intro":
                    aktuellerScreen = intro;
                    break;
                 */
                default:
                    aktuellerScreen = level;
                    break;
            }
        }

        protected override void LoadContent()
        {
            aktuellerScreen.LoadContent();  
        }

        protected override void Update(GameTime gameTime)
        {
            aktuellerScreen.Update(gameTime);
            base.Update(gameTime);         
        }

        protected override void Draw(GameTime gameTime)
        {
            //Clear background
            GraphicsDevice.Clear(Color.Cyan);

            //Draw world
            spriteBatch.Begin();

            aktuellerScreen.Draw(gameTime);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
