using System;
using System.Collections.Generic;
using System.Text;

using ShadowMonsters.TileEngine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ShadowMonsters.Items;

namespace ShadowMonsters
{
    public class Player : DrawableGameComponent
    {
        public const int MaxShadowMonsters = 6;
        private Game1 gameRef;
        private string name;
        private bool gender;
        private string mapName;
        private Point tile;
        private AnimatedSprite sprite;
        private Texture2D texture;
        private string textureName;
        private float speed = 256f;
        private Vector2 position;
        private readonly List<ShadowMonsters.Monster > shadowMonsters = new List<ShadowMonsters.Monster >();
        private int currentShadowMonster;
        private readonly ShadowMonsters.Monster [] battleShadowMonsters = new ShadowMonsters.Monster [MaxShadowMonsters];
        private int selected;
        private readonly Dictionary<string, string> _characterMet = new Dictionary<string, string>();
        private readonly Dictionary<int, string> _keysfound = new Dictionary<int, string>();
        public ShadowMonsters.Monster [] BattleShadowMonsters
        {
            get { return battleShadowMonsters; }
        }
        public ShadowMonsters.Monster  Selected
        {
            get { return battleShadowMonsters[selected]; }
        }
        public Dictionary<int, string> KeysFound => _keysfound;
        public Dictionary<string, string> CharacterMet => _characterMet;
        public int Gold { get; internal set; }
        public Vector2 Position
        {
            get { return sprite.Position; }
            set { sprite.Position = value; }
        }
        public AnimatedSprite Sprite
        {
            get { return sprite; }
        }
        public float Speed
        {
            get { return speed; }
            set { speed = value; }
        }
        public string MapName
        {
            get { return mapName; }
            set { mapName = value; }
        }
        private Backpack backpack;
        public Backpack Backpack { get => backpack; }
        private Player(Game game)
            :base(game)
        {
            backpack = new Backpack();
        }
        public Player(Game game,string name,bool gender,string textureName) : base(game)
        {
            gameRef = (Game1)game;
            this.name = name;
            this.gender = gender;
            this.textureName = textureName;
            sprite = new AnimatedSprite(
                game.Content.Load<Texture2D>(textureName),
                Game1.Animations
                )
            {
                CurrentAnimation=AnimationKey.WalkDown
            };
            Gold = 1000;
            backpack = new Backpack();
        }
        public virtual void AddShadowMonster(ShadowMonsters.Monster  mon)
        {
            shadowMonsters.Add(mon);
        }
        public void SetCurrentShadowMonster(int index)
        {
            if (index < 0 || index >= MaxShadowMonsters)
            {
                throw new IndexOutOfRangeException();
            }
            else
            {
                if (battleShadowMonsters[index] != null)
                    selected = index;
            }
        }
        public ShadowMonsters.Monster  GetShadowMonster(int index)
        {
            if (index < 0 || index >= MaxShadowMonsters)
            {
                throw new IndexOutOfRangeException();
            }
            return shadowMonsters[index];
        }
        internal bool Alive()
        {
            for(int i=0;i< MaxShadowMonsters; i++)
            {
                if (battleShadowMonsters[i] != null & battleShadowMonsters[i].Alive)
                    return true;
            }
            return false;
        }
        public ShadowMonsters.Monster  GetBattleShadowMonster(int index)
        {
            if (index < 0 || index >= MaxShadowMonsters)
            {
                throw new IndexOutOfRangeException();
            }
            return battleShadowMonsters[index];
        }
        internal void HealBattleShadowMonsters()
        {
            foreach(var a in battleShadowMonsters)
            {
                if (a != null)
                {
                    a.Heal(a.GetHealth());
                    a.IsAsleep = false;
                    a.IsConfused = false;
                    a.IsFainted = false;
                    a.IsParalyzed = false;
                    a.IsPoisoned = false;
                }
            }
        }
        internal void AddKey(int key,string name)
        {
            if (!KeysFound.ContainsKey(key))
            {
                KeysFound.Add(key, name);
            }
        }
        public override void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
            base.Update(gameTime);
        }
        public override void Draw(GameTime gameTime)
        {
            sprite.Draw(gameTime, gameRef.SpriteBatch);
            base.Draw(gameTime);
        }
    }
}
