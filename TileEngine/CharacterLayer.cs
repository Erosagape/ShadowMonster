using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
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
        public static CharacterLayer Load(ContentManager content, BinaryReader reader)
        {
            CharacterLayer layer = new CharacterLayer();
            int count = reader.ReadInt32();
            for (int i = 0; i < count; i++)
            {
                Character c = null;
                int charType = reader.ReadInt32();
                Point position = new Point(reader.ReadInt32(), reader.ReadInt32());
                if (charType == 1)
                {
                    c = Character.Load(content, reader);
                }
                else if (charType == 2)
                {
                    c = Merchant.Load(content, reader);
                }
                layer.characters.Add(position, c);
            }
            return layer;
        }

    }
}
