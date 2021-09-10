using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
namespace ShadowMonsters.TileEngine
{
    public class TileSet
    {
        public int TilesWide = 8;
        public int TilesHigh = 10;
        public int TileWidth = 16;
        public int TileHeight = 16;
        public List<Texture2D> image;
        public List<Texture2D> Textures
        {
            get { return image; }
        }
        public List<string> imageName;
        public List<string> TextureNames
        {
            get { return imageName; }
        }
        public Rectangle[] sourceRectangles;
        public Rectangle[] SourceRectangles
        {
            get { return sourceRectangles; }
        }
        public TileSet()
        {
            image = new List<Texture2D>();
            imageName = new List<string>();
            SetRectangles();
        }
        public TileSet(int tilesWide, int tilesHigh, int tileWidth, int tileHeight)
        {
            TilesWide = tilesWide;
            TilesHigh = tilesHigh;
            TileWidth = tileWidth;
            TileHeight = tileHeight;
            SetRectangles();
        }
        private void SetRectangles()
        {
            sourceRectangles = new Rectangle[TilesWide * TilesHigh];
            int tile = 0;
            for (int y = 0; y < TilesHigh; y++)
            {
                for (int x = 0; x < TilesWide; x++)
                {
                    sourceRectangles[tile] = new Rectangle(
                        x * TileWidth,
                        y * TileHeight,
                        TileWidth,
                        TileHeight
                        );
                    tile++;
                }
           }
        }
    }
}
