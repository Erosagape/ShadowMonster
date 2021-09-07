using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
namespace ShadowMonster.TileEngine
{
    public class TileMap
    {
        string mapName;
        TileLayer groundLayer;
        TileLayer edgeLayer;
        TileLayer buildingLayer;
        TileLayer decorationLayer;
        int mapWidth;
        int mapHeight;
        TileSet tileSet;
        public string MapName
        {
            get { return mapName; }
            private set { mapName = value; }
        }
        public TileSet TileSet
        {
            get { return tileSet; }
            set { tileSet = value; }
        }
        public TileLayer GroundLayer
        {
            get { return groundLayer; }
            set { groundLayer = value; }
        }
        public TileLayer EdgeLayer
        {
            get { return edgeLayer; }
            set { edgeLayer = value; }
        }
        public TileLayer BuildingLayer
        {
            get { return buildingLayer; }
            set { buildingLayer = value; }
        }
        public int MapWidth
        {
            get { return mapWidth; }
        }
        public int MapHeight
        {
            get { return mapHeight; }
        }
        public int WidthInPixels
        {
            get { return mapWidth * Engine.TileWidth; }
        }
        public int HeightInPixels
        {
            get { return mapHeight * Engine.TileHeight; }
        }
        private TileMap()
        {

        }
        private TileMap(TileSet tileSet,string mapName)
        {
            this.tileSet = tileSet;
            this.mapName = mapName;
        }
        public TileMap(
            TileSet tileSet,
            TileLayer ground,
            TileLayer edge,
            TileLayer building,
            TileLayer decoration,
            string mapName
            ) : this(tileSet,mapName)
        {
            this.groundLayer = ground;
            this.edgeLayer = edge;
            this.buildingLayer = building;
            this.decorationLayer = decoration;

            mapWidth = groundLayer.Width;
            mapHeight = groundLayer.Height;
        }
        public void SetGroundTile(int x,int y,int set,int index)
        {
            groundLayer.SetTile(x, y, set, index);
        }
        public Tile GetGroundTile(int x,int y)
        {
            return groundLayer.GetTile(x, y);
        }
        public void SetEdgeTile(int x,int y,int set,int index)
        {
            edgeLayer.SetTile(x, y, set, index);
        }
        public Tile GetEdgeTile(int x,int y)
        {
            return edgeLayer.GetTile(x, y);
        }
        public void SetBuildingTile(int x,int y,int set,int index)
        {
            buildingLayer.SetTile(x, y, set, index);
        }
        public Tile GetBuildingTile(int x,int y)
        {
            return GetBuildingTile(x, y);
        }
        public void SetDecorationTile(int x,int y,int set,int index)
        {
            decorationLayer.SetTile(x, y, set, index);
        }
        public Tile GetDecorationTile(int x,int y)
        {
            return decorationLayer.GetTile(x, y);
        }
        public void FillEdges()
        {
            for(int y = 0; y < mapHeight; y++)
            {
                for(int x = 0; x < mapWidth; x++)
                {
                    edgeLayer.SetTile(x, y, -1, -1); 
                }
            }
        }
        public void FillBuilding()
        {
            for (int y = 0; y < mapHeight; y++)
            {
                for (int x = 0; x < mapWidth; x++)
                {
                    buildingLayer.SetTile(x, y, -1, -1);
                }
            }
        }
        public void FillDecoration()
        {
            for (int y = 0; y < mapHeight; y++)
            {
                for (int x = 0; x < mapWidth; x++)
                {
                    decorationLayer.SetTile(x, y, -1, -1);
                }
            }
        }
        public void Update(GameTime gameTime)
        {
            if (groundLayer != null)
                groundLayer.Update(gameTime);
            if (edgeLayer != null)
                edgeLayer.Update(gameTime);
            if (buildingLayer != null)
                buildingLayer.Update(gameTime);
            if (decorationLayer != null)
                decorationLayer.Update(gameTime);
        }
        public void Draw(GameTime gameTime,SpriteBatch spriteBatch,Camera camera)
        {
            if (groundLayer != null)
                groundLayer.Draw(gameTime, spriteBatch, tileSet, camera);
            if (edgeLayer != null)
                edgeLayer.Draw(gameTime, spriteBatch, tileSet, camera);
            if (buildingLayer != null)
                buildingLayer.Draw(gameTime, spriteBatch, tileSet, camera);
            if (decorationLayer != null)
                decorationLayer.Draw(gameTime, spriteBatch, tileSet, camera);
        }
    }
}
