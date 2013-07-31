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
            Settings.Textures.Add("textGameSound", Content.Load<Texture2D>("textGameSound"));
            Settings.Textures.Add("textGameWeiter", Content.Load<Texture2D>("textGameWeiter"));
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

            if (menuState.IsKeyDown(Keys.Enter))
            {
                switch (indexPos)
                { 
                    case 0:
                        game.switchScreen("level");
                        break;
                    case 1:
                        game.switchScreen("level");
                        break;
                    case 2:
                        //Sound an und ausschalten
                        break;
                    case 3:
                        game.Exit();
                        break;
                }
            }

            oldKeyboardState = menuState;

        }

        public override void Draw(GameTime gameTime)
        {
            //Weiter
            spriteBatch.Draw(Settings.Textures["textGameWeiter"], new Vector2(750, 100), indexPos == 0 ? Color.White : Color.DimGray);
            //New Game
            spriteBatch.Draw(Settings.Textures["textGameStarten"], new Vector2(750, 200), indexPos == 1 ? Color.White : Color.DimGray);
            //Sound
            spriteBatch.Draw(Settings.Textures["textGameSound"], new Vector2(750, 300), indexPos == 2 ? Color.White : Color.DimGray);
            //Exit
            spriteBatch.Draw(Settings.Textures["textGameBeenden"], new Vector2(750, 400), indexPos == 3 ? Color.White : Color.DimGray);
        }
    }
}
