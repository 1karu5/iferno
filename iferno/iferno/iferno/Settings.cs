using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace iferno
{
    public static class Settings
    {
        //fenster größe
        public const int Width = 1024;
        public const int Height = 768;

        //Player werte
        public const int PlayerSpeed = 250;
        public const int PlayerFallSpeed = 200;
        public const float PlayerFallSpeedAddition = 0.2f;
        public const float PlayerMaxYDirection = 5.1f;

        //Background
        public const int BackgroundSpeed = 2;

        public static Game1 game;
        public static Player player;
        public static int mapNumber;

        public static float playerStartX = 250;
        public static float playerStartY = 400;

        //zufalls zahlen
        public static Random Rnd = new Random();

        public static SpriteFont font;

        public static Dictionary<string, Texture2D> Textures =
            new Dictionary<string, Texture2D>();
    }
}
