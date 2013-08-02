using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace iferno
{
    public class UI
    {
        public HealthBar healthbar;
        public List<HelpText> texts;
        public Console console;

        public UI()
        {
            healthbar = new HealthBar(10,210);
            texts = new List<HelpText>();
            console = new Console(800,0);
        }

        public void debug(string s)
        {
            console.write(s);
        }

        public void addHelpText(float x,float y,Texture2D t,float time){
            texts.Add(new HelpText(x,y,t,time));
        }

        public void changeHPTo(int hp)
        {
            healthbar.changeTo(hp);    
        }

        public void Update(float dt)
        {
            healthbar.Update(dt);
            console.Update(dt);
            foreach (HelpText t in texts)
            {
                t.Update(dt);
            }
            for (int i = texts.Count - 1; i >= 0; i--)
            {
                if (texts[i].isDestroying)
                    texts.RemoveAt(i);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            
            console.Draw(spriteBatch);
            foreach (HelpText t in texts)
            {
                t.Draw(spriteBatch);
            }
            healthbar.Draw(spriteBatch);
        }
    }
}
