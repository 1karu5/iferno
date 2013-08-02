using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace iferno
{
    public class BlockWolke : Block
    {
        public BlockWolke(Map map, int x, int y)
            : base(map, x, y, Color.White, Settings.Textures["block-wolke" + Settings.Rnd.Next(0, 2)])
        {
            dmg = 0;
            collideWithPlayer = false;
        }
    }
}
