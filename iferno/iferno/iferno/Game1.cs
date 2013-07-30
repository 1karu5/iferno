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
        Screen level1;
        Screen menu;


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

            this.menu = new StartScreen(this, spriteBatch);
            this.level1 = new LevelScreen(this, spriteBatch);

            this.switchScreen("menu");

            base.Initialize();
        }

        public void switchScreen(string screen)
        {
            if (screen == "menu")
            {
                aktuellerScreen = menu;
            }else if(screen == "level1"){
                aktuellerScreen = level1;
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

<<<<<<< HEAD
            aktuellerScreen.Draw(gameTime);
=======
            player.Draw(spriteBatch);
            //player2.Draw(spriteBatch);

            foreach (Entity e in map)
            {
               e.Draw(spriteBatch);
            }
>>>>>>> 79cd36fedec266efd9b66204ae21e8e9b395073d

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
