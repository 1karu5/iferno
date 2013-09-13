using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace iferno
{
    public class BlockWiese:Block
    {
        public BlockWiese(Map map, int x, int y,Texture2D t)
            : base(map, x, y, Color.White, t)
        {

        }

        public BlockWiese(Map map,int x, int y):base(map,x,y,Color.White,Settings.Textures["blockgruen"])
        {
           
        }
    }
}
