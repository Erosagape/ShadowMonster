using System;
using System.Collections.Generic;
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
    }
}
