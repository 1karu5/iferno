using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace iferno
{
    public class BlockSand:Block
    {
        public BlockSand(Map map, int x, int y)
            : base(map, x, y, Color.White, Settings.Textures["block-sand" + Settings.Rnd.Next(0, 4)])
        {
           
        }
    }
}
