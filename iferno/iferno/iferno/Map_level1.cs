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


            newMap.Add(new Block(this, 0, 11, Color.White, Settings.Textures["block-wasser"]));
            newMap.Add(new Block(this, 1, 11, Color.White, Settings.Textures["block-wasser"]));
            for (int i = 2; i < 28; i++)
            {
                newMap.Add(new Block(this, i, 11, Color.White, Settings.Textures["block-sand"]));
            }
            newMap.Add(new Block(this, 28, 11, Color.White, Settings.Textures["block-wasser"]));
            newMap.Add(new Block(this, 29, 11, Color.White, Settings.Textures["block-wasser"]));
            for (int i = 30; i < 68; i++)
            {
                newMap.Add(new Block(this, i, 11, Color.White, Settings.Textures["block-sand"]));
            }

            return newMap;
        }

        public override void LoadContent()
        {
            Settings.Textures.Add("block-feuer", screen.Content.Load<Texture2D>("block-feuer"));
            Settings.Textures.Add("block-wasser", screen.Content.Load<Texture2D>("block-wasser"));
            Settings.Textures.Add("block-holz-baum", screen.Content.Load<Texture2D>("block-holz-baum"));
            Settings.Textures.Add("block-sand", screen.Content.Load<Texture2D>("block-sand"));
            Settings.Textures.Add("block-holz-kiste", screen.Content.Load<Texture2D>("block-holz-kiste"));
        }

        
    }
}
