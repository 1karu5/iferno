using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace iferno
{
    public class BlockStein:Block
    {
        public BlockStein(Map map, int x, int y)
            : base(map, x, y, Color.White, Settings.Textures["block-stein" + Settings.Rnd.Next(0, 4)])
        {
           
        }
    }
}
