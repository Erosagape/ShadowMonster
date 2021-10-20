using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ShadowMonsters.GameStates;
using ShadowMonsters.TileEngine;
using ShadowMonsters.ConversationComponents;
using System;
using System.Collections.Generic;

namespace ShadowMonsters
{
    public class Game1 : Game
    {
        public static Player Player;
        public static Random Random = new Random();
        private static Dictionary<AnimationKey, Animation> animations = new Dictionary<AnimationKey, Animation>();

        private readonly GraphicsDeviceManager graphics;

        private readonly GamePlayState gamePlayState;
        private readonly ConversationState conversationState;
        private readonly LevelUpState levelUpState;
        private readonly BattleOverState battleOverState;
        private readonly DamageState damageState;
        private readonly BattleState battleState;
        private readonly ActionSelectionState actionSelectionState;
        private readonly ShadowMonsterSelectionState shadowMonsterSelectionState;
        private readonly StartBattleState startBattleState;
        private readonly GameStateManager stateManager;
        private readonly ShopState shopState;
        private readonly ItemSelectionState itemSelectionState;
        private readonly UseItemState useItemState;

        private SpriteBatch spriteBatch;
        public ItemSelectionState ItemSelectionState => itemSelectionState;
        public UseItemState UseItemState => useItemState;
        public ShopState ShopState => shopState;
        public ConversationState ConversationState => conversationState;
        public LevelUpState LevelUpState => levelUpState;        
        public BattleOverState BattleOverState => battleOverState;        
        public DamageState DamageState => damageState;        
        public BattleState BattleState => battleState;
        public ActionSelectionState ActionSelectionState => actionSelectionState;
        public ShadowMonsterSelectionState ShadowMonsterSelectionState => shadowMonsterSelectionState;
        public StartBattleState StartBattleState => startBattleState;
        public SpriteBatch SpriteBatch => spriteBatch;
        public GamePlayState GamePlayState => gamePlayState;
        public static Dictionary<AnimationKey, Animation> Animations => animations;
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
            conversationState = new ConversationState(this);
            levelUpState = new LevelUpState(this);
            damageState = new DamageState(this);
            battleOverState = new BattleOverState(this);
            battleState = new BattleState(this);
            actionSelectionState = new ActionSelectionState(this);
            shadowMonsterSelectionState = new ShadowMonsterSelectionState(this);
            startBattleState = new StartBattleState(this);
            shopState = new ShopState(this);
            itemSelectionState = new ItemSelectionState(this);
            useItemState = new UseItemState(this);

            stateManager.PushState(gamePlayState);            
            ConversationManager.Instance.CreateConversations(this);
            IsMouseVisible = true;
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
            Components.Add(new FontManager(this));

            Game1.Player = new Player(this, "Bonnie", true, "Sprites/mage_f");
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
