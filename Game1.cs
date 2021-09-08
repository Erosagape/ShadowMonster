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
