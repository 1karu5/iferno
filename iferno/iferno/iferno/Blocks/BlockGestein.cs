using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace iferno
{
    public class BlockGestein:Block
    {
        public BlockGestein(Map map, int x, int y)
            : base(map, x, y, Color.White, Settings.Textures["block-sand"])
        {
           
        }

        public override bool OnCollisionWithPlayer(Player p)
        {
            return true;
        }
    }
}
