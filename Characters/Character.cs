using System;
using System.Collections.Generic;
using System.Text;
using ShadowMonsters;
using Microsoft.Xna.Framework;
using ShadowMonsters.TileEngine;
using System.Linq;
using Microsoft.Xna.Framework.Graphics;
using System.IO;

namespace ShadowMonsters.Characters
{
    public class Character
    {
        public const float SpeakingRadius = 40f;
        public const int MonsterLimit = 6;
        protected string name;
        public string Name 
        {
            get { return name; }
            set { name = value; }
        }
        protected string textureName;
        public string SpriteName 
        { 
            get { return textureName; }
        }
        protected readonly ShadowMonsters.ShadowMonster [] monsters = new ShadowMonsters.ShadowMonster [MonsterLimit];
        protected int currentMonster;
        protected ShadowMonsters.ShadowMonster  givingMonster;
        protected AnimatedSprite sprite;
        public AnimatedSprite Sprite
        {
            get { return sprite; }
        }
        protected string conversation;
        public string Conversation {
            get
            {
                return conversation;
            }
        }
        public bool Battled { get; set; }
        protected static Game gameRef;
        public List<ShadowMonsters.ShadowMonster > BattleMonsters => monsters.ToList<ShadowMonsters.ShadowMonster >();
        public ShadowMonsters.ShadowMonster  BattleMonster
        {
            get { return monsters[currentMonster]; }
        }
        public ShadowMonsters.ShadowMonster  GiveMonster
        {
            get { return givingMonster; }
        }
        protected Character()
        {

        }
        public bool NextMonster()
        {
            currentMonster++;
            return currentMonster < MonsterLimit && monsters[currentMonster] != null;
        }
        public static Character FromString(Game game,string characterString)            
        {
            if (gameRef == null)
                gameRef = game;

            Character character= new Character();
            string[] parts = characterString.Split(',');
            character.name = parts[0];
            character.textureName = parts[1];
            character.sprite = new AnimatedSprite(
                game.Content.Load<Texture2D>(@"Sprites\" + parts[1]),
                Game1.Animations
                )
            {
                CurrentAnimation = (AnimationKey)Enum.Parse(typeof(AnimationKey), parts[2])
            };
            character.conversation = parts[3];
            character.currentMonster = int.Parse(parts[4]);
            for(int i=5;i<11 && i< parts.Length - 1; i++)
            {
                var monster =
                    ShadowMonsterManager.GetShadowMonster(parts[i].ToLowerInvariant());
                character.monsters[i - 5] = monster;
            }
            character.givingMonster = ShadowMonsterManager.GetShadowMonster(parts[parts.Length - 1].ToLowerInvariant());
            return character;
        }
        public void ChangeMonster(int index)
        {
            if (index < 0 || index <= MonsterLimit)
            {
                currentMonster = index;
            }
        }
        public void SetConversation(string newConver)
        {
            conversation = newConver;
        }
        public void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
        }
        public void Draw(GameTime gameTime,SpriteBatch spriteBatch)
        {
            sprite.Draw(gameTime, spriteBatch);
        }
        public bool Alive()
        {
            for(int i = 0; i < MonsterLimit; i++)
            {
                if(BattleMonsters[i]!=null && BattleMonsters[i].CurrentHealth > 0)
                {
                    return true;
                }
            }
            return false;
        }
        public virtual bool Save(BinaryWriter writer)
        {
            StringBuilder b = new StringBuilder();
            b.Append(name);
            b.Append(",");
            b.Append(textureName);
            b.Append(",");
            b.Append(sprite.CurrentAnimation);
            b.Append(",");
            b.Append(conversation);
            b.Append(",");
            b.Append(currentMonster);
            b.Append(",");
            b.Append(Battled);
            writer.Write(b.ToString());
            writer.Write(-1);
            foreach (ShadowMonster a in monsters)
            {
                if (a != null)
                {
                    a.Save(writer);
                    writer.Write(-1);
                }
                else
                {
                    writer.Write("*");
                    writer.Write(-1);
                }
            }
            if (givingMonster != null)
            {
                givingMonster.Save(writer);
                writer.Write(-1);
            }
            else
            {
                writer.Write("*");
                writer.Write(-1);
            }
            return true;
        }
    }
}
