using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace iferno
{
    public class BlockUnteresWasser:Block
    {
        public BlockUnteresWasser(Map map,int x, int y):base(map,x,y,Color.White,Settings.Textures["block-untereswasser"])
        {
            dmg = 0;
            collideWithPlayer = false;
        }
    }
}
