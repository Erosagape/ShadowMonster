using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using ShadowMonsters.ConversationComponents;

namespace ShadowMonsters.GameStates
{
    public interface IActionSelectionState
    {
        void SetShadowMonsters(ShadowMonster player, ShadowMonster enemy);
    }
    public class ActionSelectionState : BaseGameState,IActionSelectionState
    {
        ShadowMonster player, enemy;
        GameScene scene;
        Texture2D background,ShadowMonsterBorder,ShadowMonsterHealth;
        Rectangle playerRect, enemyRect, playerBorderRect, enemyBorderRect, playerMiniRect, enemyMiniRect, playerHealthRect, enemyHealthRect, healthSourceRect;
        Vector2 playerName, enemyName;
        float playerHealth, enemyHealth;
        int frameCount = 0;
        public ActionSelectionState(Game game): base(game)
        {
            playerRect = new Rectangle(10, 90, 300, 300);
            enemyRect = new Rectangle(game.Window.ClientBounds.Width - 310, 10, 300, 300);
            playerBorderRect = new Rectangle(10, 10, 300, 75);
            enemyBorderRect = new Rectangle(game.Window.ClientBounds.Width - 310, 320, 300, 75);
            healthSourceRect = new Rectangle(10, 50, 290, 20);
            playerHealthRect = new Rectangle(playerBorderRect.X + 12, playerBorderRect.Y + 52, 286, 16);
            enemyHealthRect = new Rectangle(enemyBorderRect.X + 12, enemyBorderRect.Y + 52, 286, 16);
            playerMiniRect = new Rectangle(playerBorderRect.X + 11, playerBorderRect.Y + 17, 28, 28);
            enemyMiniRect = new Rectangle(enemyBorderRect.X + 11, enemyBorderRect.Y + 11, 28, 28);
            playerName = new Vector2(playerBorderRect.X + 55, playerBorderRect.Y + 5);
            enemyName = new Vector2(enemyBorderRect.X + 55, enemyBorderRect.Y + 5);
        }
        protected override void LoadContent()
        {
            base.LoadContent();
            background = new Texture2D(GraphicsDevice, 1280, 720);
            Color[] buffer = new Color[1280 * 720];
            for(int i = 0; i < buffer.Length; i++)
            {
                buffer[i] = Color.White;
            }
            background.SetData(buffer);
            ShadowMonsterBorder = new Texture2D(GraphicsDevice, 300, 75);
            ShadowMonsterHealth = new Texture2D(GraphicsDevice, 300, 25);
            buffer = new Color[300 * 75];
            for(int i = 0; i < buffer.Length; i++)
            {
                buffer[i] = Color.Green;
            }
            ShadowMonsterBorder.SetData(buffer);

            buffer = new Color[300 * 25];
            for (int i = 0; i < buffer.Length; i++)
            {
                buffer[i] = Color.Red;
            }
            ShadowMonsterHealth.SetData(buffer);
            scene = new GameScene(GameRef, "", new List<SceneOption>());
            SceneOption option = new SceneOption("Fight", "Fight", new SceneAction());
            scene.Options.Add(option);
            option = new SceneOption("Item", "Item", new SceneAction());
            scene.Options.Add(option);
            option = new SceneOption("Flee", "Flee", new SceneAction());
            scene.Options.Add(option);
        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            frameCount++;
            scene.Update();
            if(Xin.CheckKeyReleased(Keys.Space)||
                Xin.CheckKeyReleased(Keys.Enter) && frameCount >= 5)
            {
                frameCount = 0;
                manager.PopState();
                if (scene.SelectedIndex == 0)
                {

                }
                if (scene.SelectedIndex == 1)
                {
                    manager.PushState((ShadowMonsterSelectionState)GameRef.ShadowMonsterSelectionState);
                }
                if (scene.SelectedIndex == 2)
                {
                    manager.PushState((ItemSelectionState)GameRef.ItemSelectionState);
                }
                if (scene.SelectedIndex == 3)
                {
                    manager.ChangeState(GameRef.GamePlayState);
                }
            }
        }
        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            GameRef.SpriteBatch.Begin();
            scene.Draw(GameRef.SpriteBatch, background);

            GameRef.SpriteBatch.Draw(player.Texture, playerRect, Color.White);
            GameRef.SpriteBatch.Draw(enemy.Texture, enemyRect, Color.White);

            GameRef.SpriteBatch.Draw(ShadowMonsterBorder, playerBorderRect, Color.White);

            playerHealth = (float)player.CurrentHealth / (float)player.GetHealth();
            MathHelper.Clamp(playerHealth, 0f, 1f);
            
            playerHealthRect.Width = (int)(playerHealth * 286);
            GameRef.SpriteBatch.Draw(ShadowMonsterHealth, playerHealthRect, Color.White);
            GameRef.SpriteBatch.Draw(ShadowMonsterBorder, playerBorderRect, Color.White);

            enemyHealth = (float)enemy.CurrentHealth / (float)enemy.GetHealth();
            MathHelper.Clamp(enemyHealth, 0f, 1f);
            enemyHealthRect.Width = (int)(enemyHealth * 286);

            GameRef.SpriteBatch.Draw(
                ShadowMonsterHealth,
                enemyHealthRect,
                healthSourceRect,
                Color.White
                );
            GameRef.SpriteBatch.DrawString(
                FontManager.GetFont("test"),
                player.DisplayName,
                playerName,
                Color.White
                );
            GameRef.SpriteBatch.DrawString(
                FontManager.GetFont("test"),
                enemy.DisplayName,
                enemyName,
                Color.White
            );
            GameRef.SpriteBatch.Draw(
                player.Texture,
                playerMiniRect,
                player.Source,
                Color.White
                );
            GameRef.SpriteBatch.Draw(
                player.Texture,
                playerMiniRect,
                player.Source,
                Color.White                
                );
            GameRef.SpriteBatch.End();
        }
        public void SetShadowMonsters(ShadowMonster player,ShadowMonster enemy)
        {
            this.player = player;
            this.enemy = enemy;
            player.StartCombat();
            enemy.StartCombat();
        }
    }
}
