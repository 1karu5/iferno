using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace iferno
{
    public static class Settings
    {
        //fenster größe
        public const int Width = 1024;
        public const int Height = 768;

        //Player werte
        public const int PlayerSpeed = 200;
        public const int PlayerFallSpeed = 200;
        public const float PlayerFallSpeedAddition = 0.05f;
        public const int PlayerJumpHeight = 100;


        //zufalls zahlen
        public static Random Rnd = new Random();

        public static Dictionary<string, Texture2D> Textures =
            new Dictionary<string, Texture2D>();
    }
}
