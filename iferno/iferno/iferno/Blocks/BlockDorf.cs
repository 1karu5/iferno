using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace iferno
{
    public class BlockDorf:Block
    {
        public BlockDorf(Map map, int x, int y)
            : base(map, x, y, Color.White, Settings.Textures["block-dorf" + Settings.Rnd.Next(0, 3)])
        {
            dmg = 0;  
        }
    }
}
