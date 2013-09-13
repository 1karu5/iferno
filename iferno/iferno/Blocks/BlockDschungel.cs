using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace iferno
{
    public class BlockDschungel:Block
    {
        public BlockDschungel(Map map, int x, int y)
            : base(map, x, y, Color.White, Settings.Textures["block-dschungel" + Settings.Rnd.Next(0, 4)])
        {
           
        }
    }
}
