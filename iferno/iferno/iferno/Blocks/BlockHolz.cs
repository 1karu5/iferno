﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace iferno
{
    public class BlockHolz:Block
    {

        public BlockHolz(Map map,int x, int y):base(map,x,y,Color.White,Settings.Textures["block-holz-baum"])
        {
           dmg = -10;
        }

        public override bool OnCollisionWithPlayer(Player p)
        {
            isDestroying = true;

            return true;
        }
    }
}