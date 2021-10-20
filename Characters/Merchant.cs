using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ShadowMonsters.Items;
using ShadowMonsters.TileEngine;

namespace ShadowMonsters.Characters
{
    public class Merchant:Character
    {
        private Backpack backpack;
        public Backpack Backpack => backpack;
        private Merchant() :base() { }
        public new static Merchant FromString(Game game,string characterString)
        {
            if (gameRef == null)
                gameRef = game;
            Merchant character = new Merchant();
            character.backpack = new Backpack();
            string[] parts = characterString.Split(',');
            character.name = parts[0];
            character.textureName = parts[1];
            character.sprite = new AnimatedSprite(
                game.Content.Load<Texture2D>("Sprites/" + parts[1]),
                Game1.Animations
                )
            {
                CurrentAnimation = (AnimationKey)Enum.Parse(typeof(AnimationKey), parts[2])
            };
            character.conversation = parts[3];
            character.currentMonster = int.Parse(parts[4]);
            for(int i=5;i<11 && i < parts.Length - 1; i++)
            {
                Monster monster = ShadowMonsterManager.GetShadowMonster(
                    parts[i].ToLowerInvariant()
                    );
                character.monsters[i - 5] = monster;
            }
            character.givingMonster = ShadowMonsterManager.GetShadowMonster(parts[parts.Length - 1].ToLowerInvariant());
            return character;
        }
    }
}
