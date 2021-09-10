using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ShadowMonsters;
using ShadowMonsters.ConversationComponents;
using ShadowMonsters.GameStates;

using System.Collections.Generic;

namespace ShadowMonsters.GameStates
{
    public interface IBattleState
    {
        void SetShadowMonsters(Monster player, Monster enemy);
        void StartBattle();
        void ChangePlayerShadowMonster(Monster selected);
    }
    public class BattleState : BaseGameState, IBattleState
    {
        #region Field Region
        private Monster player;
        private Monster enemy;
        private GameScene combatScene;
        private Texture2D combatBackground;
        private Rectangle playerRect;
        private Rectangle enemyRect;
        private Rectangle playerBorderRect;
        private Rectangle enemyBorderRect;
        private Rectangle playerMiniRect;
        private Rectangle enemyMiniRect;
        private Rectangle playerHealthRect;
        private Rectangle enemyHealthRect;
        private Rectangle healthSourceRect;
        private Vector2 playerName;
        private Vector2 enemyName;
        private float playerHealth;
        private float enemyHealth;
        private Texture2D avatarBorder;
        private Texture2D avatarHealth;
        public Monster EnemyShadowMonster { get { return enemy; } }
        #endregion
        #region Property Region
        #endregion
        #region Constructor Region
        public BattleState(Game game)
        : base(game)
        {

            playerRect = new Rectangle(10, 90, 300, 300);
            enemyRect = new Rectangle(GameRef.Window.ClientBounds.Width - 310, 10, 300, 300);
            playerBorderRect = new Rectangle(10, 10, 300, 75);
            enemyBorderRect = new Rectangle(GameRef.Window.ClientBounds.Width - 310, 320, 300,
            75);
            healthSourceRect = new Rectangle(10, 50, 290, 20);
            playerHealthRect = new Rectangle(
            playerBorderRect.X + 12,
            playerBorderRect.Y + 52,
            286,
            16);
            enemyHealthRect = new Rectangle(enemyBorderRect.X + 12, enemyBorderRect.Y + 52,
            286, 16);
            playerMiniRect = new Rectangle(playerBorderRect.X + 11, playerBorderRect.Y + 11,
            28, 28);
            enemyMiniRect = new Rectangle(enemyBorderRect.X + 11, enemyBorderRect.Y + 11, 28,
            28);
            playerName = new Vector2(playerBorderRect.X + 55, playerBorderRect.Y + 5);
            enemyName = new Vector2(enemyBorderRect.X + 55, enemyBorderRect.Y + 5);
        }
        #endregion
        #region Method Region
        protected override void LoadContent()
        {
            if (combatScene == null)
            {
                combatBackground = new Texture2D(GraphicsDevice, 1280, 720);
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
                combatScene = new GameScene(GameRef, "", new List<SceneOption>());
            }
            base.LoadContent();
        }
        public override void Update(GameTime gameTime)
        {
            if (Xin.CheckKeyReleased(Keys.P))
            {
                manager.PopState();
            }
            combatScene.Update();
            if (Xin.CheckKeyReleased(Keys.Space) ||
            Xin.CheckKeyReleased(Keys.Enter) ||
            (Xin.CheckMouseReleased(MouseButtons.Left) &&
            combatScene.IsMouseOver))
            {
                manager.PushState((DamageState)GameRef.DamageState);
                GameRef.DamageState.SetShadowMonsters(player, enemy);
                IMove enemyMove = null;
                do
                {
                    int move = random.Next(0, enemy.KnownMoves.Count);

                    int i = 0;

                    foreach (string s in enemy.KnownMoves.Keys)
                    {
                        if (move == i)
                        {
                            enemyMove = (IMove)enemy.KnownMoves[s].Clone();
                        }
                        i++;
                    }
                } while (!enemyMove.Unlocked);
                GameRef.DamageState.SetMoves(
                (IMove)player.KnownMoves[combatScene.OptionText].Clone(),
                enemyMove);
                GameRef.DamageState.Start();
                player.Update();
                enemy.Update();
            }
            Visible = true;
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            GameRef.SpriteBatch.Begin();
            GameRef.SpriteBatch.Draw(combatBackground, Vector2.Zero, Color.White);
            combatScene.Draw(GameRef.SpriteBatch, combatBackground);
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
            GameRef.SpriteBatch.DrawString(
            FontManager.GetFont("testfont"),
            player.DisplayName,
            playerName,
            Color.White);
            GameRef.SpriteBatch.DrawString(
            FontManager.GetFont("testfont"),
            enemy.DisplayName,
            enemyName,
            Color.White);
            GameRef.SpriteBatch.Draw(player.Texture, playerMiniRect, Color.White);
            GameRef.SpriteBatch.Draw(enemy.Texture, enemyMiniRect, Color.White);
            GameRef.SpriteBatch.End();
        }
        public void SetShadowMonsters(Monster player, Monster enemy)
        {
            this.player = player;
            this.enemy = enemy;
            player.StartCombat();
            enemy.StartCombat();
            List<SceneOption> moves = new List<SceneOption>();
            if (combatScene == null)
            {
                LoadContent();
            }

            foreach (string s in player.KnownMoves.Keys)
            {
                if (player.KnownMoves[s].Unlocked)
                {
                    SceneOption option = new SceneOption(s, s, new SceneAction());
                    moves.Add(option);
                }
            }
            combatScene.SelectedIndex = 0;
            combatScene.Options = moves;
        }
        public void StartBattle()
        {
            player.StartCombat();
            enemy.StartCombat();
            playerHealth = 100f;
            enemyHealth = 100f;
        }
        public void ChangePlayerShadowMonster(Monster selected)
        {
            this.player = selected;
            List<SceneOption> moves = new List<SceneOption>();
            foreach (string s in player.KnownMoves.Keys)
            {
                if (player.KnownMoves[s].Unlocked)
                {
                    SceneOption option = new SceneOption(s, s, new SceneAction());
                    moves.Add(option);
                }
            }
            combatScene.SelectedIndex = 0;
            combatScene.Options = moves;
        }
        #endregion
    }
}
