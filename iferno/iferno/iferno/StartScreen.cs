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
        Texture2D gameStartText;
        Texture2D gameExitText;

        int indexPos = 0;

        public StartScreen(Game1 game, SpriteBatch spriteBatch) : base(game, spriteBatch)
        {

        }

        public override void LoadContent()
        {
             Settings.Textures.Add("textGameStarten", Content.Load<Texture2D>("textGameStarten"));
             Settings.Textures.Add("textGameBeenden", Content.Load<Texture2D>("textGameBeenden"));
        }

        public override void Update(GameTime gameTime)
        {
            KeyboardState menuState = Keyboard.GetState();

            if (menuState.IsKeyDown(Keys.Up) && indexPos > 0)
            {
                indexPos--;
            }else if(menuState.IsKeyDown(Keys.Down) && indexPos < 0)
            {
                indexPos++;
            }
            else if (menuState.IsKeyDown(Keys.Space))
            {
                if (indexPos == 0)
                {
                    game.switchScreen("level");
                }

                else if (indexPos == 1)
                    game.Exit();
            }
            else if (menuState.IsKeyDown(Keys.Escape))
            {
                game.Exit();
            }

        }

        public override void Draw(GameTime gameTime)
        {
            //Spiel im Hintergrund verdunkeln
            //spriteBatch.Draw(Const.TEX_EMPTY, Const.SCREEN_RECTANGLE, new Color(0, 0, 0, 0.75f));

            //New Game
           spriteBatch.Draw(Settings.Textures["textGameStarten"], new Vector2(50, 130), indexPos == 0 ? Color.White : Color.DimGray);
            //Exit
           spriteBatch.Draw(Settings.Textures["textGameBeenden"], new Vector2(50, 200), indexPos == 1 ? Color.White : Color.DimGray);
        }
    }
}

