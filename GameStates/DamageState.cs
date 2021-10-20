using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ShadowMonsters.GameStates
{
    public enum CurrentTurn
    {
        Players,Enemies
    }
    public interface IDamageState
    {
        void SetShadowMonsters(ShadowMonsters.Monster  player, ShadowMonsters.Monster  enemy);
        void SetMoves(IMove playerMove, IMove enemyMove);
        void Start();
    }
    public class DamageState : BaseGameState,IDamageState
    {
        private CurrentTurn turn;
        private Texture2D combatBackground;
        private Rectangle playerRect;
        private Rectangle enemyRect;
        private TimeSpan cTimer;
        private TimeSpan dTimer;
        private ShadowMonsters.Monster  player;
        private ShadowMonsters.Monster  enemy;
        private IMove playerMove;
        private IMove enemyMove;
        private bool first;
        private Rectangle playerBorderRect;
        private Rectangle enemyBorderRect;
        private Rectangle playerMiniRect;
        private Rectangle enemyMiniRect;
        private Rectangle playerHealthRect;
        private Rectangle enemyHealthRect;
        private Rectangle healthSourceRect;
        private float playerHealth;
        private float enemyHealth;
        private Texture2D avatarBorder;
        private Texture2D avatarHealth;
        private Vector2 playerName;
        private Vector2 enemyName;
        public DamageState(Game game) : base(game)
        {
            playerRect = new Rectangle(10, 90, 300, 300);
            enemyRect = new Rectangle(game.Window.ClientBounds.Width - 310, 10, 300, 300);
            playerBorderRect = new Rectangle(10, 10, 300, 75);
            enemyBorderRect = new Rectangle(game.Window.ClientBounds.Width - 310, 320, 300,
            75);
            healthSourceRect = new Rectangle(10, 50, 290, 20);
            playerHealthRect = new Rectangle(playerBorderRect.X + 12, playerBorderRect.Y + 52,
            286, 16);
            enemyHealthRect = new Rectangle(enemyBorderRect.X + 12, enemyBorderRect.Y + 52,
            286, 16);
            playerMiniRect = new Rectangle(playerBorderRect.X + 11, playerBorderRect.Y + 11,
            28, 28);
            enemyMiniRect = new Rectangle(enemyBorderRect.X + 11, enemyBorderRect.Y + 11, 28,
            28);
            playerName = new Vector2(playerBorderRect.X + 55, playerBorderRect.Y + 5);
            enemyName = new Vector2(enemyBorderRect.X + 55, enemyBorderRect.Y + 5);
        }
        public override void Initialize()
        {
            base.Initialize();
        }
        protected override void LoadContent()
        {
            combatBackground = new Texture2D(GameRef.GraphicsDevice, 1280, 720);
            Color[] buffer = new Color[1280 * 720];
            for (int i = 0; i < buffer.Length; i++)
            {
                buffer[i] = Color.White;
            }

            combatBackground.SetData(buffer);
            avatarBorder = new Texture2D(GraphicsDevice, 300, 75);
            avatarHealth = new Texture2D(GraphicsDevice, 300, 25);
            buffer = new Color[300 * 75];
            for (int i = 0; i < buffer.Length; i++)
            {
                buffer[i] = Color.Green;
            }
            avatarBorder.SetData(buffer);
            buffer = new Color[300 * 25];
            for (int i = 0; i < buffer.Length; i++)
            {
                buffer[i] = Color.Red;
            }
            avatarHealth.SetData(buffer);
            base.LoadContent();
        }
        public override void Update(GameTime gameTime)
        {
            if ((cTimer > TimeSpan.FromSeconds(3) ||
!enemy.Alive ||
!player.Alive) &&
dTimer > TimeSpan.FromSeconds(2))
            {
                if (!enemy.Alive || !player.Alive)
                {
                    manager.PopState();
                    manager.PushState((BattleOverState)GameRef.BattleOverState);
                    GameRef.BattleOverState.SetShadowMonsters(player, enemy);
                }
                else
                {
                    manager.PopState();
                }
            }
            else if (cTimer > TimeSpan.FromSeconds(2) && first && enemy.Alive && player.Alive)
            {
                first = false;
                dTimer = TimeSpan.Zero;
                if (turn == CurrentTurn.Players)
                {
                    turn = CurrentTurn.Enemies;
                    enemy.ResoleveMove(enemyMove, player);
                }
                else
                {
                    turn = CurrentTurn.Players;
                    player.ResoleveMove(playerMove, enemy);
                }
            }

            else if (cTimer == TimeSpan.Zero)
            {
                dTimer = TimeSpan.Zero;
                if (turn == CurrentTurn.Players)
                {
                    player.ResoleveMove(playerMove, enemy);
                }
                else
                {
                    enemy.ResoleveMove(enemyMove, player);
                }
            }
            cTimer += gameTime.ElapsedGameTime;
            dTimer += gameTime.ElapsedGameTime;
            base.Update(gameTime);
        }
        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            GameRef.SpriteBatch.Begin();
            GameRef.SpriteBatch.Draw(combatBackground, Vector2.Zero, Color.White);
            Vector2 location = new Vector2(25, 475);
            if (turn == CurrentTurn.Players)
            {
                GameRef.SpriteBatch.DrawString(
                FontManager.GetFont("test"),
                player.DisplayName + " uses " + playerMove.Name + ".",
                location,
                Color.Black);
                if (playerMove.Target == Target.Enemy && playerMove.MoveType ==
                MoveType.Attack)
                {
                    location.Y += FontManager.GetFont("test").LineSpacing;
                    if (ShadowMonsters.Monster .GetMoveModifier(playerMove.MoveElement, enemy.Element) <
                    1f)
                    {
                        GameRef.SpriteBatch.DrawString(
                        FontManager.GetFont("test"),
                        "It is not very effective.",
                        location,
                        Color.Black);
                    }
                    else if (ShadowMonsters.Monster .GetMoveModifier(playerMove.MoveElement,
                    enemy.Element) > 1f)
                    {
                        GameRef.SpriteBatch.DrawString(
                        FontManager.GetFont("test"),
                        "It is super effective.",
                        location,
                        Color.Black);

                    }
                }
            }
            else
            {
                GameRef.SpriteBatch.DrawString(
                FontManager.GetFont("test"),
                "Enemy " + enemy.DisplayName + " uses " + enemyMove.Name + ".",
                location,
                Color.Black);
                if (enemyMove.Target == Target.Enemy && playerMove.MoveType == MoveType.Attack)
                {
                    location.Y += FontManager.GetFont("test").LineSpacing;
                    if (ShadowMonsters.Monster .GetMoveModifier(enemyMove.MoveElement, player.Element) <
                    1f)
                    {
                        GameRef.SpriteBatch.DrawString(
                        FontManager.GetFont("test"),
                        "It is not very effective.",
                        location,
                        Color.Black);
                    }
                    else if (ShadowMonsters.Monster .GetMoveModifier(enemyMove.MoveElement,
                    player.Element) > 1f)
                    {
                        GameRef.SpriteBatch.DrawString(
                        FontManager.GetFont("test"),
                        "It is super effective.",
                        location,
                        Color.Black);
                    }
                }
            }
            GameRef.SpriteBatch.Draw(avatarBorder, playerBorderRect, Color.White);
            GameRef.SpriteBatch.Draw(player.Texture, playerRect, Color.White);
            GameRef.SpriteBatch.Draw(enemy.Texture, enemyRect, Color.White);
            GameRef.SpriteBatch.Draw(avatarBorder, playerBorderRect, Color.White);
            playerHealth = (float)player.CurrentHealth / (float)player.GetHealth();
            MathHelper.Clamp(playerHealth, 0f, 1f);
            playerHealthRect.Width = (int)(playerHealth * 286);
            GameRef.SpriteBatch.Draw(avatarHealth, playerHealthRect, healthSourceRect,
            Color.White);
            GameRef.SpriteBatch.Draw(avatarBorder, enemyBorderRect, Color.White);
            enemyHealth = (float)enemy.CurrentHealth / (float)enemy.GetHealth();
            MathHelper.Clamp(enemyHealth, 0f, 1f);
            enemyHealthRect.Width = (int)(enemyHealth * 286);
            GameRef.SpriteBatch.Draw(avatarHealth, enemyHealthRect, healthSourceRect,
            Color.White);
            GameRef.SpriteBatch.DrawString(FontManager.GetFont("test"), player.DisplayName,
            playerName, Color.White);
            GameRef.SpriteBatch.DrawString(FontManager.GetFont("test"), enemy.DisplayName,

            enemyName, Color.White);
            GameRef.SpriteBatch.Draw(player.Texture, playerMiniRect, Color.White);
            GameRef.SpriteBatch.Draw(enemy.Texture, enemyMiniRect, Color.White);
            GameRef.SpriteBatch.End();
        }
        public void SetShadowMonsters(ShadowMonsters.Monster  player, ShadowMonsters.Monster  enemy)
        {
            this.player = player;
            this.enemy = enemy;
            if (player.GetSpeed() >= enemy.GetSpeed())
            {
                turn = CurrentTurn.Players;
            }
            else
            {
                turn = CurrentTurn.Enemies;
            }
        }
        public void SetMoves(IMove playerMove, IMove enemyMove)
        {
            this.playerMove = playerMove;
            this.enemyMove = enemyMove;
        }
        public void Start()
        {
            cTimer = TimeSpan.Zero;
            dTimer = TimeSpan.Zero;
            first = true;
        }
    }
}
