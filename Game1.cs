using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ShadowMonster.GameStates;
using ShadowMonster.TileEngine;
using System;
using System.Collections.Generic;

namespace ShadowMonster
{
    public class Game1 : Game
    {
        public static Random Random = new Random();
        private readonly GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private readonly GamePlayState gamePlayState;
        private readonly GameStateManager stateManager;
        private static Dictionary<AnimationKey, Animation> animations = new Dictionary<AnimationKey, Animation>();
        public static Dictionary<AnimationKey, Animation> Animations 
        {
            get { return animations; } 
        }
        public SpriteBatch SpriteBatch => spriteBatch;
        public GamePlayState GamePlayState => gamePlayState;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 1280;
            graphics.PreferredBackBufferHeight = 720;
            graphics.ApplyChanges();

            Content.RootDirectory = "Content";
            stateManager = new GameStateManager(this);
            Components.Add(stateManager);
            gamePlayState = new GamePlayState(this);
            stateManager.PushState(gamePlayState);
        }

        protected override void Initialize()
        {
            Animation animation = new Animation(3, 32, 36, 0, 0);
            animations.Add(AnimationKey.WalkUp, animation);

            animation = new Animation(3, 32, 36, 0, 36);
            animations.Add(AnimationKey.WalkRight, animation);

            animation = new Animation(3, 32, 36, 0, 72);
            animations.Add(AnimationKey.WalkDown, animation);

            animation = new Animation(3, 32, 36, 0, 108);
            animations.Add(AnimationKey.WalkLeft, animation);
            // TODO: Add your initialization logic here
            Components.Add(new Xin(this));
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
        }
        protected override void UnloadContent()
        {
            
        }
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here            
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
            
        }
    }
}
