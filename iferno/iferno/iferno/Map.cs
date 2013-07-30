using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace iferno
{
    public class Map
    {

        public List<Block> blocks;
        
        public Map()
        {
            this.blocks = this.createMap();
        }

        /**
         *  fenster höhe: 12
         *  fenster breite: 16
         * 
         **/

        public List<Block> createMap(){
            List<Block> newMap = new List<Block>();

            for (int i = 0; i < 50; i++)
            {
                newMap.Add(new Block(this,i, 11, Color.White, Settings.Textures["blockgruen"]));
            }
            newMap.Add(new Block(this, 5, 10, Color.White, Settings.Textures["blockgruen"]));
            return newMap;
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

        public void Update(float dt)
        {
            foreach (Entity b in blocks)
            {
                b.Update(dt);
            }   
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Entity b in blocks)
            {
                b.Draw(spriteBatch);
            }
        }
    }
}
