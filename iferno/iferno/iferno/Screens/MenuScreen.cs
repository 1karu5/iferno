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
    public class MenuScreen : Screen
    {
        int indexPos = 0;
        KeyboardState oldKeyboardState = Keyboard.GetState();
        public MenuScreen(Game1 game, SpriteBatch spriteBatch)
            : base(game, spriteBatch)
        {

        }

        public override void LoadContent()
        {
            Settings.Textures.Add("textGameSound", Content.Load<Texture2D>("text/textGameSound"));
            Settings.Textures.Add("textGameWeiter", Content.Load<Texture2D>("text/textGameWeiter"));
            Settings.Textures.Add("textGameSound2", Content.Load<Texture2D>("text/textGameSound2"));
            Settings.Textures.Add("textGameWeiter2", Content.Load<Texture2D>("text/textGameWeiter2"));
        }

        public override void activate()
        {
            oldKeyboardState = Keyboard.GetState();
        }

        public override void Update(GameTime gameTime)
        {
            KeyboardState menuState = Keyboard.GetState();

            if(menuState.IsKeyDown(Keys.Up) && oldKeyboardState.IsKeyUp(Keys.Up) && indexPos > 0)
            {
                indexPos--;
            }
            else if (menuState.IsKeyDown(Keys.Down) && oldKeyboardState.IsKeyUp(Keys.Down) && indexPos < 3)
            {
                indexPos++;
            }

            if (menuState.IsKeyDown(Keys.Enter) || menuState.IsKeyDown(Keys.Space))
            {
                switch (indexPos)
                { 
                    case 0:
                        game.switchScreen("level");
                        break;
                    case 1:
                        Settings.didhedied = true;
                        Settings.mapNumber = 0;
                        game.switchScreen("start");
                        break;
                    case 2:
                        game.Exit();
                        break;
                }
            }

            oldKeyboardState = menuState;

        }

        public override void Draw(GameTime gameTime)
        {
            //Weiter
            if (indexPos == 0)
            {
                spriteBatch.Draw(Settings.Textures["textGameWeiter2"], new Vector2(750, 100), Color.White);
                spriteBatch.Draw(Settings.Textures["textGameStarten"], new Vector2(750, 180), Color.White);
                spriteBatch.Draw(Settings.Textures["textGameBeenden"], new Vector2(750, 260), Color.White);
            }
            if (indexPos == 1)
            {
                spriteBatch.Draw(Settings.Textures["textGameWeiter"], new Vector2(750, 100), Color.White);
                spriteBatch.Draw(Settings.Textures["textGameStarten2"], new Vector2(750, 180), Color.White);
                spriteBatch.Draw(Settings.Textures["textGameBeenden"], new Vector2(750, 260), Color.White);
            }
            if (indexPos == 2)
            {
                spriteBatch.Draw(Settings.Textures["textGameWeiter"], new Vector2(750, 100), Color.White);
                spriteBatch.Draw(Settings.Textures["textGameStarten"], new Vector2(750, 180), Color.White);
                spriteBatch.Draw(Settings.Textures["textGameBeenden2"], new Vector2(750, 260), Color.White);
            }
            /*
            //Weiter
            spriteBatch.Draw(Settings.Textures["textGameWeiter"], new Vector2(750, 100), indexPos == 0 ? Color.White : Color.DimGray);
            //New Game
            spriteBatch.Draw(Settings.Textures["textGameStarten"], new Vector2(750, 200), indexPos == 1 ? Color.White : Color.DimGray);
            //Exit
            spriteBatch.Draw(Settings.Textures["textGameBeenden"], new Vector2(750, 300), indexPos == 2 ? Color.White : Color.DimGray);
             * */
        }
    }
}
