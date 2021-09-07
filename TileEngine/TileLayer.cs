using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
namespace ShadowMonster.TileEngine
{
    public class Tile
    {
        public int TileSet { get; set; }
        public int TileIndex { get; set; }
        public Tile()
        {
            TileSet = -1;
            TileIndex = -1;
        }
        public Tile(int set,int idx)
        {
            TileSet = set;
            TileIndex = idx;
        }
    }
    public class TileLayer
    {
        readonly Tile[] tiles;
        int width;
        public int Width
        {
            get { return width; }
            private set { width = value; }
        }
        int height;
        public int Height
        {
            get { return height; }
            private set { height = value; }
        }
        Point cameraPoint;
        Point viewPoint;
        Point min;
        Point max;
        Rectangle destination;
        public bool Enabled { get; set; }
        public bool Visible { get; set; }
        public TileLayer()
        {
            Visible = true;
            Enabled = true;
        }
        public TileLayer(Tile[] tiles,int width,int height) 
            :this()
        {
            this.tiles = (Tile[])tiles.Clone();
            this.width = width;
            this.height = height;
        }
        public TileLayer(int width,int height)
            :this()
        {
            tiles = new Tile[height * width];
            this.width = width;
            this.height = height;
            for (int y = 0; y < this.height; y++)
            {
                for (int x = 0; x < this.width; x++)
                {
                    tiles[y * width + x] = new Tile();
                }

            }
        }
        public TileLayer(int width,int height,int set,int index)
        {
            tiles = new Tile[height * width];
            this.width = width;
            this.height = height;
            for (int y = 0; y < this.height; y++)
            {
                for (int x = 0; x < this.width; x++)
                {
                    tiles[y * width + x] = new Tile(set,index);
                }
            }
        }
        public Tile GetTile(int x,int y)
        {
            if (x < 0 || y < 0)
                return new Tile();
            if (x >= width || y >= height)
                return new Tile();
            return tiles[y * width + x];
        }
        public void SetTile(int x,int y,int tileSet,int tileIndex)
        {
            if (x < 0 || y < 0)
                return;
            if (x >= width || y >= height)
                return;
            tiles[y * width + x] = new Tile(tileSet, tileIndex);
        }
        public void Update(GameTime gameTime)
        {
            if (!Enabled)
                return;
        }
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch, TileSet tileSet, Camera camera)
        {
            if (!Visible)
                return;
            cameraPoint = Engine.VectorToCell(camera.Position);
            viewPoint = Engine.VectorToCell(
                new Vector2(
                    (camera.Position.X + Engine.ViewportRectangle.Width),
                    (camera.Position.Y + Engine.ViewportRectangle.Height)
                    )
                );
            min.X = Math.Max(0, cameraPoint.X - 1);
            min.Y = Math.Max(0, cameraPoint.Y - 1);
            max.X = Math.Min(viewPoint.X + 1, width);
            max.Y = Math.Min(viewPoint.Y + 1, height);
            destination = new Rectangle(
                0, 0,
                Engine.TileWidth,
                Engine.TileHeight
                );
            Tile tile;
            spriteBatch.Begin(
                SpriteSortMode.Deferred,
                BlendState.AlphaBlend,
                SamplerState.PointClamp,
                null, null, null,
                camera.Transformation
                );
            for (int y = min.Y; y < max.Y; y++)
            {
                destination.Y = y * Engine.TileHeight;
                for(int x = min.X; x < max.X; x++)
                {
                    tile = GetTile(x, y);
                    if (tile.TileSet == -1 || tile.TileIndex == -1)
                        continue;
                    destination.X = x * Engine.TileWidth;
                    spriteBatch.Draw(
                        tileSet.Textures[tile.TileSet],
                        destination,
                        tileSet.sourceRectangles[tile.TileIndex],
                        Color.White
                        );
                }
            }

            spriteBatch.End();
        }
    }
}
