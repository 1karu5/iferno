using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace iferno
{
    public class Map_level1 : Map
    {
        /**
         *  fenster höhe: 12
         *  fenster breite: 16
         * 
         **/

        public Map_level1(Screen screen)
            : base(screen)
        {

        }

        public override List<Block> createMap(){
            List<Block> newMap = new List<Block>();

            for (int i = 0; i < 50; i++)
            {
                newMap.Add(new Block(this, i, 11, Color.White, Settings.Textures["block-holz-baum"]));
            }
            newMap.Add(new Block(this, 3, 10, Color.White, Settings.Textures["block-holz-baum"]));
            newMap.Add(new Block(this, 7, 10, Color.White, Settings.Textures["block-holz-baum"]));
            newMap.Add(new Block(this, 8, 10, Color.White, Settings.Textures["block-holz-baum"]));
            newMap.Add(new Block(this, 9, 10, Color.White, Settings.Textures["block-holz-baum"]));
            newMap.Add(new Block(this, 8, 9, Color.White, Settings.Textures["block-holz-baum"]));
            return newMap;
        }

        public override void LoadContent()
        {
            Settings.Textures.Add("block-feuer", screen.Content.Load<Texture2D>("block-feuer"));
            Settings.Textures.Add("block-wasser", screen.Content.Load<Texture2D>("block-wasser"));
            Settings.Textures.Add("block-holz-baum", screen.Content.Load<Texture2D>("block-holz-baum"));
        }

        
    }
}
