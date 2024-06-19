using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ShadowMonsters.Characters;
namespace ShadowMonsters.TileEngine
{
    public class CharacterLayer
    {
        private readonly Dictionary<Point, Character> characters;
        public Dictionary<Point, Character> Characters => characters;
        public CharacterLayer()
        {
            characters = new Dictionary<Point, Character>();
        }
        public void Update(GameTime gameTime)
        {
            foreach (Character character in characters.Values)
            {
                character.Update(gameTime);
            }
        }
        public void Draw(GameTime gameTime,SpriteBatch spriteBatch,Camera camera)
        {
            spriteBatch.Begin(
                SpriteSortMode.Deferred,
                BlendState.AlphaBlend,
                SamplerState.PointClamp,
                null,null,null,
                camera.Transformation
                );
            foreach(Character c in characters.Values)
            {
                c.Draw(gameTime, spriteBatch);
            }
            spriteBatch.End();
        }
        public bool Save(BinaryWriter writer)
        {
            writer.Write(characters.Count);
            foreach (Point p in characters.Keys)
            {
                if (characters[p] is Merchant)
                {
                    writer.Write(2);
                }
                else
                {
                    writer.Write(1);
                }
                writer.Write(p.X);
                writer.Write(p.Y);

                characters[p].Save(writer);
            }
            return true;
        }
    }
}
