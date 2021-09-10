using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ShadowMonsters.TileEngine;

using ShadowMonsters.Characters;
using ShadowMonsters;
using ShadowMonsters.GameStates;

namespace ShadowMonsters.GameStates
{
    public class GamePlayState : BaseGameState
    {
        private readonly Engine engine = new Engine(new Rectangle(0, 0, 1280, 720));
        private TileMap map;
        private Vector2 motion;
        private bool inMotion;
        private Rectangle collision;
        private ShadowMonsterManager monsterManager = new ShadowMonsterManager();
        private int frameCount = 0;
        public GamePlayState(Game game) : base(game)
        {

        }
        protected override void LoadContent()
        {
            MoveManager.FillMoves();
            // TODO: use this.Content to load your game content here
            ShadowMonsterManager.FromFile(@".\Content\ShadowMonsters.txt", content);
            TileSet set = new TileSet();
            set.TextureNames.Add("tileset1");
            set.Textures.Add(content.Load<Texture2D>("Tiles/tileset16-outdoors"));

            TileLayer groundLayer = new TileLayer(100, 100, 0, 1);
            TileLayer edgeLayer = new TileLayer(100, 100);
            TileLayer buildingLayer = new TileLayer(100, 100);
            TileLayer decorationLayer = new TileLayer(100, 100);

            for (int i = 0; i < 1000; i++)
            {
                decorationLayer.SetTile(
                    random.Next(0, 100),
                    random.Next(0, 100),
                    0,
                    random.Next(2, 4));
            }
            map = new TileMap(set, groundLayer, edgeLayer, buildingLayer, decorationLayer, "level1");

            Character c = Character.FromString(GameRef, "Paul,ninja_m,WalkDown,PaulHello,0,fire1,,,,,,,");
            c.Sprite.Position = new Vector2(2 * Engine.TileWidth, 2 * Engine.TileHeight);
            map.CharacterLayer.Characters.Add(new Point(2, 2), c);

            engine.SetMap(map);
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            engine.Update(gameTime);
            frameCount++;
            if (!inMotion && (Xin.KeyboardState.IsKeyDown(Keys.W) || Xin.KeyboardState.IsKeyDown(Keys.Up)))
            {
                motion.Y = -1;
                Game1.Player.Sprite.CurrentAnimation = AnimationKey.WalkUp;
                Game1.Player.Sprite.IsAnimating = true;
                inMotion = true;
                collision = new Rectangle(
                    (int)Game1.Player.Sprite.Position.X,
                    (int)Game1.Player.Sprite.Position.Y - Engine.TileHeight * 2,
                    Engine.TileWidth,
                    Engine.TileHeight
                    );
            }
            else if (!inMotion && (Xin.KeyboardState.IsKeyDown(Keys.S) || Xin.KeyboardState.IsKeyDown(Keys.Down)))
            {
                motion.Y = 1;
                Game1.Player.Sprite.CurrentAnimation = AnimationKey.WalkDown;
                Game1.Player.Sprite.IsAnimating = true;
                inMotion = true;
                collision = new Rectangle(
                    (int)Game1.Player.Sprite.Position.X,
                    (int)Game1.Player.Sprite.Position.Y + Engine.TileHeight * 2,
                    Engine.TileWidth,
                    Engine.TileHeight
                    );
            }
            else if (!inMotion && (Xin.KeyboardState.IsKeyDown(Keys.A) || Xin.KeyboardState.IsKeyDown(Keys.Left)))
            {
                motion.X = -1;
                Game1.Player.Sprite.CurrentAnimation = AnimationKey.WalkLeft;
                Game1.Player.Sprite.IsAnimating = true;
                inMotion = true;
                collision = new Rectangle(
                    (int)Game1.Player.Sprite.Position.X - Engine.TileHeight * 2,
                    (int)Game1.Player.Sprite.Position.Y,
                    Engine.TileWidth,
                    Engine.TileHeight
                    );
            }
            else if (!inMotion && (Xin.KeyboardState.IsKeyDown(Keys.D) || Xin.KeyboardState.IsKeyDown(Keys.Right)))
            {
                motion.X = 1;
                Game1.Player.Sprite.CurrentAnimation = AnimationKey.WalkRight;
                Game1.Player.Sprite.IsAnimating = true;
                inMotion = true;
                collision = new Rectangle(
                    (int)Game1.Player.Sprite.Position.X + Engine.TileHeight * 2,
                    (int)Game1.Player.Sprite.Position.Y,
                    Engine.TileWidth,
                    Engine.TileHeight
                    );
            }

            if (motion != Vector2.Zero)
            {
                motion.Normalize();
                motion *= Game1.Player.Sprite.Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                Rectangle pRect = new Rectangle(
                    (int)(Game1.Player.Sprite.Position.X + motion.X),
                    (int)(Game1.Player.Sprite.Position.Y + motion.Y),
                    Engine.TileWidth,
                    Engine.TileHeight
                    );
                if (pRect.Intersects(collision))
                {
                    Game1.Player.Sprite.IsAnimating = false;
                    inMotion = false;
                    motion = Vector2.Zero;
                }
                foreach (Point p in engine.Map.CharacterLayer.Characters.Keys)
                {
                    Rectangle r = new Rectangle(
                        p.X * Engine.TileWidth,
                        p.Y * Engine.TileHeight,
                        Engine.TileWidth,
                        Engine.TileHeight
                        );
                    if (r.Intersects(pRect))
                    {
                        motion = Vector2.Zero;
                        Game1.Player.Sprite.IsAnimating = false;
                        inMotion = false;
                    }
                }
                Vector2 newPosition = Game1.Player.Sprite.Position + motion;
                newPosition.X = (int)newPosition.X;
                newPosition.Y = (int)newPosition.Y;
                Game1.Player.Sprite.Position = newPosition;
                motion = Game1.Player.Sprite.LockToMap(
                    new Point(map.WidthInPixels, map.HeightInPixels),
                    motion
                    );
                if (motion == Vector2.Zero)
                {
                    Vector2 origin = new Vector2(
                        Game1.Player.Sprite.Position.X + Game1.Player.Sprite.Origin.X,
                        Game1.Player.Sprite.Position.Y + Game1.Player.Sprite.Origin.Y
                        );
                    Game1.Player.Sprite.Position = Engine.VectorFromOrigin(origin);
                    inMotion = false;
                    Game1.Player.Sprite.IsAnimating = false;
                }
            }
            if ((Xin.CheckKeyReleased(Keys.Space) ||
                Xin.CheckKeyReleased(Keys.Enter)) && frameCount >= 5)
            {
                frameCount = 0;
                foreach (Point s in engine.Map.CharacterLayer.Characters.Keys)
                {
                    Character c = engine.Map.CharacterLayer.Characters[s];
                    AnimationKey animation = Game1.Player.Sprite.CurrentAnimation;
                    if (animation == AnimationKey.WalkLeft && (
                        (int)c.Sprite.Position.X > (int)Game1.Player.Sprite.Position.X || (int)c.Sprite.Position.Y != (int)Game1.Player.Sprite.Position.Y))
                    {
                        continue;
                    }

                    if (animation == AnimationKey.WalkUp && (
                        (int)c.Sprite.Position.X != (int)Game1.Player.Sprite.Position.X || (int)c.Sprite.Position.Y > (int)Game1.Player.Sprite.Position.Y))
                    {
                        continue;
                    }

                    if (animation == AnimationKey.WalkRight && (
                        (int)c.Sprite.Position.X < (int)Game1.Player.Sprite.Position.X || (int)c.Sprite.Position.Y != (int)Game1.Player.Sprite.Position.Y))
                    {
                        continue;
                    }

                    if (animation == AnimationKey.WalkDown && (
                        (int)c.Sprite.Position.X != (int)Game1.Player.Sprite.Position.X || (int)c.Sprite.Position.Y < (int)Game1.Player.Sprite.Position.Y))
                    {
                        continue;
                    }

                    float distance = Vector2.Distance(
                        Game1.Player.Sprite.Origin + Game1.Player.Sprite.Position,
                        c.Sprite.Origin + c.Sprite.Position
                        );
                    if (Math.Abs(distance) < Engine.TileWidth + Engine.TileWidth / 2)
                    {
                        manager.PushState(
                            GameRef.ConversationState
                            );
                        GameRef.ConversationState.SetConversation(c);
                        GameRef.ConversationState.StartConversation();
                        break;
                    }
                }
            }
            if (Xin.CheckKeyReleased(Keys.B) && frameCount >= 5)
            {
                frameCount = 0;
                foreach (Point s in engine.Map.CharacterLayer.Characters.Keys)
                {
                    Character c = engine.Map.CharacterLayer.Characters[s];
                    AnimationKey animation = Game1.Player.Sprite.CurrentAnimation;
                    if (animation == AnimationKey.WalkLeft &&
                    ((int)c.Sprite.Position.X > (int)Game1.Player.Sprite.Position.X ||
                    (int)c.Sprite.Position.Y != (int)Game1.Player.Sprite.Position.Y))
                    {
                        continue;
                    }

                    if (animation == AnimationKey.WalkUp &&
                    ((int)c.Sprite.Position.X != (int)Game1.Player.Sprite.Position.X ||
                    (int)c.Sprite.Position.Y > (int)Game1.Player.Sprite.Position.Y))
                    {
                        continue;
                    }
                    if (animation == AnimationKey.WalkRight &&
                    ((int)c.Sprite.Position.X < (int)Game1.Player.Sprite.Position.X ||
                    (int)c.Sprite.Position.Y != (int)Game1.Player.Sprite.Position.Y))
                    {
                        continue;
                    }
                    if (animation == AnimationKey.WalkDown &&
                    ((int)c.Sprite.Position.X != (int)Game1.Player.Sprite.Position.X ||
                    (int)c.Sprite.Position.Y < (int)Game1.Player.Sprite.Position.Y))
                    {
                        continue;
                    }
                    float distance = Vector2.Distance(
                    Game1.Player.Sprite.Origin + Game1.Player.Sprite.Position,
                    c.Sprite.Origin + c.Sprite.Position);
                    if (Math.Abs(distance) < Engine.TileWidth + Engine.TileWidth / 2)
                    {
                        GameRef.BattleState.SetShadowMonsters(
                        Game1.Player.Selected,
                        c.BattleMonster);
                        manager.PushState(GameRef.BattleState);
                        break;
                    }
                }
            }
            Engine.Camera.LockToSprite(map, Game1.Player.Sprite, new Rectangle(0, 0, 1280, 720));
            Game1.Player.Sprite.Update(gameTime);
            base.Update(gameTime);
        }
        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            engine.Draw(gameTime, GameRef.SpriteBatch);
            GameRef.SpriteBatch.Begin(
                SpriteSortMode.Deferred,
                BlendState.AlphaBlend,
                SamplerState.PointClamp,
                null, null, null,
                Engine.Camera.Transformation
                );
            Game1.Player.Sprite.Draw(gameTime, GameRef.SpriteBatch);
            GameRef.SpriteBatch.End();
        }
    }
}
