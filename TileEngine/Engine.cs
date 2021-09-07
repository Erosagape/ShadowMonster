using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace ShadowMonster.TileEngine
{
    public class Engine
    {
        private static Rectangle viewPortRectangle;
        public static Rectangle ViewportRectangle
        {
            get { return viewPortRectangle; }
            set { viewPortRectangle = value; }
        }
        private static int tileWidth = 32;
        public static int TileWidth
        {
            get { return tileWidth; }
            set { tileWidth = value; }
        }
        private static int tileHeight = 32;
        public static int TileHeight
        {
            get { return tileHeight; }
            set { tileHeight = value; }
        }
        private TileMap map;
        public TileMap Map
        {
            get { return map; }
        }
        private static Camera camera;
        public static Camera Camera
        {
            get { return camera; }
        }
        public Engine(Rectangle viewport)
        {
            viewPortRectangle = viewport;
            camera = new Camera();
            tileWidth = 64;
            tileHeight = 64;
        }
        public Engine(Rectangle viewport,int tileWidth,int tileHeight)
            :this(viewport)
        {
            TileWidth = tileWidth;
            TileHeight = tileHeight;
        }
        public static Point VectorToCell(Vector2 position)
        {
            return new Point((int)position.X / tileWidth, (int)position.Y / tileHeight);
        }
        public void SetMap(TileMap newMap)
        {
            map = newMap ?? throw new ArgumentNullException("newMap");
        }
        public void Update(GameTime gameTime)
        {
            Map.Update(gameTime);
        }
        public void Draw(GameTime gameTime,SpriteBatch spriteBatch)
        {
            Map.Draw(gameTime, spriteBatch, camera);
        }
    }
}
