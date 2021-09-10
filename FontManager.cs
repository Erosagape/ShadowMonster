<<<<<<< HEAD
﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

=======
﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
>>>>>>> 9d444d84de81f8a24139bc81c8b2f9f695ad0c9b
namespace ShadowMonsters
{
    public class FontManager : DrawableGameComponent
    {
<<<<<<< HEAD
        private readonly static Dictionary<string, SpriteFont> _fonts =
            new Dictionary<string, SpriteFont>();
        private static Game gameRef;

=======
        private readonly static Dictionary<string, SpriteFont> _fonts = new Dictionary<string, SpriteFont>();
        private static Game gameRef;
>>>>>>> 9d444d84de81f8a24139bc81c8b2f9f695ad0c9b
        public FontManager(Game game) : base(game)
        {
            gameRef = game;
        }
<<<<<<< HEAD

        protected override void LoadContent()
        {
            _fonts.Add("testfont", Game.Content.Load<SpriteFont>(@"Fonts\testfont"));
            _fonts.Add("testfont_medium", Game.Content.Load<SpriteFont>(@"Fonts\testfont_medium"));
            _fonts.Add("testfont_high", Game.Content.Load<SpriteFont>(@"Fonts\testfont_high"));
            _fonts.Add("testfont_ultra", Game.Content.Load<SpriteFont>(@"Fonts\testfont_ultra"));
        }

        public static SpriteFont GetFont(string name)
        {
            if (gameRef.GraphicsDevice.Viewport.Width >= 4000)
            {
                name += "_ultra";
            }
            else if (gameRef.GraphicsDevice.Viewport.Width >= 3000)
            {
                name += "_high";
            }
            else if (gameRef.GraphicsDevice.Viewport.Width >= 1920)
            {
                name += "_medium";
            }

            return _fonts[name];
        }

        public static bool ContainsFont(string name)
        {
            if (gameRef.GraphicsDevice.Viewport.Width >= 4000)
            {
                name += "ultra";
            }
            else if (gameRef.GraphicsDevice.Viewport.Width >= 3000)
            {
                name += "high";
            }
            else if (gameRef.GraphicsDevice.Viewport.Width >= 1920)
            {
                name += "_medium";
            }

=======
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
>>>>>>> 9d444d84de81f8a24139bc81c8b2f9f695ad0c9b
            return _fonts.ContainsKey(name);
        }
    }
}
