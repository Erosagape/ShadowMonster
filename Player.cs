<<<<<<< HEAD
﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ShadowMonsters.Items;
using ShadowMonsters.ShadowMonsters;
using ShadowMonsters.TileEngine;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

=======
﻿using System;
using System.Collections.Generic;
using System.Text;

using ShadowMonsters.TileEngine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
>>>>>>> 9d444d84de81f8a24139bc81c8b2f9f695ad0c9b
namespace ShadowMonsters
{
    public class Player : DrawableGameComponent
    {
        public const int MaxShadowMonsters = 6;
<<<<<<< HEAD

        #region Field Region

=======
>>>>>>> 9d444d84de81f8a24139bc81c8b2f9f695ad0c9b
        private Game1 gameRef;
        private string name;
        private bool gender;
        private string mapName;
        private Point tile;
        private AnimatedSprite sprite;
        private Texture2D texture;
        private string textureName;
        private float speed = 256f;
<<<<<<< HEAD

        private Vector2 position;
        private Backpack backpack;

        private readonly List<ShadowMonster> shadowMonsters = new List<ShadowMonster>();
        private readonly ShadowMonster[] battleShadowMonsters = new ShadowMonster[MaxShadowMonsters];
        private int selected;
        private readonly Dictionary<string, string> _charactersMet = new Dictionary<string, string>();
        private readonly Dictionary<int, string> _keysFound = new Dictionary<int, string>();

        #endregion

        #region Property Region

        public ShadowMonster[] BattleShadowMonsters
        {
            get { return battleShadowMonsters; }
        }

        public Backpack Backpack { get => backpack; }
        public ShadowMonster Selected
        {
            get { return battleShadowMonsters[selected]; }
        }

        public Dictionary<int, string> KeysFound => _keysFound;

        public Dictionary<string, string> CharactersMet => _charactersMet;

=======
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
>>>>>>> 9d444d84de81f8a24139bc81c8b2f9f695ad0c9b
        public int Gold { get; internal set; }
        public Vector2 Position
        {
            get { return sprite.Position; }
            set { sprite.Position = value; }
        }
<<<<<<< HEAD

=======
>>>>>>> 9d444d84de81f8a24139bc81c8b2f9f695ad0c9b
        public AnimatedSprite Sprite
        {
            get { return sprite; }
        }
<<<<<<< HEAD

=======
>>>>>>> 9d444d84de81f8a24139bc81c8b2f9f695ad0c9b
        public float Speed
        {
            get { return speed; }
            set { speed = value; }
        }
<<<<<<< HEAD

=======
>>>>>>> 9d444d84de81f8a24139bc81c8b2f9f695ad0c9b
        public string MapName
        {
            get { return mapName; }
            set { mapName = value; }
        }
<<<<<<< HEAD

        public Point Tile
        {
            get { return tile; }
            internal set { tile = value; }
        }
        #endregion

        #region Constructor Region

        private Player(Game game)
            : base(game)
        {
            backpack = new Backpack();
        }

        public Player(Game game, string name, bool gender, string textureName)
            : base(game)
=======
        private Player(Game game)
            :base(game)
        {

        }
        public Player(Game game,string name,bool gender,string textureName) : base(game)
>>>>>>> 9d444d84de81f8a24139bc81c8b2f9f695ad0c9b
        {
            gameRef = (Game1)game;
            this.name = name;
            this.gender = gender;
<<<<<<< HEAD

            if (gender)
                this.textureName = textureName + "_f";
            else
                this.textureName = textureName + "_m";

            sprite = new AnimatedSprite(
                game.Content.Load<Texture2D>(@"CharacterSprites\" + this.textureName), 
                Game1.Animations)
            {
                CurrentAnimation = AnimationKey.WalkDown
            };
            Gold = 1000;
            backpack = new Backpack();
        }

        #endregion

        #region Method Region
        public virtual void AddShadowMonster(ShadowMonster shadowMonster)
        {
            shadowMonsters.Add(shadowMonster);
        }

        public void SetCurrentShadowMonster(int index)
        {
            if (index < 0 || index >= MaxShadowMonsters)
                throw new IndexOutOfRangeException();

            if (battleShadowMonsters[index] != null)
                selected = index;
        }

        public ShadowMonster GetShadowMonster(int index)
        {
            if (index < 0 || index >= MaxShadowMonsters)
                throw new IndexOutOfRangeException();

=======
            this.textureName = textureName;
            sprite = new AnimatedSprite(
                game.Content.Load<Texture2D>(textureName),
                Game1.Animations
                )
            {
                CurrentAnimation=AnimationKey.WalkDown
            };
            Gold = 1000;
        }
        public virtual void AddShadowMonster(ShadowMonsters.Monster  mon)
        {
            shadowMonsters.Add(mon);
        }
        public void SetCurrentShadowMonster(int index)
        {
            if (index < 0 || index >= MaxShadowMonsters)
            {
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
                return null;
            }
>>>>>>> 9d444d84de81f8a24139bc81c8b2f9f695ad0c9b
            return shadowMonsters[index];
        }
        internal bool Alive()
        {
<<<<<<< HEAD
            for (int i = 0; i < MaxShadowMonsters; i++)
                if (battleShadowMonsters[i] != null && battleShadowMonsters[i].Alive)
                    return true;

            return false;
        }

        public ShadowMonster GetBattleShadowMonster(int index)
        {
            if (index < 0 || index > MaxShadowMonsters)
                throw new IndexOutOfRangeException();

            return battleShadowMonsters[index];
        }

        internal void HealBattleShadowMonsters()
        {
            foreach (ShadowMonster a in battleShadowMonsters)
=======
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
                return null;
            }
            return battleShadowMonsters[index];
        }
        internal void HealBattleShadowMonsters()
        {
            foreach(var a in battleShadowMonsters)
>>>>>>> 9d444d84de81f8a24139bc81c8b2f9f695ad0c9b
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
<<<<<<< HEAD

        internal void AddKey(int key, string name)
        {
            if (!KeysFound.ContainsKey(key))
                KeysFound.Add(key, name);
        }

=======
        internal void AddKey(int key,string name)
        {
            if (!KeysFound.ContainsKey(key))
            {
                KeysFound.Add(key, name);
            }
        }
>>>>>>> 9d444d84de81f8a24139bc81c8b2f9f695ad0c9b
        public override void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
            base.Update(gameTime);
        }
<<<<<<< HEAD

=======
>>>>>>> 9d444d84de81f8a24139bc81c8b2f9f695ad0c9b
        public override void Draw(GameTime gameTime)
        {
            sprite.Draw(gameTime, gameRef.SpriteBatch);
            base.Draw(gameTime);
        }
<<<<<<< HEAD

        internal void Save(BinaryWriter writer)
        {
            StringBuilder b = new StringBuilder();

            b.Append(name);
            b.Append(",");
            b.Append(gender);
            b.Append(",");
            b.Append(mapName);
            b.Append(",");
            b.Append(tile.X);
            b.Append(",");
            b.Append(tile.Y);
            b.Append(",");
            b.Append(textureName);
            b.Append(",");
            b.Append(speed);
            b.Append(",");
            b.Append(sprite.CurrentAnimation);
            b.Append(",");
            b.Append(sprite.Position.X);
            b.Append(",");
            b.Append(sprite.Position.Y);

            writer.Write(b.ToString());
            writer.Write(shadowMonsters.Count);

            foreach (ShadowMonster a in shadowMonsters)
            {
                a.Save(writer);
                writer.Write(-1);
            }

            writer.Write(selected);

            foreach (ShadowMonster a in battleShadowMonsters)
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

            writer.Write(-1);
            backpack.Save(writer);
        }

        public static Player Load(Game1 game, BinaryReader reader)
        {
            Player player = new Player(game);
            player.gameRef = game;
            string data = reader.ReadString();
            string[] parts = data.Split(',');

            player.name = parts[0];
            player.gender = bool.Parse(parts[1]);
            player.mapName = parts[2];
            player.tile = new Point(
                int.Parse(parts[3]),
                int.Parse(parts[4]));
            player.textureName = parts[5];
            player.speed = float.Parse(parts[6]);
            player.sprite = new AnimatedSprite(
                game.Content.Load<Texture2D>(parts[5]),
                Game1.Animations);
            player.sprite.CurrentAnimation = (AnimationKey)Enum.Parse(typeof(AnimationKey), parts[7]);
            player.sprite.Position = new Vector2(float.Parse(parts[8]), float.Parse(parts[9]));

            int count = reader.ReadInt32();

            for (int i = 0; i < count; i++)
            {
                ShadowMonster a = ShadowMonster.Load(game.Content, reader.ReadString());
                reader.ReadInt32();

                player.shadowMonsters.Add(a);
            }

            player.selected = reader.ReadInt32();

            for (int i = 0; i < 6; i++)
            {
                string monster = reader.ReadString();
                reader.ReadInt32();

                if (monster != "*")
                {
                    ShadowMonster a = ShadowMonster.Load(game.Content, monster);
                    player.battleShadowMonsters[i] = a;
                }
            }

            player.backpack = Backpack.Load(reader);

            return player;
        }

        #endregion
=======
>>>>>>> 9d444d84de81f8a24139bc81c8b2f9f695ad0c9b
    }
}
