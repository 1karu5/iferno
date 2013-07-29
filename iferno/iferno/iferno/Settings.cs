using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace iferno
{
    public static class Settings
    {
        public const int Width = 1024;
        public const int Height = 768;

        public const int PlayerSpeed = 200;

        public static Random Rnd = new Random();

        public static Dictionary<string, Texture2D> Textures =
            new Dictionary<string, Texture2D>();
    }
}
