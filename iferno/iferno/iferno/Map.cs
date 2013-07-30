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
    public class Map
    {
        public List<Block> blocks;
        public int firstVisibleBlock;
        public int width;
        public int height;
        public int visibleWidth;
        public int visibleHeight;
        public Screen screen;

        public Map(Screen screen)
        {
            this.screen = screen;
            this.LoadContent();
            this.blocks = this.createMap();
            this.firstVisibleBlock = 0;
            this.width = 100;
            this.height = 12;

            this.visibleWidth = 16;
            this.visibleHeight = 12;
        }

        /**
         *  fenster höhe: 12
         *  fenster breite: 16
         * 
         **/

        public virtual List<Block> createMap(){
            List<Block> newMap = new List<Block>();

            for (int i = 0; i < 100; i++)
            {
                newMap.Add(new Block(this,i, 11, Color.White, Settings.Textures["blockgruen"]));
            }
            
            return newMap;
        }

        public virtual void LoadContent()
        {
            Settings.Textures.Add("blockgruen", screen.Content.Load<Texture2D>("blockgruen"));
        }

        public List<Block> getVisibleBlocks()
        {
            List<Block> visibleBlocks = new List<Block>();
            foreach (Block b in blocks)
            {
                if (b.isVisible())
                {
                    visibleBlocks.Add(b);
                }
            }
            return visibleBlocks;
        }

        public void move(float px)
        {
            foreach (Block b in blocks)
            {
                b.move(px);
            }  
        }

        public void Update(float dt)
        {
            foreach (Block b in blocks)
            {
                b.Update(dt);
            }   
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Block b in blocks)
            {
                b.Draw(spriteBatch);
            }
        }
    }
}
