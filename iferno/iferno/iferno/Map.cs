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
            //baum
            Settings.Textures.Add("block-holz-baum0", screen.Content.Load<Texture2D>("block/baumstamm/1stamm"));
            Settings.Textures.Add("block-holz-baum1", screen.Content.Load<Texture2D>("block/baumstamm/2stamm"));
            Settings.Textures.Add("block-holz-baum2", screen.Content.Load<Texture2D>("block/baumstamm/3stamm"));
            //dorf
            Settings.Textures.Add("block-dorf0", screen.Content.Load<Texture2D>("block/dorf/1dorf"));
            Settings.Textures.Add("block-dorf1", screen.Content.Load<Texture2D>("block/dorf/2dorf"));
            Settings.Textures.Add("block-dorf2", screen.Content.Load<Texture2D>("block/dorf/3dorf"));
            //stein
            Settings.Textures.Add("block-stein0", screen.Content.Load<Texture2D>("block/hoehle/1hoehle"));
            Settings.Textures.Add("block-stein1", screen.Content.Load<Texture2D>("block/hoehle/2hoehle"));
            Settings.Textures.Add("block-stein2", screen.Content.Load<Texture2D>("block/hoehle/3hoehle"));
            Settings.Textures.Add("block-stein3", screen.Content.Load<Texture2D>("block/hoehle/4hoehle"));
            //sand
            Settings.Textures.Add("block-sand0", screen.Content.Load<Texture2D>("block/sand/1sand"));
            Settings.Textures.Add("block-sand1", screen.Content.Load<Texture2D>("block/sand/2sand"));
            Settings.Textures.Add("block-sand2", screen.Content.Load<Texture2D>("block/sand/3sand"));
            Settings.Textures.Add("block-sand3", screen.Content.Load<Texture2D>("block/sand/4sand"));
            //dschungel
            Settings.Textures.Add("block-dschungel0", screen.Content.Load<Texture2D>("block/wald/1wald"));
            Settings.Textures.Add("block-dschungel1", screen.Content.Load<Texture2D>("block/wald/2wald"));
            Settings.Textures.Add("block-dschungel2", screen.Content.Load<Texture2D>("block/wald/3wald"));
            Settings.Textures.Add("block-dschungel3", screen.Content.Load<Texture2D>("block/wald/4wald"));
            //uneteres wasser
            Settings.Textures.Add("block-untereswasser", screen.Content.Load<Texture2D>("block/wasser/wasser_still"));
            //platform
            Settings.Textures.Add("block-platform", screen.Content.Load<Texture2D>("block/block-platform"));
            //kiste
            Settings.Textures.Add("block-kiste0", screen.Content.Load<Texture2D>("block/kisten/1kiste"));
            Settings.Textures.Add("block-kiste1", screen.Content.Load<Texture2D>("block/kisten/2kiste"));
            Settings.Textures.Add("block-kiste2", screen.Content.Load<Texture2D>("block/kisten/3kiste"));
            Settings.Textures.Add("block-kiste3", screen.Content.Load<Texture2D>("block/kisten/4kiste"));

            Settings.Textures.Add("blockgruen", screen.Content.Load<Texture2D>("block/blockgruen"));

            Settings.Textures.Add("waterdrop", screen.Content.Load<Texture2D>("block/waterdrop"));
            
            Settings.Textures.Add("block-ende", screen.Content.Load<Texture2D>("block/level_ende_pfeil"));

            
            Settings.Textures.Add("blattSprite", screen.Content.Load<Texture2D>("block/blattSprite"));
            Settings.Textures.Add("ventilatorSprite", screen.Content.Load<Texture2D>("block/ventilatorSprite"));
            Settings.Textures.Add("block-white", screen.Content.Load<Texture2D>("block/block-white"));
            Settings.Textures.Add("block-transparent", screen.Content.Load<Texture2D>("block/block-transparent"));
            Settings.Textures.Add("block-black", screen.Content.Load<Texture2D>("block/block-black"));
            Settings.Textures.Add("block-feuer", screen.Content.Load<Texture2D>("block/block-feuer"));
            Settings.Textures.Add("block-wasser", screen.Content.Load<Texture2D>("block/wassersprite"));
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
