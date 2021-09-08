using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ShadowMonster.TileEngine;
namespace ShadowMonster.GameStates
{
    public class GamePlayState : BaseGameState
    {
        private readonly Engine engine = new Engine(new Rectangle(0, 0, 1280, 720));
        private TileMap map;
        private Dictionary<AnimationKey, Animation> animations = new Dictionary<AnimationKey, Animation>();
        private AnimatedSprite sprite;
        private Vector2 motion;
        public GamePlayState(Game game) : base(game)
        {

        }
        protected override void LoadContent()
        {
            // TODO: use this.Content to load your game content here
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
            engine.SetMap(map);

            Animation animation = new Animation(3, 32, 36, 0, 0);
            animations.Add(AnimationKey.WalkUp, animation);
            animation = new Animation(3, 32, 36, 0, 36);
            animations.Add(AnimationKey.WalkRight, animation);
            animation = new Animation(3, 32, 36, 0, 72);
            animations.Add(AnimationKey.WalkDown, animation);
            animation = new Animation(3, 32, 36, 0, 108);
            animations.Add(AnimationKey.WalkLeft, animation);
            sprite = new AnimatedSprite(content.Load<Texture2D>("Sprites/mage_f"), animations);
            sprite.CurrentAnimation = AnimationKey.WalkDown;
            base.LoadContent();
        }
        public override void Update(GameTime gameTime)
        {
            engine.Update(gameTime);
            motion = Vector2.Zero;
            if (Xin.KeyboardState.IsKeyDown(Keys.W) || Xin.KeyboardState.IsKeyDown(Keys.Up))
            {
                motion.Y = -1;
                sprite.CurrentAnimation = AnimationKey.WalkUp;
                sprite.IsAnimating = true;
            }
            else if (Xin.KeyboardState.IsKeyDown(Keys.S) || Xin.KeyboardState.IsKeyDown(Keys.Down))
            {
                motion.Y = 1;
                sprite.CurrentAnimation = AnimationKey.WalkDown;
                sprite.IsAnimating = true;
            }
            else if (Xin.KeyboardState.IsKeyDown(Keys.A) || Xin.KeyboardState.IsKeyDown(Keys.Left))
            {
                motion.X = -1;
                sprite.CurrentAnimation = AnimationKey.WalkLeft;
                sprite.IsAnimating = true;
            }
            else if (Xin.KeyboardState.IsKeyDown(Keys.D) || Xin.KeyboardState.IsKeyDown(Keys.Right))
            {
                motion.X = 1;
                sprite.CurrentAnimation = AnimationKey.WalkRight;
                sprite.IsAnimating = true;
            }
            else
            {
                sprite.IsAnimating = false;
            }
            if (motion != Vector2.Zero)
            {
                motion.Normalize();
                motion *= (sprite.Speed * (float)gameTime.ElapsedGameTime.TotalSeconds);

                Vector2 newPosition = sprite.Position + motion;
                newPosition.X = (int)newPosition.X;
                newPosition.Y = (int)newPosition.Y;
                sprite.Position = newPosition;
                motion = sprite.LockToMap(
                    new Point(map.WidthInPixels,map.HeightInPixels),
                    motion
                    );
            }
            Engine.Camera.LockToSprite(map, sprite, new Rectangle(0, 0, 1280, 720));
            sprite.Update(gameTime);
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
            sprite.Draw(gameTime, GameRef.SpriteBatch);
            GameRef.SpriteBatch.End();
        }
    }
}
