using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
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
                ShadowMonster monster = ShadowMonsterManager.GetShadowMonster(
                    parts[i].ToLowerInvariant()
                    );
                character.monsters[i - 5] = monster;
            }
            character.givingMonster = ShadowMonsterManager.GetShadowMonster(parts[parts.Length - 1].ToLowerInvariant());
            return character;
        }
        public override bool Save(BinaryWriter writer)
        {
            base.Save(writer);
            backpack.Save(writer);
            return true;
        }
        new public static Merchant Load(ContentManager content, BinaryReader reader)
        {
            Merchant c = new Merchant
            {
                backpack = new Backpack()
            };
            string data = reader.ReadString();
            string[] parts = data.Split(',');
            reader.ReadInt32();
            c.name = parts[0];
            c.textureName = parts[1];
            c.sprite = new AnimatedSprite(
            content.Load<Texture2D>(
            @"CharacterSprites\" + parts[1]),
            Game1.Animations);
            c.sprite.CurrentAnimation = (AnimationKey)Enum.Parse(typeof(AnimationKey),
           parts[2]);
            c.conversation = parts[3];
            c.currentMonster = int.Parse(parts[4]);
            c.Battled = bool.Parse(parts[5]);
            for (int i = 0; i < 6; i++)
            {
                string avatar = reader.ReadString();
                if (avatar != "*")
                {
                    c.monsters[i] = ShadowMonster.Load(content, avatar);
                }
                reader.ReadInt32();
            }
            string giving = reader.ReadString();
            if (giving != "*")
            {
                c.givingMonster = ShadowMonster.Load(content, giving);
            }
            c.backpack = Backpack.Load(reader);
            return c;
        }
    }
}
