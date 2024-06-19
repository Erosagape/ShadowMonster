using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ShadowMonsters;
using ShadowMonsters.GameStates;


namespace ShadowMonsters.GameStates
{
    public interface IBattleOverState
    {
        void SetShadowMonsters(ShadowMonster player, ShadowMonster  enemy);
    }
    public class BattleOverState : BaseGameState, IBattleOverState
    {
        #region Field Region
        private ShadowMonster player;
        private ShadowMonster enemy;
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
        private readonly string[] battleState;
        private Vector2 battlePosition;
        private bool levelUp;
        #endregion
        #region Property Region
        #endregion
        #region Constructor Region
        public BattleOverState(Game game)
        : base(game)
        {
            battleState = new string[3];
            battleState[0] = "The battle was won!";
            battleState[1] = " gained ";
            battleState[2] = "Continue";
            battlePosition = new Vector2(25, 475);
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
        #endregion
        #region Method Region
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
            if (Xin.CheckKeyReleased(Keys.Space) || Xin.CheckKeyReleased(Keys.Enter))
            {
                if (levelUp)
                {
                    manager.PushState((LevelUpState)GameRef.LevelUpState);
                    GameRef.LevelUpState.SetShadowMonster(player);
                    this.Visible = true;
                }
                else if (Game1.Player.Alive())
                {
                    manager.PopState();
                    manager.PopState();
                }
                else
                {
                    manager.PopState();
                    manager.PopState();
                    // should warp to a location since the player has no avatars
                    // with no access to the world it is hard to say where to warp
                    // to
                }
            }
            base.Update(gameTime);
        }
        public override void Draw(GameTime gameTime)
        {
            Vector2 position = battlePosition;
            base.Draw(gameTime);
            GameRef.SpriteBatch.Begin();
            GameRef.SpriteBatch.Draw(combatBackground, Vector2.Zero, Color.White);
            for (int i = 0; i < 2; i++)
            {
                GameRef.SpriteBatch.DrawString(
                FontManager.GetFont("testfont"),
                battleState[i],
                position,
                Color.Black);
                position.Y += FontManager.GetFont("test").LineSpacing;
            }
            GameRef.SpriteBatch.DrawString(
            FontManager.GetFont("test"),
            battleState[2],
            position,
            Color.Red);
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
            FontManager.GetFont("test"),
            player.DisplayName,
            playerName, Color.
            White);
            GameRef.SpriteBatch.DrawString(
            FontManager.GetFont("test"),
            enemy.DisplayName,
            enemyName,
            Color.White);
            GameRef.SpriteBatch.Draw(player.Texture, playerMiniRect, Color.White);
            GameRef.SpriteBatch.Draw(enemy.Texture, enemyMiniRect, Color.White);
            GameRef.SpriteBatch.End();
        }
        public void SetShadowMonsters(ShadowMonster  player, ShadowMonster  enemy)
        {
            levelUp = false;
            this.player = player;
            this.enemy = enemy;
            long expGained;
            if (player.Alive)
            {
                expGained = player.WinBattle(enemy);
                battleState[0] = player.DisplayName + " has won the battle!";
                battleState[1] = player.DisplayName + " has gained " + expGained + "  experience";
            if (player.CheckLevelUp())
                {
                    battleState[1] += " and gained a level!";
                    foreach (string s in player.KnownMoves.Keys)
                    {
                        if (player.KnownMoves[s].Unlocked == false &&
                        player.Level >= player.KnownMoves[s].UnlockedAt)
                        {
                            player.KnownMoves[s].Unlock();
                            battleState[1] += " " + s + " was unlocked!";
                        }
                    }

                    levelUp = true;
                }
                else
                {
                    battleState[1] += ".";
                }
            }
            else
            {
                expGained = player.LoseBattle(enemy);
                battleState[0] = player.DisplayName + " has lost the battle.";
                battleState[1] = player.DisplayName + " has gained " + expGained + " experience";
            if (player.CheckLevelUp())
                {
                    battleState[1] += " and gained a level!";
                    foreach (string s in player.KnownMoves.Keys)
                    {
                        if (player.KnownMoves[s].Unlocked == false && player.Level >=
                        player.KnownMoves[s].UnlockedAt)
                        {
                            player.KnownMoves[s].Unlock();
                            battleState[1] += " " + s + " was unlocked!";
                        }
                    }
                    levelUp = true;
                }
                else
                {
                    battleState[1] += ".";
                }
            }
        }
        #endregion
    }
}
