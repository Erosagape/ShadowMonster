﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ShadowMonsters;
namespace ShadowMonsters.GameStates
{
    public interface IShadowMonsterSelectionState
    {
        int Selected { get; }
    }
    public class ShadowMonsterSelectionState : BaseGameState,IShadowMonsterSelectionState
    {
        bool mouseOver;
        Texture2D shadowMonsterBorder;
        Texture2D shadowMonsterHealth;
        int Selected1;
        public int Selected
        {
            get { return Selected1; }
        }
        public ShadowMonsterSelectionState(Game game)
            : base(game) { }
        protected override void LoadContent()
        {
            base.LoadContent();
            shadowMonsterBorder = new Texture2D(GraphicsDevice, 300, 75);
            shadowMonsterHealth = new Texture2D(GraphicsDevice, 300, 75);
            Color[] buffer = new Color[300 * 75];
            for (int i = 0; i < buffer.Length; i++)
                buffer[i] = Color.Green;
            shadowMonsterBorder.SetData(buffer);
            buffer = new Color[300 * 25];
            for (int i = 0; i < buffer.Length; i++)
                buffer[i] = Color.Red;
            shadowMonsterHealth.SetData(buffer);
        }
        public override void Update(GameTime gameTime)
        {
            if(Xin.CheckKeyReleased(Keys.Up)||
                Xin.CheckKeyReleased(Keys.W))
            {
                Selected1--;
                if (Selected1 < 0)
                    Selected1 = Game1.Player.BattleShadowMonsters.Length - 1;
            }
            if (Xin.CheckKeyReleased(Keys.Down) ||
    Xin.CheckKeyReleased(Keys.S))
            {
                Selected1++;
                if (Selected1 >=Game1.Player.BattleShadowMonsters.Length)
                    Selected1=0;
            }
            if(Xin.CheckKeyReleased(Keys.Space)||
                Xin.CheckKeyReleased(Keys.Enter)||
                (mouseOver && Xin.CheckMouseReleased(MouseButtons.Left)))
            {
                if (Game1.Player.BattleShadowMonsters[Selected1] != null &&
                    Game1.Player.BattleShadowMonsters[Selected1].Alive) 
                {
                    Game1.Player.SetCurrentShadowMonster(Selected1);
                    GameRef.BattleState.ChangePlayerShadowMonster(Game1.Player.Selected);
                    GameRef.ActionSelectionState.SetShadowMonsters(
                        Game1.Player.Selected,
                        ((BattleState)GameRef.BattleState).EnemyShadowMonster
                        );
                    manager.PopState();
                }
            }
            if (Xin.CheckKeyReleased(Keys.Escape) ||
                Xin.CheckMouseReleased(MouseButtons.Right))
            {
                manager.PopState();
            }
            base.Update(gameTime);
        }
        public override void Draw(GameTime gameTime)
        {
            GameRef.SpriteBatch.Begin();
            base.Draw(gameTime);
            Color tint = Color.White;
            Rectangle destination = new Rectangle(50, 20, 100, 100);
            Rectangle playerBorderRect = new Rectangle(250, 20, 40, 100);
            Rectangle playerHealthRect = new Rectangle(
                playerBorderRect.X+16,
                playerBorderRect.Y+73,
                350,19
                );
            Vector2 playerName = new Vector2(325, 25);
            Rectangle healthSourceRect = new Rectangle(10, 50, 290, 20);
            Point cursor = Xin.MouseAsPoint;
            for(int i = 0; i < Game1.Player.BattleShadowMonsters.Length; i++)
            {
                tint = Color.White;
                if (i == Selected)
                {
                    tint = Color.Red;
                }
                if (Game1.Player.BattleShadowMonsters[i] != null)
                {
                    Monster a = Game1.Player.BattleShadowMonsters[i];
                    GameRef.SpriteBatch.Draw(a.Texture, destination, Color.White);
                    if(destination.Contains(cursor)|| playerBorderRect.Contains(cursor))
                    {
                        Selected1 = i;
                        mouseOver = true;
                    }
                    GameRef.SpriteBatch.Draw(shadowMonsterBorder, playerBorderRect, Color.White);
                    GameRef.SpriteBatch.DrawString(
                        FontManager.GetFont("test"),
                        a.DisplayName,
                        playerName,tint
                        );
                    float playerHealth = (float)a.CurrentHealth / (float)a.GetHealth();
                    MathHelper.Clamp(playerHealth, 0f, 1f);
                    playerHealthRect.Width = (int)(playerHealth * 384);
                    GameRef.SpriteBatch.Draw(
                        shadowMonsterHealth,
                        playerHealthRect,
                        healthSourceRect,
                        Color.White
                        );
                    playerBorderRect.Y += 120;
                    playerName.Y += 120;
                    playerHealthRect.Y += 120;
                }
                destination.Y += 120;
            }
            GameRef.SpriteBatch.End();
        }
    }
}
