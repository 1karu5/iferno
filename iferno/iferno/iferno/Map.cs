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
        public int mapNumber;

        public Map(Screen screen)
        {
            this.screen = screen;
            this.LoadContent();
            this.mapNumber = -1;
            this.nextMap();
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

        public void nextMap()
        {
            this.mapNumber++;
            this.blocks = new MapLoader().Load(this,"C:\\Users\\gamer\\Documents\\GitHub\\iferno\\iferno\\iferno\\ifernoContent\\level" + this.mapNumber + ".txt");
        }

        public virtual void LoadContent()
        {
            Settings.Textures.Add("blockgruen", screen.Content.Load<Texture2D>("blockgruen"));


            Settings.Textures.Add("block-feuer", screen.Content.Load<Texture2D>("block-feuer"));
            Settings.Textures.Add("block-wasser", screen.Content.Load<Texture2D>("block-wasser"));
            Settings.Textures.Add("block-holz-baum", screen.Content.Load<Texture2D>("block-holz-baum"));
            Settings.Textures.Add("block-sand", screen.Content.Load<Texture2D>("block-sand"));
            Settings.Textures.Add("block-holz-kiste", screen.Content.Load<Texture2D>("block-holz-kiste"));
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
