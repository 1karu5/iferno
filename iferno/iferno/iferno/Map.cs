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

        private float mapPosition = 0.0f;
        

        public Map(Screen screen)
        {
            this.screen = screen;
            Settings.mapNumber = -1;
            this.LoadContent();
            this.loadMap(0);
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

        public void loadMap(int number)
        {
            mapPosition = 0;
            Settings.mapNumber=number;
            this.blocks = new MapLoader().Load(this,"level" + number + ".txt");
        }

        public virtual void LoadContent()
        {
            Settings.Textures.Add("blockgruen", screen.Content.Load<Texture2D>("block/blockgruen"));

            Settings.Textures.Add("waterdrop", screen.Content.Load<Texture2D>("block/waterdrop"));

            Settings.Textures.Add("blattSprite", screen.Content.Load<Texture2D>("block/blattSprite"));
            Settings.Textures.Add("ventilatorSprite", screen.Content.Load<Texture2D>("block/ventilatorSprite"));
            Settings.Textures.Add("block-white", screen.Content.Load<Texture2D>("block/block-white"));
            Settings.Textures.Add("block-transparent", screen.Content.Load<Texture2D>("block/block-transparent"));
            Settings.Textures.Add("block-black", screen.Content.Load<Texture2D>("block/block-black"));
            Settings.Textures.Add("block-feuer", screen.Content.Load<Texture2D>("block/block-feuer"));
            Settings.Textures.Add("block-wasser", screen.Content.Load<Texture2D>("block/block-wasser"));
            Settings.Textures.Add("block-holz-baum", screen.Content.Load<Texture2D>("block/block-holz-baum"));
            Settings.Textures.Add("block-sand", screen.Content.Load<Texture2D>("block/block-sand"));
            Settings.Textures.Add("block-holz-kiste", screen.Content.Load<Texture2D>("block/block-holz-kiste"));
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

        public float getMapPosition(){
            return mapPosition;
        }

        public void move(float px)
        {
            mapPosition += px;
            foreach (Block b in blocks)
            {
                b.move(px);
            }  
        }

        public void Update(float dt)
        {
            foreach (Block e in getVisibleBlocks())
            {
                e.Update(dt);
            }

            for (int i = blocks.Count-1; i >= 0; i--)
            {
                if (blocks[i].isDestroying)
                    blocks.RemoveAt(i);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Block b in getVisibleBlocks())
            {
                b.Draw(spriteBatch);
            }
        }
    }
}
