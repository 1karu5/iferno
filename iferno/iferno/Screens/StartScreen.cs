using System;
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
    class StartScreen : Screen
    {
        int indexPos = 0;
        KeyboardState oldKeyboardState = Keyboard.GetState();
        

        public StartScreen(Game1 game, SpriteBatch spriteBatch) : base(game, spriteBatch)
        {

        }

        public override void activate()
        {
            oldKeyboardState = Keyboard.GetState();
        }

        public override void LoadContent()
        {
             Settings.Textures.Add("textGameStarten", Content.Load<Texture2D>("text/textGameStarten"));
             Settings.Textures.Add("textGameBeenden", Content.Load<Texture2D>("text/textGameBeenden"));
             Settings.Textures.Add("textGameStarten2", Content.Load<Texture2D>("text/textGameStart2"));
             Settings.Textures.Add("textGameBeenden2", Content.Load<Texture2D>("text/textGameBeenden2"));
             Settings.Textures.Add("startscreen", Content.Load<Texture2D>("startbildschirm"));
            
        }

        public override void Update(GameTime gameTime)
        {

            KeyboardState menuState = Keyboard.GetState();
            if (menuState.IsKeyDown(Keys.Left) && oldKeyboardState.IsKeyUp(Keys.Left) && indexPos == 1)
            {
                indexPos--;
            }
            else if (menuState.IsKeyDown(Keys.Right) && oldKeyboardState.IsKeyUp(Keys.Right) && indexPos == 0)
            {
                indexPos++;
            }
            else if (menuState.IsKeyDown(Keys.Enter) && oldKeyboardState.IsKeyUp(Keys.Enter) || menuState.IsKeyDown(Keys.Space) && oldKeyboardState.IsKeyDown(Keys.Space))
            {
                if (indexPos == 0)
                {
                    if (Settings.didhedied)
                    {
                        game.switchScreen("karte");
                    }
                    else{
                        game.switchScreen("intro");
                    }
                }

                else if (indexPos == 1)
                    game.Exit();
            }
            else if (menuState.IsKeyDown(Keys.Escape))
            {
                game.Exit();
            }

            oldKeyboardState = menuState;

        }

        public override void Draw(GameTime gameTime)
        {

            spriteBatch.Draw(Settings.Textures["startscreen"], new Vector2(0, 0), Color.White);

            //Spiel im Hintergrund verdunkeln
            //spriteBatch.Draw(Const.TEX_EMPTY, Const.SCREEN_RECTANGLE, new Color(0, 0, 0, 0.75f));
            if (indexPos == 0)
            {
                 spriteBatch.Draw(Settings.Textures["textGameStarten2"], new Vector2(550, 630), Color.White);
                 spriteBatch.Draw(Settings.Textures["textGameBeenden"], new Vector2(750, 630), Color.White);
            }
            if (indexPos == 1)
            {
                spriteBatch.Draw(Settings.Textures["textGameStarten"], new Vector2(550, 630), Color.White);
                spriteBatch.Draw(Settings.Textures["textGameBeenden2"], new Vector2(750, 630), Color.White);
            }

            
            /*
            //New Game
           spriteBatch.Draw(Settings.Textures["textGameStarten"], new Vector2(750, 550), indexPos == 0 ? Color.White : Color.DimGray);
            //Exit
           spriteBatch.Draw(Settings.Textures["textGameBeenden"], new Vector2(750, 650), indexPos == 1 ? Color.White : Color.DimGray);
             * */
        }
    }
}

