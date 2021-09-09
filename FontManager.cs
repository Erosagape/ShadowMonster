﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace ShadowMonster
{
    public class FontManager : DrawableGameComponent
    {
        private readonly static Dictionary<string, SpriteFont> _fonts = new Dictionary<string, SpriteFont>();
        private static Game gameRef;
        public FontManager(Game game) : base(game)
        {
            gameRef = game;
        }
        protected override void LoadContent()
        {
            _fonts.Add("testfont", Game.Content.Load<SpriteFont>("Fonts/testfont"));
        }
        public static SpriteFont GetFont(string name)
        {
            /*
            if (gameRef.GraphicsDevice.Viewport.Height == 1080)
            {
                name += "1080";
            }
            */
            return _fonts[name];
        }
        public static bool ContainsFont(string name)
        {
            /*
            if (gameRef.GraphicsDevice.Viewport.Height == 1080)
            {
                name += "1080";
            }
            */
            return _fonts.ContainsKey(name);
        }
    }
}